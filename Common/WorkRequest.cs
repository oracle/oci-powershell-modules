/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿namespace Oci.PSModules.Common.Cmdlets
{
    /*Wrapper class for returing work request id, if the cmdlets return type is void and it has work request id in the response header.*/
    public class WorkRequest
    {
        /// <summary>
        /// The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }
    }
}
