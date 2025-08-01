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
    [Cmdlet("New", "OCIApmtracesScheduledQuery")]
    [OutputType(new System.Type[] { typeof(Oci.ApmtracesService.Models.ScheduledQuery), typeof(Oci.ApmtracesService.Responses.CreateScheduledQueryResponse) })]
    public class NewOCIApmtracesScheduledQuery : OCIScheduledQueryCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The APM Domain ID for the intended request.")]
        public string ApmDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request body containing the details about the scheduled query to be created.")]
        public CreateScheduledQueryDetails CreateScheduledQueryDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request.  If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates that the request is a dry run, if set to ""true"". A dry run request does not create or modify the resource and is used only to perform validation on the submitted data.")]
        public string OpcDryRun { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateScheduledQueryRequest request;

            try
            {
                request = new CreateScheduledQueryRequest
                {
                    ApmDomainId = ApmDomainId,
                    CreateScheduledQueryDetails = CreateScheduledQueryDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken,
                    OpcDryRun = OpcDryRun
                };

                response = client.CreateScheduledQuery(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ScheduledQuery);
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

        private CreateScheduledQueryResponse response;
    }
}
