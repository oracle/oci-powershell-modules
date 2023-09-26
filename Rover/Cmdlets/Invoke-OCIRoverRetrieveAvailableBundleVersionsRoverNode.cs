/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201210
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.RoverService.Requests;
using Oci.RoverService.Responses;
using Oci.RoverService.Models;
using Oci.Common.Model;

namespace Oci.RoverService.Cmdlets
{
    [Cmdlet("Invoke", "OCIRoverRetrieveAvailableBundleVersionsRoverNode")]
    [OutputType(new System.Type[] { typeof(Oci.RoverService.Models.RoverBundleVersion), typeof(Oci.RoverService.Responses.RetrieveAvailableBundleVersionsRoverNodeResponse) })]
    public class InvokeOCIRoverRetrieveAvailableBundleVersionsRoverNode : OCIRoverBundleCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Provide the current rover bundle details.")]
        public CurrentRoverBundleDetails CurrentRoverBundleDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique RoverNode identifier")]
        public string RoverNodeId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RetrieveAvailableBundleVersionsRoverNodeRequest request;

            try
            {
                request = new RetrieveAvailableBundleVersionsRoverNodeRequest
                {
                    CurrentRoverBundleDetails = CurrentRoverBundleDetails,
                    RoverNodeId = RoverNodeId,
                    OpcRequestId = OpcRequestId
                };

                response = client.RetrieveAvailableBundleVersionsRoverNode(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RoverBundleVersion);
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

        private RetrieveAvailableBundleVersionsRoverNodeResponse response;
    }
}