/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.VnmonitoringService.Requests;
using Oci.VnmonitoringService.Responses;
using Oci.VnmonitoringService.Models;
using Oci.Common.Model;

namespace Oci.VnmonitoringService.Cmdlets
{
    [Cmdlet("Move", "OCIVnmonitoringPathAnalyzerTestCompartment")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.VnmonitoringService.Responses.ChangePathAnalyzerTestCompartmentResponse) })]
    public class MoveOCIVnmonitoringPathAnalyzerTestCompartment : OCIVnMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the `PathAnalyzerTest` resource.")]
        public string PathAnalyzerTestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to update.")]
        public ChangePathAnalyzerTestCompartmentDetails ChangePathAnalyzerTestCompartmentDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ChangePathAnalyzerTestCompartmentRequest request;

            try
            {
                request = new ChangePathAnalyzerTestCompartmentRequest
                {
                    PathAnalyzerTestId = PathAnalyzerTestId,
                    ChangePathAnalyzerTestCompartmentDetails = ChangePathAnalyzerTestCompartmentDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.ChangePathAnalyzerTestCompartment(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private ChangePathAnalyzerTestCompartmentResponse response;
    }
}
