/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200407
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.GoldengateService.Requests;
using Oci.GoldengateService.Responses;
using Oci.GoldengateService.Models;
using Oci.Common.Model;

namespace Oci.GoldengateService.Cmdlets
{
    [Cmdlet("Get", "OCIGoldengateConnectionsList")]
    [OutputType(new System.Type[] { typeof(Oci.GoldengateService.Models.ConnectionCollection), typeof(Oci.GoldengateService.Responses.ListConnectionsResponse) })]
    public class GetOCIGoldengateConnectionsList : OCIGoldenGateCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment that contains the work request. Work requests should be scoped to the same compartment as the resource the work request affects. If the work request concerns multiple resources, and those resources are not in the same compartment, it is up to the service team to pick the primary resource whose compartment should be used.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The array of technology types.")]
        public System.Collections.Generic.List<Oci.GoldengateService.Models.TechnologyType> TechnologyType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The array of connection types.")]
        public System.Collections.Generic.List<Oci.GoldengateService.Models.ConnectionType> ConnectionType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the deployment which for the connection must be assigned.")]
        public string AssignedDeploymentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filters for compatible connections which can be, but currently not assigned to the deployment specified by its id.")]
        public string AssignableDeploymentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filters for connections which can be assigned to the latest version of the specified deployment type.")]
        public System.Nullable<Oci.GoldengateService.Models.DeploymentType> AssignableDeploymentType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only connections having the 'lifecycleState' given.")]
        public System.Nullable<Oci.GoldengateService.Models.Connection.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only the resources that match the entire 'displayName' given.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.GoldengateService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order can be provided. Default order for 'timeCreated' is descending.  Default order for 'displayName' is ascending. If no value is specified timeCreated is the default.")]
        public System.Nullable<Oci.GoldengateService.Requests.ListConnectionsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListConnectionsRequest request;

            try
            {
                request = new ListConnectionsRequest
                {
                    CompartmentId = CompartmentId,
                    TechnologyType = TechnologyType,
                    ConnectionType = ConnectionType,
                    AssignedDeploymentId = AssignedDeploymentId,
                    AssignableDeploymentId = AssignableDeploymentId,
                    AssignableDeploymentType = AssignableDeploymentType,
                    LifecycleState = LifecycleState,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListConnectionsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ConnectionCollection, true);
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
            IEnumerable<ListConnectionsResponse> DefaultRequest(ListConnectionsRequest request) => Enumerable.Repeat(client.ListConnections(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListConnectionsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListConnectionsResponse response;
        private delegate IEnumerable<ListConnectionsResponse> RequestDelegate(ListConnectionsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
