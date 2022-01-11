/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using Oci.Common;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;


namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    /// <summary>
    /// Cmdlet to setup a config used by a OCI Client.
    /// </summary>
    [Cmdlet("Set", "OCIClientConfig")]
    [OutputType(typeof(void))]
    public class SetOCIClientConfig : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Path of the config file")]
        [ValidateNotNullOrEmpty]
        public string ConfigPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Configuration profile name")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "User OCID")]
        [ValidateNotNullOrEmpty]
        public string UserOCID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tenancy OCID")]
        [ValidateNotNullOrEmpty]
        public string TenancyOCID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "User region ID")]
        [ValidateNotNullOrEmpty]
        public string RegionID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A name for the key. Generated key files will be {key-name}.pem and {key-name}_public.pem")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An optional directory to output the generated keys.")]
        [ValidateNotNullOrEmpty]
        public string KeyDirectory { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An optional passphrase to encrypt the private key. Specify \"\" to avoid encrypting the private key.")]
        [ValidateNotNull]
        public string PassPhrase { get; set; }

        private const string DEFAULTCONFIGNAME = "config";
        private const string DEFAULTPROFILE = "DEFAULT";
        private const string USER_OCID_PROMPT = "Enter a user OCID";
        private const string USER_OCID_PROPERTY = "User OCID";
        private const string TENANCY_OCID_PROMPT = "Enter a tenancy OCID";
        private const string TENANCY_OCID_PROPERTY = "Tenancy OCID";
        private const string CONFIG_FILE_PROMPT = "Enter full path of the config file";
        private const string CONFIG_FILE_PROPERTY = "Config file Path";
        private const string PROFILE_PROMPT = "Enter the name of the profile you would like to create";
        private const string PROFILE_PROPERTY = "Profile Name";
        private const string KEY_CHOICE_PROMPT = "Do you want to generate a new API Signing RSA key pair? (If you decline you will be asked to supply the path to an existing key.)";
        private const string PRIVATE_KEY_PROMPT = "Enter the location of your API Signing private key file";
        private const string PRIVATE_KEY_PROPERTY = "Private Key";
        private const string PASS_PHRASE_PROMPT = "Enter the passphrase for your private key:";
        private const string UPLOAD_KEY_MESSAGE = " If you haven't already uploaded your public key through the console,\n follow the instructions on the page linked below in the section 'How to \n upload the public key':\n https://docs.cloud.oracle.com/Content/API/Concepts/apisigningkey.htm#How2";
        private const string CONFIG_FILE_WRITTEN = "Config written to ";
        private const string INVALID_OCID_FORMAT = "Invalid ocid format. Instructions to find OCIDs: https://docs.cloud.oracle.com/Content/API/Concepts/apisigningkey.htm#Other";
        private const string UNRECOGNIZED_REGION_PROMPT = "Continue with unrecognized region? (Enter 'No' to re-enter region)";
        private const string VALID_REGION_INFO = "Valid regions can be found here: https://docs.cloud.oracle.com/Content/General/Concepts/regions.htm";
        private const string CONFIG_FILE_INFO = "Config will be saved at :";

        private static readonly string DEFAULT_CONFIG_PATH = Path.GetFullPath(Path.Combine(CmdletUtils.DEFAULT_OCI_DIR, DEFAULTCONFIGNAME));
        private static readonly HashSet<string> regionIDSet;

        private CmdletUtils util;
        private string privateKeyPath;
        private string publicKeyFingerprint;


        static SetOCIClientConfig()
        {
            regionIDSet = new HashSet<string>();
            //create a set of valid values
            foreach (var region in Region.Values())
            {
                regionIDSet.Add(region.RegionId);
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            util = new CmdletUtils(this);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SetConfigProfileDetails();
            //prompt if the user hasn't specified a "valid" value
            if (String.IsNullOrEmpty(UserOCID) || ValidateOCID(UserOCID) == null)
            {
                UserOCID = util.PromptValidateString(USER_OCID_PROMPT, USER_OCID_PROPERTY, ValidateOCID);
            }
            if (String.IsNullOrEmpty(TenancyOCID) || ValidateOCID(TenancyOCID) == null)
            {
                TenancyOCID = util.PromptValidateString(TENANCY_OCID_PROMPT, TENANCY_OCID_PROPERTY, ValidateOCID);
            }
            if (String.IsNullOrEmpty(RegionID) || ValidateRegion(RegionID) == null)
            {
                RegionID = GetRegionID();
            }
            SetKeyDetails();
            WriteDebug("Config Path:" + ConfigPath);
            WriteDebug("Profile Name:" + ProfileName);
            WriteDebug("User OCID:" + UserOCID);
            WriteDebug("Tenancy OCID:" + TenancyOCID);
            WriteDebug("Region ID:" + RegionID);
            WriteDebug("Private Key Path:" + privateKeyPath);
            WriteDebug("Public Key Fingerprint:" + publicKeyFingerprint);
            WriteConfig(ConfigPath);
            Host.UI.WriteLine(UPLOAD_KEY_MESSAGE);
        }

        private void SetConfigProfileDetails()
        {
            //config path not assigned in cmdlet invocation
            if (ConfigPath == null)
            {
                ConfigPath = util.PromptFullPath($"{CONFIG_FILE_PROMPT} [{DEFAULT_CONFIG_PATH}]", CONFIG_FILE_PROPERTY);
            }
            else
            {
                ConfigPath = util.GetSessionAbsPath(ConfigPath);
            }
            //Assume default path if the user didn't enter a path 
            if (string.IsNullOrEmpty(ConfigPath))
            {
                ConfigPath = DEFAULT_CONFIG_PATH;
            }
            Host.UI.WriteLine($"{CONFIG_FILE_INFO} {ConfigPath}");
            if (File.Exists(ConfigPath))
            {
                bool addProfile = util.PromptYesNoChoice($"Config file {ConfigPath} already exists. Do you want add a profile here?" +
                    " (If no, you will be prompted to overwrite the file)", true);
                if (addProfile)
                {
                    if (String.IsNullOrEmpty(ProfileName) || ValidateProfileName(ProfileName) == null)
                    {
                        ProfileName = util.PromptValidateString(PROFILE_PROMPT, PROFILE_PROPERTY, ValidateProfileName);
                    }
                }
                else
                {
                    bool deleteConfig = util.PromptYesNoChoice($"File {ConfigPath} already exists. Do you want to overwrite (Removes existing profiles!!!)?", false);
                    if (deleteConfig)
                    {
                        util.InformDeleteFile(ConfigPath);
                    }
                    else
                    {
                        throw new Exception($"Avoid overwriting existing config at {ConfigPath}. Config setup terminated!");
                    }
                }
            }
            //Assume default profile name if the user hasn't specified one
            if (String.IsNullOrEmpty(ProfileName))
            {
                ProfileName = DEFAULTPROFILE;
            }
            ProfileName = ProfileName.ToUpperInvariant();
        }

        private void SetKeyDetails()
        {
            string pvtKeyPath;
            string passKey = null;
            AsymmetricCipherKeyPair keyPair;
            bool generateKeys = util.PromptYesNoChoice(KEY_CHOICE_PROMPT, true);
            //Generate new keys
            if (generateKeys)
            {
                var keyInfo = util.CreateKeys(KeyDirectory, KeyName, PassPhrase);
                keyPair = keyInfo.Item1;
                pvtKeyPath = keyInfo.Item2;
                passKey = keyInfo.Item3;
            }
            else
            {
                //Use existing keys
                var promptPath = util.PromptValidateString(PRIVATE_KEY_PROMPT, PRIVATE_KEY_PROPERTY, ValidatePathNotEmpty);
                pvtKeyPath = util.GetSessionAbsPath(promptPath);
                // util.PromptFullPath(PRIVATE_KEY_PROMPT, PRIVATE_KEY_PROPERTY);
                try
                {
                    keyPair = new FileKeySupplier(pvtKeyPath, null).GetKeyPair();
                }
                catch (PasswordException)
                {
                    SecureString pass = util.PromptPassPhrase(PASS_PHRASE_PROMPT);
                    passKey = KeyUtils.ConvertToUnsecureString(pass);
                    keyPair = new FileKeySupplier(pvtKeyPath, passKey).GetKeyPair();
                }
            }
            PassPhrase = passKey;
            privateKeyPath = pvtKeyPath;
            publicKeyFingerprint = KeyUtils.GetPublicKeyFingerprint(keyPair);
        }

        private string GetRegionID()
        {
            return util.PromptValidateString(String.Concat("Enter a region (", String.Join(", ", regionIDSet), ")"), "Region ID", ValidateRegion);
        }

        private string ValidatePathNotEmpty(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                WriteWarning("Path cannot be empty!");
                return null;
            }
            return path;
        }

        private string ValidateRegion(string region)
        {
            region = region.ToLowerInvariant();
            if (!regionIDSet.Contains(region))
            {
                WriteWarning($"Unrecognized region: {region}. {VALID_REGION_INFO}");
                bool proceed = util.PromptYesNoChoice(UNRECOGNIZED_REGION_PROMPT, false);
                if (!proceed)
                {
                    return null;
                }
            }
            return region;
        }

        private string ValidateOCID(string ocid)
        {
            Regex ocidPattern = new Regex(@"^ocid\d\.[a-zA-Z\-]+\.oc\d\.[\w\-]*(\.[\w\-]*)?\.[\w\-]+$");
            if (!ocidPattern.IsMatch(ocid))
            {
                WriteWarning(INVALID_OCID_FORMAT);
                ocid = null;
            }
            return ocid;
        }

        private string ValidateProfileName(string profileName)
        {
            string valid = null;
            try
            {
                profileName = profileName.ToUpperInvariant();
                ConfigFileReader.Parse(ConfigPath, profileName);
                WriteWarning($"Profile {profileName} already exists!! Can't specify a profile that exists.");
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.Contains(profileName))
                {
                    valid = profileName;
                }
            }
            return valid;
        }

        private void WriteConfig(string path)
        {
            var dir = Path.GetDirectoryName(path);
            OCIFileUtils.CreateDirectory(dir);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{ProfileName}]");
            sb.AppendLine($"user={UserOCID}");
            sb.AppendLine($"fingerprint={publicKeyFingerprint}");
            sb.AppendLine($"key_file={privateKeyPath}");
            sb.AppendLine($"tenancy={TenancyOCID}");
            sb.AppendLine($"region={RegionID}");
            if (PassPhrase != null)
            {
                sb.AppendLine($"pass_phrase={PassPhrase}");
            }
            if (File.Exists(path))
            {
                sb.Insert(0, "\n\n");
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.Write(sb.ToString());
            }
            Host.UI.WriteLine($"{CONFIG_FILE_WRITTEN}{path}");
            //<TODO> Restrict file access permissions; Currently .Net Standard doesn't support ACL Permissions.
            //FileSecurity fSecurity = new FileSecurity(path, AccessControlSections.Owner);
            //fSecurity.AddAccessRule()
            //FileInfo fInfo = new FileInfo(path);
            //fInfo.SetAccessControl(fSecurity);
            //var ds = new DirectorySecurity();
            //ds.AddAccessRule(new FileSystemAccessRule(adminSI, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            //ds.SetAccessRuleProtection(true, false); // disable inheritance and clear any inherited permissions
            //System.IO.FileSystemAclExtensions.SetAccessControl(new DirectoryInfo(< path to directory >), ds);
        }
    }
}