/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20240501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DbmulticloudService.Requests;
using Oci.DbmulticloudService.Responses;
using Oci.DbmulticloudService.Models;
using Oci.Common.Model;

namespace Oci.DbmulticloudService.Cmdlets
{
    [Cmdlet("Get", "OCIDbmulticloudMultiCloudResourceDiscoveriesList")]
    [OutputType(new System.Type[] { typeof(Oci.DbmulticloudService.Models.MultiCloudResourceDiscoverySummaryCollection), typeof(Oci.DbmulticloudService.Responses.ListMultiCloudResourceDiscoveriesResponse) })]
    public class GetOCIDbmulticloudMultiCloudResourceDiscoveriesList : OCIMultiCloudResourceDiscoveryCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [ID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Display Name of the Multi Cloud Discovery Resource.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Multi Cloud Discovery Resource.")]
        public string MultiCloudResourceDiscoveryId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the given lifecycle state. The state value is case-insensitive.")]
        public System.Nullable<Oci.DbmulticloudService.Models.MultiCloudResourceDiscovery.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return Oracle DB Azure Blob Mount Resources.")]
        public string OracleDbAzureConnectorId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The type of Multi Cloud Resource.")]
        public System.Nullable<Oci.DbmulticloudService.Models.MultiCloudResourceDiscovery.ResourceTypeEnum> ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DbmulticloudService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified, default is timeCreated.")]
        public System.Nullable<Oci.DbmulticloudService.Requests.ListMultiCloudResourceDiscoveriesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListMultiCloudResourceDiscoveriesRequest request;

            try
            {
                request = new ListMultiCloudResourceDiscoveriesRequest
                {
                    CompartmentId = CompartmentId,
                    DisplayName = DisplayName,
                    MultiCloudResourceDiscoveryId = MultiCloudResourceDiscoveryId,
                    LifecycleState = LifecycleState,
                    OracleDbAzureConnectorId = OracleDbAzureConnectorId,
                    ResourceType = ResourceType,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListMultiCloudResourceDiscoveriesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.MultiCloudResourceDiscoverySummaryCollection, true);
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
            IEnumerable<ListMultiCloudResourceDiscoveriesResponse> DefaultRequest(ListMultiCloudResourceDiscoveriesRequest request) => Enumerable.Repeat(client.ListMultiCloudResourceDiscoveries(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListMultiCloudResourceDiscoveriesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListMultiCloudResourceDiscoveriesResponse response;
        private delegate IEnumerable<ListMultiCloudResourceDiscoveriesResponse> RequestDelegate(ListMultiCloudResourceDiscoveriesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
