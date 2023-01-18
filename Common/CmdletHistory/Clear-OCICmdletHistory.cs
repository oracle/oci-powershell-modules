/**
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System.Management.Automation;

/// <summary>
/// Clears the cmdlet history stored in $OCICmdletHistory Session Variable
/// </summary>
namespace Oci.PSModules.Common.Cmdlets.CmdletHistory
{
    [Cmdlet("Clear", "OCICmdletHistory")]
    [OutputType(typeof(void))]
    public class ClearOCICmdletHistory : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            OCICmdletHistoryStore.Instance.ClearHistory();
        }
    }
}