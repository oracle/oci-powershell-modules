/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ApmtracesService.Requests;
using Oci.ApmtracesService.Responses;
using Oci.ApmtracesService.Models;
using Oci.Common.Model;

namespace Oci.ApmtracesService.Cmdlets
{
    [Cmdlet("Get", "OCIApmtracesTraceSnapshot")]
    [OutputType(new System.Type[] { typeof(Oci.ApmtracesService.Models.TraceSnapshot), typeof(Oci.ApmtracesService.Responses.GetTraceSnapshotResponse) })]
    public class GetOCIApmtracesTraceSnapshot : OCITraceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM Domain ID for the intended request.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Application Performance Monitoring trace identifier (traceId).")]
        public string TraceKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request.  If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If enabled, only span level details are sent.")]
        public System.Nullable<bool> IsSummarized { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Thread ID for which snapshots need to be retrieved. This identifier of a thread is a long positive number generated when a thread is created.")]
        public string ThreadId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Epoch time of snapshot.")]
        public string SnapshotTime { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetTraceSnapshotRequest request;

            try
            {
                request = new GetTraceSnapshotRequest
                {
                    ApmDomainId = ApmDomainId,
                    TraceKey = TraceKey,
                    OpcRequestId = OpcRequestId,
                    IsSummarized = IsSummarized,
                    ThreadId = ThreadId,
                    SnapshotTime = SnapshotTime
                };

                response = client.GetTraceSnapshot(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TraceSnapshot);
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

        private GetTraceSnapshotResponse response;
    }
}
