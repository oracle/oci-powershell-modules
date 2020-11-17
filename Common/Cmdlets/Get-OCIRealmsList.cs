/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Gets the list of OCI realms currently supported in this version.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets
{
    [Cmdlet("Get", "OCIRealmsList")]
    [OutputType(typeof(Realm[]))]
    public class GetOCIRealmsList : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Realm.Values());
        }
    }
}