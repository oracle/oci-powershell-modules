/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20250101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DistributeddatabaseService.Requests;
using Oci.DistributeddatabaseService.Responses;
using Oci.DistributeddatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DistributeddatabaseService.Cmdlets
{
    [Cmdlet("Get", "OCIDistributeddatabasePrivateEndpointsList")]
    [OutputType(new System.Type[] { typeof(Oci.DistributeddatabaseService.Models.DistributedDatabasePrivateEndpointCollection), typeof(Oci.DistributeddatabaseService.Responses.ListDistributedDatabasePrivateEndpointsResponse) })]
    public class GetOCIDistributeddatabasePrivateEndpointsList : OCIDistributedDbPrivateEndpointServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources their lifecycleState matches the given lifecycleState.")]
        public System.Nullable<Oci.DistributeddatabaseService.Models.DistributedDatabasePrivateEndpoint.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.DistributeddatabaseService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending.")]
        public System.Nullable<Oci.DistributeddatabaseService.Requests.ListDistributedDatabasePrivateEndpointsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only private endpoint that match the entire name given. The match is not case sensitive.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDistributedDatabasePrivateEndpointsRequest request;

            try
            {
                request = new ListDistributedDatabasePrivateEndpointsRequest
                {
                    CompartmentId = CompartmentId,
                    LifecycleState = LifecycleState,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    DisplayName = DisplayName
                };
                IEnumerable<ListDistributedDatabasePrivateEndpointsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DistributedDatabasePrivateEndpointCollection, true);
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
            IEnumerable<ListDistributedDatabasePrivateEndpointsResponse> DefaultRequest(ListDistributedDatabasePrivateEndpointsRequest request) => Enumerable.Repeat(client.ListDistributedDatabasePrivateEndpoints(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDistributedDatabasePrivateEndpointsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDistributedDatabasePrivateEndpointsResponse response;
        private delegate IEnumerable<ListDistributedDatabasePrivateEndpointsResponse> RequestDelegate(ListDistributedDatabasePrivateEndpointsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
