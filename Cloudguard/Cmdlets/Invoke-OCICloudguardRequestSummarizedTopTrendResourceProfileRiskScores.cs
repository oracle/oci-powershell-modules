/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200131
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CloudguardService.Requests;
using Oci.CloudguardService.Responses;
using Oci.CloudguardService.Models;

namespace Oci.CloudguardService.Cmdlets
{
    [Cmdlet("Invoke", "OCICloudguardRequestSummarizedTopTrendResourceProfileRiskScores")]
    [OutputType(new System.Type[] { typeof(Oci.CloudguardService.Models.ResourceProfileRiskScoreAggregationSummaryCollection), typeof(Oci.CloudguardService.Responses.RequestSummarizedTopTrendResourceProfileRiskScoresResponse) })]
    public class InvokeOCICloudguardRequestSummarizedTopTrendResourceProfileRiskScores : OCICloudGuardCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Start time for a filter. If start time is not specified, start time will be set to today's current time - 30 days.")]
        public System.Nullable<System.DateTime> TimeScoreComputedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"End time for a filter. If end time is not specified, end time will be set to today's current time.")]
        public System.Nullable<System.DateTime> TimeScoreComputedLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Default is false. When set to true, the hierarchy of compartments is traversed and all compartments and subcompartments in the tenancy are returned depending on the the setting of `accessLevel`.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort trendlines for resource profiles. Only one sort order may be provided. If no value is specified riskScore is default.")]
        public System.Nullable<Oci.CloudguardService.Requests.RequestSummarizedTopTrendResourceProfileRiskScoresRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Number of resource profile risk score trend-lines to be displayed. Default value is 10.")]
        public System.Nullable<int> Count { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Valid values are `RESTRICTED` and `ACCESSIBLE`. Default is `RESTRICTED`. Setting this to `ACCESSIBLE` returns only those compartments for which the user has INSPECT permissions directly or indirectly (permissions can be on a resource in a subcompartment). When set to `RESTRICTED` permissions are checked and no partial results are displayed.")]
        public System.Nullable<Oci.CloudguardService.Requests.RequestSummarizedTopTrendResourceProfileRiskScoresRequest.AccessLevelEnum> AccessLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RequestSummarizedTopTrendResourceProfileRiskScoresRequest request;

            try
            {
                request = new RequestSummarizedTopTrendResourceProfileRiskScoresRequest
                {
                    CompartmentId = CompartmentId,
                    TimeScoreComputedGreaterThanOrEqualTo = TimeScoreComputedGreaterThanOrEqualTo,
                    TimeScoreComputedLessThanOrEqualTo = TimeScoreComputedLessThanOrEqualTo,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    SortBy = SortBy,
                    Count = Count,
                    AccessLevel = AccessLevel,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };

                response = client.RequestSummarizedTopTrendResourceProfileRiskScores(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ResourceProfileRiskScoreAggregationSummaryCollection);
                FinishProcessing(response);
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

        private RequestSummarizedTopTrendResourceProfileRiskScoresResponse response;
    }
}