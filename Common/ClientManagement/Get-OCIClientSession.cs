/**
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System.Management.Automation;

/// <summary>
/// Gets the stored region/config/profile preference for this session.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    [Cmdlet("Get", "OCIClientSession")]
    [OutputType(typeof(Oci.PSModules.Common.Cmdlets.ClientManagement.OCIClientSession))]
    public class GetOCIClientSession : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(OCIClientSession.Instance);
        }
    }
}