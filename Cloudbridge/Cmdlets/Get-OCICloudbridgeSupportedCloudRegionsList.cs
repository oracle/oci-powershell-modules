/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220509
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CloudbridgeService.Requests;
using Oci.CloudbridgeService.Responses;
using Oci.CloudbridgeService.Models;
using Oci.Common.Model;

namespace Oci.CloudbridgeService.Cmdlets
{
    [Cmdlet("Get", "OCICloudbridgeSupportedCloudRegionsList")]
    [OutputType(new System.Type[] { typeof(Oci.CloudbridgeService.Models.SupportedCloudRegionCollection), typeof(Oci.CloudbridgeService.Responses.ListSupportedCloudRegionsResponse) })]
    public class GetOCICloudbridgeSupportedCloudRegionsList : OCIDiscoveryCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The asset source type.")]
        public System.Nullable<Oci.CloudbridgeService.Models.AssetSourceType> AssetSourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only supported cloud regions which name contains given nameContains as sub-string.")]
        public string NameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. By default, name is in ascending order.")]
        public System.Nullable<Oci.CloudbridgeService.Requests.ListSupportedCloudRegionsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.CloudbridgeService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListSupportedCloudRegionsRequest request;

            try
            {
                request = new ListSupportedCloudRegionsRequest
                {
                    AssetSourceType = AssetSourceType,
                    NameContains = NameContains,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListSupportedCloudRegionsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.SupportedCloudRegionCollection, true);
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
            IEnumerable<ListSupportedCloudRegionsResponse> DefaultRequest(ListSupportedCloudRegionsRequest request) => Enumerable.Repeat(client.ListSupportedCloudRegions(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListSupportedCloudRegionsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListSupportedCloudRegionsResponse response;
        private delegate IEnumerable<ListSupportedCloudRegionsResponse> RequestDelegate(ListSupportedCloudRegionsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
