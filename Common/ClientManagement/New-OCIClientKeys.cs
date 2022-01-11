/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System.Management.Automation;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    /// <summary>
    /// Cmdlet to create a PEM formatted asymmetric cipher key pair. 
    /// </summary>
    [Cmdlet("New", "OCIClientKeys")]
    [OutputType(typeof(void))]
    public class NewOCIClientKeys : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "A name for the key. Generated key files will be {key-name}.pem and {key-name}_public.pem")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An optional directory to output the generated keys.")]
        [ValidateNotNullOrEmpty]
        public string KeyDirectory { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An optional passphrase to encrypt the private key.Specify \"\" to avoid encrypting the private key.")]
        [ValidateNotNull]
        public string PassPhrase { get; set; }

        private CmdletUtils util;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            util = new CmdletUtils(this);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            util.CreateKeys(KeyDirectory, KeyName, PassPhrase);
        }
    }
}
