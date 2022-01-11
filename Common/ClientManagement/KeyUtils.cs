/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    public class KeyUtils
    {
        private const string DECRYPT_NULL = "Attempting to decrypt null";
        private const string KEYPAIR_NULL = "Expected Keypair is null";
        private const string PEMKEY_NULL = "PEM key value is null";
        private const string KEYFILE_EXISTS = "Key file already exists at path";

        /// <summary>
        /// Generate a 2048 bit RSA Key Pair. 
        /// </summary>
        /// <returns></returns>
        public static AsymmetricCipherKeyPair GenerateKeyPair()
        {
            RsaKeyPairGenerator rsaKeyPair = new RsaKeyPairGenerator();
            rsaKeyPair.Init(new Org.BouncyCastle.Crypto.KeyGenerationParameters(new SecureRandom(), 2048));
            return rsaKeyPair.GenerateKeyPair();
        }

        /// <summary>
        /// Write the PEM Key to the file and optionally encrypt it with the requested algorithm or AES-256-CBC.
        /// </summary>
        /// <param name="keyPath">Path to the key file</param>
        /// <param name="key">Asymmetric Key</param>
        /// <param name="password">Password to encrypt the key file</param>
        /// <param name="algorithm">Encryption algorithm</param>
        /// <returns></returns>
        public static bool WritePEMKeyToFile(string keyPath, AsymmetricKeyParameter key, string password = null, string algorithm = "AES-256-CBC")
        {
            if (key == null)
            {
                throw new ArgumentNullException(PEMKEY_NULL);
            }
            if (File.Exists(keyPath))
            {
                throw new ArgumentException($"{KEYFILE_EXISTS} {keyPath}");
            }
            using (var textWriter = new StreamWriter(keyPath))
            {
                var pemWriter = new PemWriter(textWriter);
                if (password != null)
                {
                    pemWriter.WriteObject(key, algorithm, password.ToCharArray(), new SecureRandom());
                }
                else
                {
                    pemWriter.WriteObject(key);
                }
                pemWriter.Writer.Flush();
            }
            //<TODO> add file permissions; Currently .Net Standard doesn't support ACL Permissions.
            return true;
        }

        /// <summary>
        /// Get the public key fingerprint(hash) of an Aysmmetric Cipher Key Pair
        /// </summary>
        /// <param name="keyPair">Key pair to fingerprint</param>
        /// <returns>MD5 Hash of the given keypair</returns>
        public static string GetPublicKeyFingerprint(AsymmetricCipherKeyPair keyPair)
        {
            if (keyPair == null)
            {
                throw new ArgumentNullException(KEYPAIR_NULL);
            }
            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyPair.Public);
            byte[] serializedPublicKey = publicKeyInfo.ToAsn1Object().GetDerEncoded();
            return ComputeHash(serializedPublicKey);
        }

        /// <summary>
        /// Computes the MD5 hash of byte array
        /// </summary>
        /// <param name="binaryPublicKey">Byte array of the public key</param>
        /// <returns>MD5 hash encoded in Hex</returns>
        public static string ComputeHash(byte[] binaryPublicKey)
        {
            MD5 hashComputer = MD5.Create();
            byte[] hashedKey = hashComputer.ComputeHash(binaryPublicKey);
            string hash = null;
            foreach (byte b in hashedKey)
            {
                hash += string.Concat(":", b.ToString("x2"));
            }
            return hash?.Remove(0, 1);
        }

        /// <summary>
        /// Decrypt a secure string 
        /// </summary>
        /// <param name="securePassword">String to be decrypted</param>
        /// <returns>Decrypted string</returns>
        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException(DECRYPT_NULL);
            }
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
