/**
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Clears the OCI Cmdlet parameter preference for this session
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    [Cmdlet("Clear", "OCIClientSession")]
    [OutputType(typeof(void))]
    public class ClearOCIClientSession : PSCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the region preference for this session.", ParameterSetName = DEFAULT)]
        public SwitchParameter RegionId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the profile preference in the config file for this session.", ParameterSetName = DEFAULT)]
        public SwitchParameter Profile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the config file preference for this session.", ParameterSetName = DEFAULT)]
        public SwitchParameter Config { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the authentication type preference for this session and defaults to API Key authentication.", ParameterSetName = DEFAULT)]
        public SwitchParameter AuthType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the max timeout preference for OCI Cmdlets in this session.", ParameterSetName = DEFAULT)]
        public SwitchParameter TimeOutInMillis { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears the Noretry logic preference for this session.", ParameterSetName = DEFAULT)]
        public SwitchParameter NoRetry { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Clears all session preferences.", ParameterSetName = ALL)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName.Equals(ALL))
            {
                //clear all session preferences.
                OCIClientSession.Instance.RegionId = null;
                OCIClientSession.Instance.Profile = null;
                OCIClientSession.Instance.Config = null;
                OCIClientSession.Instance.AuthType = null;
                OCIClientSession.Instance.TimeOutInMillis = null;
                OCIClientSession.Instance.NoRetry = null;
            }
            else
            {
                if (RegionId.IsPresent)
                {
                    OCIClientSession.Instance.RegionId = null;
                }
                if (Profile.IsPresent)
                {
                    OCIClientSession.Instance.Profile = null;
                }
                if (Config.IsPresent)
                {
                    OCIClientSession.Instance.Config = null;
                }
                if (AuthType.IsPresent)
                {
                    OCIClientSession.Instance.AuthType = null;
                }
                if (TimeOutInMillis.IsPresent)
                {
                    OCIClientSession.Instance.TimeOutInMillis = null;
                }
                if (NoRetry.IsPresent)
                {
                    OCIClientSession.Instance.NoRetry = null;
                }
            }
        }

        private const string ALL = "All";
        private const string DEFAULT = "Default";
    }
}