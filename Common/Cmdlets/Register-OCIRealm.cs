/**
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Management.Automation;
using Oci.Common;

/// <summary>
/// Registers a new OCI Realm that is currently not supported.
/// </summary>
namespace Oci.PSModules.Common.Cmdlets
{
    [Cmdlet("Register", "OCIRealm")]
    [OutputType(typeof(Realm))]
    public class RegisterOCIRealm : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Realm Identifier of the new realm.")]
        public String RealmId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The second level domain of the realm.")]
        public string SecondLevelDomain { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(Realm.Register(RealmId, SecondLevelDomain));
        }
    }
}