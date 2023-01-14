/**
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Gets the OCI region corresponding to the region code or Id.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets
{
    [Cmdlet("Get", "OCIRegion")]
    [OutputType(typeof(Region))]
    public class GetOCIRegion : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Region Identifier of the new region. eg) us-phoenix-1", ParameterSetName = REGION_ID)]
        public String RegionId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Region key representing the region. eg) phx ", ParameterSetName = REGION_CODE)]
        public string RegionCode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enabling the Instance Metadata Service allows region lookups through the OCI Instance's metadata.")]
        public SwitchParameter EnableInstanceMetadataService { get; set; }

        protected override void ProcessRecord()
        {
            if(EnableInstanceMetadataService) {
                Region.EnableInstanceMetadataService();
            }
            string regionInfo = RegionId ?? RegionCode;
            WriteObject(Region.FromRegionCodeOrId(regionInfo));
        }

        private const string REGION_ID = "RegionId";
        private const string REGION_CODE = "RegionCode";
    }
}