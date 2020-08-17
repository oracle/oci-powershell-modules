/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System.Management.Automation;

/// <summary>
/// Sets the size of the history stored in $OCICmdletHistory session variable
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.CmdletHistory
{
    [Cmdlet("Set", "OCICmdletHistory")]
    [OutputType(typeof(int))]
    public class SetOCICmdletHistory : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Size of the history store")]
        [ValidateRange(OCICmdletHistoryStore.MIN_SIZE, OCICmdletHistoryStore.MAX_SIZE)]
        public int Size { get; set; }

        protected override void ProcessRecord()
        {
            OCICmdletHistoryStore.Instance.ChangeSize(Size);
            WriteObject(OCICmdletHistoryStore.Instance.Size);
        }
    }
}