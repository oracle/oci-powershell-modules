/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.AutoscalingService.Requests;
using Oci.AutoscalingService.Responses;
using Oci.AutoscalingService.Models;
using Oci.Common.Model;

namespace Oci.AutoscalingService.Cmdlets
{
    [Cmdlet("Get", "OCIAutoscalingPoliciesList")]
    [OutputType(new System.Type[] { typeof(Oci.AutoscalingService.Models.AutoScalingPolicySummary), typeof(Oci.AutoscalingService.Responses.ListAutoScalingPoliciesResponse) })]
    public class GetOCIAutoscalingPoliciesList : OCIAutoScalingCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the autoscaling configuration.")]
        public string AutoScalingConfigurationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the given display name exactly.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can provide one sort order (`sortOrder`). Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. The DISPLAYNAME sort order is case sensitive.

**Note:** In general, some ""List"" operations (for example, `ListInstances`) let you optionally filter by availability domain if the scope of the resource type is within a single availability domain. If you call one of these ""List"" operations without specifying an availability domain, the resources are grouped by availability domain, then sorted.")]
        public System.Nullable<Oci.AutoscalingService.Requests.ListAutoScalingPoliciesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`). The DISPLAYNAME sort order is case sensitive.")]
        public System.Nullable<Oci.AutoscalingService.Requests.ListAutoScalingPoliciesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListAutoScalingPoliciesRequest request;

            try
            {
                request = new ListAutoScalingPoliciesRequest
                {
                    AutoScalingConfigurationId = AutoScalingConfigurationId,
                    DisplayName = DisplayName,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortBy = SortBy,
                    SortOrder = SortOrder
                };
                IEnumerable<ListAutoScalingPoliciesResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListAutoScalingPoliciesResponse> DefaultRequest(ListAutoScalingPoliciesRequest request) => Enumerable.Repeat(client.ListAutoScalingPolicies(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListAutoScalingPoliciesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListAutoScalingPoliciesResponse response;
        private delegate IEnumerable<ListAutoScalingPoliciesResponse> RequestDelegate(ListAutoScalingPoliciesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
