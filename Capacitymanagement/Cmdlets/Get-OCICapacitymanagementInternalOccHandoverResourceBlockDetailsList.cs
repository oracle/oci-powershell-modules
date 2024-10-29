/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CapacitymanagementService.Requests;
using Oci.CapacitymanagementService.Responses;
using Oci.CapacitymanagementService.Models;
using Oci.Common.Model;

namespace Oci.CapacitymanagementService.Cmdlets
{
    [Cmdlet("Get", "OCICapacitymanagementInternalOccHandoverResourceBlockDetailsList")]
    [OutputType(new System.Type[] { typeof(Oci.CapacitymanagementService.Models.OccHandoverResourceBlockDetailCollection), typeof(Oci.CapacitymanagementService.Responses.ListInternalOccHandoverResourceBlockDetailsResponse) })]
    public class GetOCICapacitymanagementInternalOccHandoverResourceBlockDetailsList : OCICapacityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the OccHandoverResource which is a required query parameter for listing OccHandoverResourceDetails.")]
        public string OccHandoverResourceBlockId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This fiter is applicable only for COMPUTE namespace. It helps in fetching of all resource block details for which the hostId is equal to the one provided in this query param.")]
        public string HostId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. The default order for handoverDate is chronological order(latest date item at the end).")]
        public System.Nullable<Oci.CapacitymanagementService.Requests.ListInternalOccHandoverResourceBlockDetailsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListInternalOccHandoverResourceBlockDetailsRequest request;

            try
            {
                request = new ListInternalOccHandoverResourceBlockDetailsRequest
                {
                    OccHandoverResourceBlockId = OccHandoverResourceBlockId,
                    HostId = HostId,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListInternalOccHandoverResourceBlockDetailsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.OccHandoverResourceBlockDetailCollection, true);
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
            IEnumerable<ListInternalOccHandoverResourceBlockDetailsResponse> DefaultRequest(ListInternalOccHandoverResourceBlockDetailsRequest request) => Enumerable.Repeat(client.ListInternalOccHandoverResourceBlockDetails(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListInternalOccHandoverResourceBlockDetailsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListInternalOccHandoverResourceBlockDetailsResponse response;
        private delegate IEnumerable<ListInternalOccHandoverResourceBlockDetailsResponse> RequestDelegate(ListInternalOccHandoverResourceBlockDetailsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}