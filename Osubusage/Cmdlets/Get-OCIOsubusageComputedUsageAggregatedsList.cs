/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OsubusageService.Requests;
using Oci.OsubusageService.Responses;
using Oci.OsubusageService.Models;
using Oci.Common.Model;

namespace Oci.OsubusageService.Cmdlets
{
    [Cmdlet("Get", "OCIOsubusageComputedUsageAggregatedsList")]
    [OutputType(new System.Type[] { typeof(Oci.OsubusageService.Models.ComputedUsageAggregatedSummary), typeof(Oci.OsubusageService.Responses.ListComputedUsageAggregatedsResponse) })]
    public class GetOCIOsubusageComputedUsageAggregatedsList : OCIComputedUsageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the root compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Subscription Id is an identifier associated to the service used for filter the Computed Usage in SPM.")]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Initial date to filter Computed Usage data in SPM. In the case of non aggregated data the time period between of fromDate and toDate , expressed in RFC 3339 timestamp format.")]
        public System.Nullable<System.DateTime> TimeFrom { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Final date to filter Computed Usage data in SPM, expressed in RFC 3339 timestamp format.")]
        public System.Nullable<System.DateTime> TimeTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Product part number for subscribed service line, called parent product.")]
        public string ParentProduct { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Grouping criteria to use for aggregate the computed Usage, either hourly (`HOURLY`), daily (`DAILY`), monthly(`MONTHLY`) or none (`NONE`) to not follow a grouping criteria by date.")]
        public System.Nullable<Oci.OsubusageService.Requests.ListComputedUsageAggregatedsRequest.GroupingEnum> Grouping { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number aggregatedComputedUsages of items to return within the Subscription ""List"" call, this counts the overall count across all items Example: `500`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous ""List"" call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCI home region name in case home region is not us-ashburn-1 (IAD), e.g. ap-mumbai-1, us-phoenix-1 etc.")]
        public string XOneOriginRegion { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListComputedUsageAggregatedsRequest request;

            try
            {
                request = new ListComputedUsageAggregatedsRequest
                {
                    CompartmentId = CompartmentId,
                    SubscriptionId = SubscriptionId,
                    TimeFrom = TimeFrom,
                    TimeTo = TimeTo,
                    ParentProduct = ParentProduct,
                    Grouping = Grouping,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    XOneOriginRegion = XOneOriginRegion
                };
                IEnumerable<ListComputedUsageAggregatedsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
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
            IEnumerable<ListComputedUsageAggregatedsResponse> DefaultRequest(ListComputedUsageAggregatedsRequest request) => Enumerable.Repeat(client.ListComputedUsageAggregateds(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListComputedUsageAggregatedsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListComputedUsageAggregatedsResponse response;
        private delegate IEnumerable<ListComputedUsageAggregatedsResponse> RequestDelegate(ListComputedUsageAggregatedsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
