/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Sets the OCI cmdlet parameters preference for this session.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    [Cmdlet("Set", "OCIClientSession")]
    [OutputType(typeof(Oci.PSModules.Common.Cmdlets.ClientManagement.OCIClientSession))]
    public class SetOCIClientSession : PSCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The region to make calls against for this session.")]
        public string RegionId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The profile in the config file to load for this session.")]
        public string Profile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the config file to be used for this session.")]
        public string Config { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Type of authentication to use for making API requests in this session.")]
        public AuthenticationType AuthType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Max wait time in milliseconds for the API request to complete in this session. Default is 100000 millis(100 secs).")]
        [ValidateRange(1, int.MaxValue)]
        public int TimeOutInMillis { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Disable retry logic for calls to services in this session.")]
        public SwitchParameter NoRetry { get; set; }

        protected override void ProcessRecord()
        {
            if (null != RegionId)
            {
                //To Validate Region Id
                if (String.Empty != RegionId)
                {
                    Region.FromRegionId(RegionId);
                }
                OCIClientSession.Instance.RegionId = RegionId;
            }
            if (null != Profile)
            {
                OCIClientSession.Instance.Profile = Profile;
            }
            if (null != Config)
            {
                OCIClientSession.Instance.Config = Config;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AuthType"))
            {
                OCIClientSession.Instance.AuthType = AuthType;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeOutInMillis"))
            {
                OCIClientSession.Instance.TimeOutInMillis = TimeOutInMillis;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoRetry"))
            {
                OCIClientSession.Instance.NoRetry = NoRetry;
            }
            WriteObject(OCIClientSession.Instance);
        }
    }
}