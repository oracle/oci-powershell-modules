/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Sets the region/profile/config file preference for this session
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    [Cmdlet("Set", "OCIClientSession")]
    [OutputType(typeof(Oci.PSModules.Common.Cmdlets.ClientManagement.OCIClientSession))]
    public class SetOCIClientSession : PSCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The region to make calls against for this session. Set empty string to delete existing OCI_PS_REGION")]
        public string RegionId { get; set; }
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The profile in the config file to load for this session. Set empty string to delete existing OCI_PS_PROFILE")]
        public string Profile { get; set; }
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the config file to be used for this session. Set empty string to delete existing OCI_PS_CONFIG")]
        public string Config { get; set; }

        protected override void ProcessRecord()
        {
            if (!String.IsNullOrEmpty(RegionId))
            {
                //To Validate Region Id
                Region.FromRegionId(RegionId);
            }
            OCIClientSession.Instance.SetSession(RegionId, Profile, Config);
            WriteObject(OCIClientSession.Instance);
        }
    }
}