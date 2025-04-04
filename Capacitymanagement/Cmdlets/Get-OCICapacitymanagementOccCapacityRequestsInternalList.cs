/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20231107
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
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
    [Cmdlet("Get", "OCICapacitymanagementOccCapacityRequestsInternalList")]
    [OutputType(new System.Type[] { typeof(Oci.CapacitymanagementService.Models.OccCapacityRequestCollection), typeof(Oci.CapacitymanagementService.Responses.ListOccCapacityRequestsInternalResponse) })]
    public class GetOCICapacitymanagementOccCapacityRequestsInternalList : OCICapacityManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ocid of the compartment or tenancy in which resources are to be listed. This will also be used for authorization purposes.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The customer group ocid by which we would filter the list.")]
        public string OccCustomerGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return the list of capacity requests based on the OCID of the availability catalog against which they were created.")]
        public string OccAvailabilityCatalogId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The namespace by which we would filter the list.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.Namespace> Namespace { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the resources that match the entire display name. The match is not case sensitive.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the resources that match the request type. The match is not case sensitive.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.OccCapacityRequest.RequestTypeEnum> RequestType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return the list of capacity requests based on the OCID of the capacity request. This is done for the users who have INSPECT permission on the resource but do not have READ permission.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.CapacitymanagementService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. The default order for display name is ascending. The default order for time created is reverse chronological order(latest date at the top).")]
        public System.Nullable<Oci.CapacitymanagementService.Requests.ListOccCapacityRequestsInternalRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListOccCapacityRequestsInternalRequest request;

            try
            {
                request = new ListOccCapacityRequestsInternalRequest
                {
                    CompartmentId = CompartmentId,
                    OccCustomerGroupId = OccCustomerGroupId,
                    OccAvailabilityCatalogId = OccAvailabilityCatalogId,
                    Namespace = Namespace,
                    DisplayName = DisplayName,
                    RequestType = RequestType,
                    Id = Id,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListOccCapacityRequestsInternalResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.OccCapacityRequestCollection, true);
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
            IEnumerable<ListOccCapacityRequestsInternalResponse> DefaultRequest(ListOccCapacityRequestsInternalRequest request) => Enumerable.Repeat(client.ListOccCapacityRequestsInternal(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListOccCapacityRequestsInternalResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListOccCapacityRequestsInternalResponse response;
        private delegate IEnumerable<ListOccCapacityRequestsInternalResponse> RequestDelegate(ListOccCapacityRequestsInternalRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
