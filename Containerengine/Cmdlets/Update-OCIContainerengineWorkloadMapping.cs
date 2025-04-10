/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180222
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ContainerengineService.Requests;
using Oci.ContainerengineService.Responses;
using Oci.ContainerengineService.Models;
using Oci.Common.Model;

namespace Oci.ContainerengineService.Cmdlets
{
    [Cmdlet("Update", "OCIContainerengineWorkloadMapping")]
    [OutputType(new System.Type[] { typeof(Oci.ContainerengineService.Models.WorkloadMapping), typeof(Oci.ContainerengineService.Responses.UpdateWorkloadMappingResponse) })]
    public class UpdateOCIContainerengineWorkloadMapping : OCIContainerEngineCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the cluster.")]
        public string ClusterId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the workloadMapping.")]
        public string WorkloadMappingId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the workloadMapping to be updated.")]
        public UpdateWorkloadMappingDetails UpdateWorkloadMappingDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource.  The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateWorkloadMappingRequest request;

            try
            {
                request = new UpdateWorkloadMappingRequest
                {
                    ClusterId = ClusterId,
                    WorkloadMappingId = WorkloadMappingId,
                    UpdateWorkloadMappingDetails = UpdateWorkloadMappingDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateWorkloadMapping(request).GetAwaiter().GetResult();
                WriteOutput(response, response.WorkloadMapping);
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

        private UpdateWorkloadMappingResponse response;
    }
}
