/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System.IO;
using Oci.Common.Utils;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    /// <summary>
    /// This class reads provides accessors to the read PEM key files.
    /// </summary>
    class FileKeySupplier
    {
        private readonly string pemPrivateKeyPath;
        private readonly string passPhrase;

        public FileKeySupplier(string pemPrivateKeyPath, string passPhrase)
        {
            this.pemPrivateKeyPath = pemPrivateKeyPath;
            this.passPhrase = passPhrase;
        }

        public AsymmetricCipherKeyPair GetKeyPair()
        {
            AsymmetricCipherKeyPair keyPair;
            using (StreamReader reader = File.OpenText(FileUtils.ExpandUserHome(pemPrivateKeyPath)))
            {
                try
                {
                    // PemReader uses password only if the private is password encrypted.
                    // If password is passed for a plain private key, it would be ignored.
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader, new PasswordFinder(this.passPhrase)).ReadObject();
                }
                catch (InvalidCipherTextException)
                {
                    throw new InvalidCipherTextException("Incorrect passphrase for private key");
                }
                catch (PasswordException)
                {
                    throw new PasswordException("Private key is encrypted with a pass phrase. Please provide passphrase in the config");
                }
                catch (InvalidKeyException)
                {
                    throw new InvalidKeyException("Invalid Key has been provided");
                }
            }
            return keyPair;
        }

        private class PasswordFinder : IPasswordFinder
        {
            private readonly string passPhrase;

            public PasswordFinder(string passPhrase)
            {
                this.passPhrase = passPhrase;
            }

            public char[] GetPassword()
            {
                return passPhrase?.ToCharArray();
            }
        }
    }
}