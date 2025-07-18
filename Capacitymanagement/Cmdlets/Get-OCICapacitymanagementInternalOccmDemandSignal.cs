/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CapacitymanagementService.Requests;
using Oci.CapacitymanagementService.Responses;
using Oci.CapacitymanagementService.Models;
using Oci.Common.Model;

namespace Oci.CapacitymanagementService.Cmdlets
{
    [Cmdlet("Get", "OCICapacitymanagementInternalOccmDemandSignal")]
    [OutputType(new System.Type[] { typeof(Oci.CapacitymanagementService.Models.InternalOccmDemandSignal), typeof(Oci.CapacitymanagementService.Responses.GetInternalOccmDemandSignalResponse) })]
    public class GetOCICapacitymanagementInternalOccmDemandSignal : OCIInternalDemandSignalCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the demand signal.")]
        public string OccmDemandSignalId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetInternalOccmDemandSignalRequest request;

            try
            {
                request = new GetInternalOccmDemandSignalRequest
                {
                    OccmDemandSignalId = OccmDemandSignalId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetInternalOccmDemandSignal(request).GetAwaiter().GetResult();
                WriteOutput(response, response.InternalOccmDemandSignal);
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

        private GetInternalOccmDemandSignalResponse response;
    }
}
