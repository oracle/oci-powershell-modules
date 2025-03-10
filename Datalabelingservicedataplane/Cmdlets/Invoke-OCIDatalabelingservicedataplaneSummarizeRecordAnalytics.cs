/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20211001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatalabelingservicedataplaneService.Requests;
using Oci.DatalabelingservicedataplaneService.Responses;
using Oci.DatalabelingservicedataplaneService.Models;
using Oci.Common.Model;

namespace Oci.DatalabelingservicedataplaneService.Cmdlets
{
    [Cmdlet("Invoke", "OCIDatalabelingservicedataplaneSummarizeRecordAnalytics")]
    [OutputType(new System.Type[] { typeof(Oci.DatalabelingservicedataplaneService.Models.RecordAnalyticsAggregationCollection), typeof(Oci.DatalabelingservicedataplaneService.Responses.SummarizeRecordAnalyticsResponse) })]
    public class InvokeOCIDatalabelingservicedataplaneSummarizeRecordAnalytics : OCIDataLabelingCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter the results by the OCID of the dataset.")]
        public string DatasetId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources whose lifecycleState matches the given lifecycleState.")]
        public System.Nullable<Oci.DatalabelingservicedataplaneService.Models.Record.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatalabelingservicedataplaneService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to group by. If no value is specified isLabeled is used by default.")]
        public System.Nullable<Oci.DatalabelingservicedataplaneService.Requests.SummarizeRecordAnalyticsRequest.RecordGroupByEnum> RecordGroupBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. The default order is descending. If no value is specified, count is used by default.")]
        public System.Nullable<Oci.DatalabelingservicedataplaneService.Requests.SummarizeRecordAnalyticsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeRecordAnalyticsRequest request;

            try
            {
                request = new SummarizeRecordAnalyticsRequest
                {
                    CompartmentId = CompartmentId,
                    DatasetId = DatasetId,
                    LifecycleState = LifecycleState,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    RecordGroupBy = RecordGroupBy,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeRecordAnalytics(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RecordAnalyticsAggregationCollection);
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

        private SummarizeRecordAnalyticsResponse response;
    }
}
