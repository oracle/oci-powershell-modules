/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220126
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LockboxService.Requests;
using Oci.LockboxService.Responses;
using Oci.LockboxService.Models;
using Oci.Common.Model;

namespace Oci.LockboxService.Cmdlets
{
    [Cmdlet("Get", "OCILockboxAccessMaterials")]
    [OutputType(new System.Type[] { typeof(Oci.LockboxService.Models.AccessMaterials), typeof(Oci.LockboxService.Responses.GetAccessMaterialsResponse) })]
    public class GetOCILockboxAccessMaterials : OCILockboxCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier (OCID) of the access request.")]
        public string AccessRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAccessMaterialsRequest request;

            try
            {
                request = new GetAccessMaterialsRequest
                {
                    AccessRequestId = AccessRequestId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAccessMaterials(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AccessMaterials);
                FinishProcessing(response);
            }
            catch (OciException ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            TerminatingErrorDuringExecution(new OperationCanceledException("Cmdlet execution interrupted"));
        }

        private GetAccessMaterialsResponse response;
    }
}
