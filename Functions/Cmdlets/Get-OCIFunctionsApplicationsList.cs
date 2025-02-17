/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.FunctionsService.Requests;
using Oci.FunctionsService.Responses;
using Oci.FunctionsService.Models;
using Oci.Common.Model;

namespace Oci.FunctionsService.Cmdlets
{
    [Cmdlet("Get", "OCIFunctionsApplicationsList")]
    [OutputType(new System.Type[] { typeof(Oci.FunctionsService.Models.ApplicationSummary), typeof(Oci.FunctionsService.Responses.ListApplicationsResponse) })]
    public class GetOCIFunctionsApplicationsList : OCIFunctionsManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment to which this resource belongs.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return. 1 is the minimum, 50 is the maximum.

Default: 10", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The pagination token for a list query returned by a previous operation")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only applications that match the lifecycle state in this parameter. Example: `Creating`")]
        public System.Nullable<Oci.FunctionsService.Models.Application.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only applications with display names that match the display name string. Matching is exact.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only applications with the specified OCID.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies sort order.

* **ASC:** Ascending sort order. * **DESC:** Descending sort order.")]
        public System.Nullable<Oci.FunctionsService.Requests.ListApplicationsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the attribute with which to sort the rules.

Default: `displayName`

* **timeCreated:** Sorts by timeCreated. * **displayName:** Sorts by displayName. * **id:** Sorts by id.")]
        public System.Nullable<Oci.FunctionsService.Requests.ListApplicationsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListApplicationsRequest request;

            try
            {
                request = new ListApplicationsRequest
                {
                    CompartmentId = CompartmentId,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId,
                    LifecycleState = LifecycleState,
                    DisplayName = DisplayName,
                    Id = Id,
                    SortOrder = SortOrder,
                    SortBy = SortBy
                };
                IEnumerable<ListApplicationsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListApplicationsResponse> DefaultRequest(ListApplicationsRequest request) => Enumerable.Repeat(client.ListApplications(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListApplicationsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListApplicationsResponse response;
        private delegate IEnumerable<ListApplicationsResponse> RequestDelegate(ListApplicationsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
