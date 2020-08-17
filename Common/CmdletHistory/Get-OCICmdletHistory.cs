/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Management.Automation;

/// <summary>
/// Gets the cmdlet history and its attributes stored in $OCICmdletHistory Session Variable
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.CmdletHistory
{
    [Cmdlet("Get", "OCICmdletHistory")]
    [OutputType(typeof(Oci.PSModules.Common.Cmdlets.CmdletHistory.OCICmdletHistory))]
    [OutputType(typeof(int), ParameterSetName = new String[] { SIZESET })]
    public class GetOCICmdletHistory : PSCmdlet
    {
        [Parameter(HelpMessage = "Size of the history store", ParameterSetName = SIZESET)]
        public SwitchParameter Size { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName.Equals(SIZESET, StringComparison.OrdinalIgnoreCase))
            {
                WriteObject(OCICmdletHistoryStore.Instance.Size);
            }
            else
            {
                WriteObject(OCICmdletHistoryStore.Instance.Entries);
            }
        }
        private const string SIZESET = "Size";
    }
}