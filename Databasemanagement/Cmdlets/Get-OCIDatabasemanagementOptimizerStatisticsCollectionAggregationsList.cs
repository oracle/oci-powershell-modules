/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemanagementOptimizerStatisticsCollectionAggregationsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.OptimizerStatisticsCollectionAggregationsCollection), typeof(Oci.DatabasemanagementService.Responses.ListOptimizerStatisticsCollectionAggregationsResponse) })]
    public class GetOCIDatabasemanagementOptimizerStatisticsCollectionAggregationsList : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optimizer statistics tasks grouped by type.")]
        public System.Nullable<Oci.DatabasemanagementService.Models.OptimizerStatisticsGroupByTypes> GroupType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The start time of the time range to retrieve the optimizer statistics of a Managed Database in UTC in ISO-8601 format, which is ""yyyy-MM-dd'T'hh:mm:ss.sss'Z'"".")]
        public string StartTimeGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The end time of the time range to retrieve the optimizer statistics of a Managed Database in UTC in ISO-8601 format, which is ""yyyy-MM-dd'T'hh:mm:ss.sss'Z'"".")]
        public string EndTimeLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The filter types of the optimizer statistics tasks.")]
        public System.Nullable<Oci.DatabasemanagementService.Models.OptimizerStatisticsTaskFilterTypes> TaskType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of records returned in the paginated response.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page from where the next set of paginated results are retrieved. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListOptimizerStatisticsCollectionAggregationsRequest request;

            try
            {
                request = new ListOptimizerStatisticsCollectionAggregationsRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    GroupType = GroupType,
                    StartTimeGreaterThanOrEqualTo = StartTimeGreaterThanOrEqualTo,
                    EndTimeLessThanOrEqualTo = EndTimeLessThanOrEqualTo,
                    TaskType = TaskType,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page
                };
                IEnumerable<ListOptimizerStatisticsCollectionAggregationsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.OptimizerStatisticsCollectionAggregationsCollection, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && !ParameterSetName.Equals(LimitSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources.");
                }
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

        private RequestDelegate GetRequestDelegate()
        {
            IEnumerable<ListOptimizerStatisticsCollectionAggregationsResponse> DefaultRequest(ListOptimizerStatisticsCollectionAggregationsRequest request) => Enumerable.Repeat(client.ListOptimizerStatisticsCollectionAggregations(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListOptimizerStatisticsCollectionAggregationsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListOptimizerStatisticsCollectionAggregationsResponse response;
        private delegate IEnumerable<ListOptimizerStatisticsCollectionAggregationsResponse> RequestDelegate(ListOptimizerStatisticsCollectionAggregationsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}