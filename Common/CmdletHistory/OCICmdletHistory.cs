/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.Management.Automation;

namespace Oci.PSModules.Common.Cmdlets.CmdletHistory
{
    /// <summary>
    /// OCICmdletHistory class helps bundle Cmdlet invocation and the RestAPI responses received.
    /// This object is stored by the OCICmdlet history store. 
    /// </summary>
    public class OCICmdletHistory
    {
        /// <summary>
        /// Cmdlet invocation start time. Cannot be modified outside this class to preserve the Cmdlet history order in the History store.
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// Cmdlet invocation end time. Cannot be modified outside this class to preserve the Cmdlet history order in the History store.
        /// </summary>
        public DateTime EndTime { get; }

        public InvocationInfo Command { get; set; }

        public PSObject Response { get; set; }

        public OCICmdletHistory(DateTime start, DateTime end)
        {
            StartTime = start;
            EndTime = end;
        }
    }
}