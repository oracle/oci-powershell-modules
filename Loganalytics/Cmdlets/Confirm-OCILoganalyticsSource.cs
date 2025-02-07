/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoganalyticsService.Requests;
using Oci.LoganalyticsService.Responses;
using Oci.LoganalyticsService.Models;
using Oci.Common.Model;

namespace Oci.LoganalyticsService.Cmdlets
{
    [Cmdlet("Confirm", "OCILoganalyticsSource")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.SourceValidateResults), typeof(Oci.LoganalyticsService.Responses.ValidateSourceResponse) })]
    public class ConfirmOCILoganalyticsSource : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Logging Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the new LoganSourceDetails.")]
        public UpsertLogAnalyticsSourceDetails UpsertLogAnalyticsSourceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier of the source to use as the reference for a create like operation.")]
        public System.Nullable<int> CreateLikeSourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A flag indicating whether or not the update of a source is incremental or not.  If incremental, the name of the source must be specified.")]
        public System.Nullable<bool> IsIncremental { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"is ignore warning")]
        public System.Nullable<bool> IsIgnoreWarning { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ValidateSourceRequest request;

            try
            {
                request = new ValidateSourceRequest
                {
                    NamespaceName = NamespaceName,
                    UpsertLogAnalyticsSourceDetails = UpsertLogAnalyticsSourceDetails,
                    CreateLikeSourceId = CreateLikeSourceId,
                    IsIncremental = IsIncremental,
                    IsIgnoreWarning = IsIgnoreWarning,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.ValidateSource(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SourceValidateResults);
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

        private ValidateSourceResponse response;
    }
}
