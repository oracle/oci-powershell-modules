/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231130
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.GenerativeaiService.Requests;
using Oci.GenerativeaiService.Responses;
using Oci.GenerativeaiService.Models;
using Oci.Common.Model;

namespace Oci.GenerativeaiService.Cmdlets
{
    [Cmdlet("Update", "OCIGenerativeaiModel")]
    [OutputType(new System.Type[] { typeof(Oci.GenerativeaiService.Models.Model), typeof(Oci.GenerativeaiService.Responses.UpdateModelResponse) })]
    public class UpdateOCIGenerativeaiModel : OCIGenerativeAiCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The model OCID")]
        public string ModelId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The model information to be updated.")]
        public UpdateModelDetails UpdateModelDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateModelRequest request;

            try
            {
                request = new UpdateModelRequest
                {
                    ModelId = ModelId,
                    UpdateModelDetails = UpdateModelDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateModel(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Model);
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

        private UpdateModelResponse response;
    }
}
