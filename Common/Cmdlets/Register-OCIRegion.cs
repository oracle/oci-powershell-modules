/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Registers a new OCI region that is currently not supported.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets
{
    [Cmdlet("Register", "OCIRegion")]
    [OutputType(typeof(Region))]
    public class RegisterOCIRegion : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Region Identifier of the new region.")]
        public String RegionId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Realm key that contains the region.")]
        public Realm Realm { get; set; }

        [Parameter(HelpMessage = "The Region key representing the region.")]
        public string RegionCode { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(Region.Register(RegionId, Realm, RegionCode));
        }
    }
}