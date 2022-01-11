/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;
using Org.BouncyCastle.Crypto;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    /// <summary>
    /// CmdletUtils class provides methods that performs operations in the context of the Host UI of the cmdlet being invoked.
    /// </summary>
    public class CmdletUtils
    {
        private const string PUBLIC_KEY_SUFFIX = "_public.pem";
        private const string PRIVATE_KEY_SUFFIX = ".pem";
        private const string DEFAULT_KEY_NAME = "oci_api_key";
        private const string CHOICE_NO = "No";
        private const string CHOICE_YES = "Yes";
        private const string KEY_DIR_PROMPT = "Enter a directory for your keys to be created";
        private const string KEY_DIR_PROPERTY = "Key Directory";
        private const string KEY_NAME_PROMPT = "Enter a name for your key";
        private const string KEY_NAME_PROPERTY = "Key Name";
        private const string PASSWORDS_DONT_MATCH = "Entered passwords doesn't match!";
        private const string PRIVATE_KEY_PASSPHRASE = "Enter a passphrase for your private key (empty for no passphrase):";
        private const string CONFIRM_PASSPHRASE = "Confirm Passphrase:";
        private const string KEYS_CREATED = "Keys written to path :";
        private const string KEYS_DIRECTORY_INFO = "Keys will be written to directory :";
        public static readonly string DEFAULT_OCI_DIR = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".oci"));

        private readonly PSCmdlet CMDLET;

        public CmdletUtils(in PSCmdlet cmdlet)
        {
            this.CMDLET = cmdlet;
        }

        /// <summary>
        /// Prompt Yes or No choice on the Host UI
        /// </summary>
        /// <param name="promptMessage">Message to prompt</param>
        /// <param name="isYesDefault">Use 'Yes' as a default option</param>
        /// <returns></returns>
        public bool PromptYesNoChoice(string promptMessage, bool isYesDefault)
        {
            var yesorno = new Collection<ChoiceDescription>
            {
                new ChoiceDescription(CHOICE_NO),
                new ChoiceDescription(CHOICE_YES)
            };
            int ret = CMDLET.Host.UI.PromptForChoice(string.Empty, promptMessage, yesorno, isYesDefault ? 1 : 0);
            return ret != 0;
        }

        /// <summary>
        /// Prompt a value of type T on the Host UI
        /// </summary>
        /// <typeparam name="T">Type name of the value expected</typeparam>
        /// <param name="promptMessage">Message to prompt</param>
        /// <param name="fieldName">Property whose value is being prompted</param>
        /// <returns>A value of type T</returns>
        public T PromptValue<T>(string promptMessage, string fieldName)
        {
            T result = default;
            FieldDescription pathField = new FieldDescription(fieldName);
            pathField.SetParameterType(typeof(T));
            var descriptions = new Collection<FieldDescription>
            {
                pathField
            };
            var prompt = CMDLET.Host.UI.Prompt(String.Empty, promptMessage, descriptions);
            if (prompt != null)
            {
                result = (T)Convert.ChangeType(prompt[fieldName].BaseObject, typeof(T));
            }
            return result;
        }

        /// <summary>
        /// Prompt a path and return result relative to the user's active powershell session.
        /// </summary>
        /// <param name="promptMessage">Message to prompt</param>
        /// <param name="fieldName">Property whose value is being prompted</param>
        /// <returns>Path string adjusted to the users powershell session active directory</returns>
        public string PromptFullPath(string promptMessage, string fieldName)
        {
            string path = null;
            var prompt = PromptValue<string>(promptMessage, fieldName);
            if (!string.IsNullOrEmpty(prompt))
            {
                path = GetSessionAbsPath(prompt);
            }
            return path;
        }

        /// <summary>
        /// Prompt a string on the Host UI and validate the string using the validationFunction passed.
        /// </summary>
        /// <param name="promptMessage">Message to prompt</param>
        /// <param name="fieldName">Property whose value is being prompted</param>
        /// <param name="validationFunction">Function delagate the validates the value returned by the prompt</param>
        /// <returns></returns>
        public string PromptValidateString(string promptMessage, string fieldName, Func<string, string> validationFunction)
        {
            string ret;
            do
            {
                ret = PromptValue<string>(promptMessage, fieldName);
                if (String.IsNullOrEmpty(ret))
                {
                    CMDLET.WriteWarning($"{fieldName} cannot be empty!!");
                }
                else
                {
                    ret = validationFunction(ret);
                }
            } while (String.IsNullOrEmpty(ret));
            return ret;
        }

        /// <summary>
        /// Prompt a passphrase on the Host UI
        /// </summary>
        /// <param name="message">Message to prompt</param>
        /// <returns></returns>
        public SecureString PromptPassPhrase(string message)
        {
            CMDLET.Host.UI.Write(message);
            return CMDLET.Host.UI.ReadLineAsSecureString();
        }

        /// <summary>
        /// Delete a file and notify the user
        /// </summary>
        /// <param name="path">Path of the file</param>
        public void InformDeleteFile(string path)
        {
            File.Delete(path);
            CMDLET.Host.UI.WriteLine($"File {path} deleted.");
        }

        /// <summary>
        /// Get a path relative to the user's active powershell session.
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns>Path relative to the user's active powershell session</returns>
        public string GetSessionAbsPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return path;
            }
            return CMDLET.SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
        }

        /// <summary>
        /// Create PEM Key Files with the values passed in or prompt the user for missing details.
        /// </summary>
        /// <param name="keyDirectory">Directory path of the key(s)</param>
        /// <param name="keyName">Name of the key(s)</param>
        /// <param name="passPhrase">Passphrase to encrypt the keys</param>
        /// <returns>Tuple<KeyPair,PrivateKeyPath,Passphrase></KeyPair></returns>
        public Tuple<AsymmetricCipherKeyPair, string, string> CreateKeys(string keyDirectory, string keyName, string passPhrase)
        {
            if (String.IsNullOrEmpty(keyDirectory))
            {
                keyDirectory = PromptFullPath($"{KEY_DIR_PROMPT} [{CmdletUtils.DEFAULT_OCI_DIR}]", KEY_DIR_PROPERTY);
            }
            else
            {
                keyDirectory = GetSessionAbsPath(keyDirectory);
            }
            //assume default directory
            if (string.IsNullOrEmpty(keyDirectory))
            {
                keyDirectory = CmdletUtils.DEFAULT_OCI_DIR;
            }
            CMDLET.Host.UI.WriteLine($"{KEYS_DIRECTORY_INFO} {keyDirectory}");
            if (String.IsNullOrEmpty(keyName))
            {
                keyName = PromptValue<string>($"{KEY_NAME_PROMPT} [{DEFAULT_KEY_NAME}]", KEY_NAME_PROPERTY);
            }
            //assume default key name    
            if (string.IsNullOrEmpty(keyName))
            {
                keyName = DEFAULT_KEY_NAME;
            }
            string privateKeyPath = Path.Combine(keyDirectory, keyName) + PRIVATE_KEY_SUFFIX;
            string publicKeyPath = Path.Combine(keyDirectory, keyName) + PUBLIC_KEY_SUFFIX;
            if (File.Exists(privateKeyPath) || File.Exists(publicKeyPath))
            {
                bool deleteKeyFile = PromptYesNoChoice($"Key File name {keyName} already exists in {keyDirectory}. Do you want to overwrite!?", false);
                if (deleteKeyFile)
                {
                    InformDeleteFile(privateKeyPath);
                    InformDeleteFile(publicKeyPath);
                }
                else
                {
                    throw new Exception($"Avoid overwriting existing key file at {keyDirectory}. Key setup terminated!");
                }
            }
            if (passPhrase == null)
            {
                SecureString pass = null, confirm = null;
                do
                {
                    if (pass != null)
                    {
                        CMDLET.WriteWarning(PASSWORDS_DONT_MATCH);
                    }
                    pass = PromptPassPhrase(PRIVATE_KEY_PASSPHRASE);
                    if (pass?.Length != 0)
                    {
                        confirm = PromptPassPhrase(CONFIRM_PASSPHRASE);
                    }
                    else
                    {
                        break;
                    }
                    passPhrase = KeyUtils.ConvertToUnsecureString(pass);
                } while (passPhrase.CompareTo(KeyUtils.ConvertToUnsecureString(confirm)) != 0);
                pass?.Dispose();
                confirm?.Dispose();
            }
            else if (passPhrase.CompareTo(String.Empty) == 0)
            {
                //user doesn't want any passphrase and is using the cmdlet in non-interactive mode
                passPhrase = null;
            }
            OCIFileUtils.CreateDirectory(keyDirectory);
            AsymmetricCipherKeyPair keyPair = KeyUtils.GenerateKeyPair();
            KeyUtils.WritePEMKeyToFile(publicKeyPath, keyPair.Public);
            KeyUtils.WritePEMKeyToFile(privateKeyPath, keyPair.Private, passPhrase);
            CMDLET.Host.UI.WriteLine($"{ KEYS_CREATED} {privateKeyPath}, {publicKeyPath}");
            return new Tuple<AsymmetricCipherKeyPair, string, string>(keyPair, privateKeyPath, passPhrase);
        }
    }
}
