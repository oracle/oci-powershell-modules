/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210331
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.BastionService.Requests;
using Oci.BastionService.Responses;
using Oci.BastionService.Models;
using Oci.Common.Model;

namespace Oci.BastionService.Cmdlets
{
    [Cmdlet("Update", "OCIBastionSession")]
    [OutputType(new System.Type[] { typeof(Oci.BastionService.Models.Session), typeof(Oci.BastionService.Responses.UpdateSessionResponse) })]
    public class UpdateOCIBastionSession : OCIBastionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier (OCID) of the session.")]
        public string SessionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The session information to be updated.")]
        public UpdateSessionDetails UpdateSessionDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateSessionRequest request;

            try
            {
                request = new UpdateSessionRequest
                {
                    SessionId = SessionId,
                    UpdateSessionDetails = UpdateSessionDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateSession(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Session);
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

        private UpdateSessionResponse response;
    }
}
