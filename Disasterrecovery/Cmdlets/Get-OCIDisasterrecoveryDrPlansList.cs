/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220125
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DisasterrecoveryService.Requests;
using Oci.DisasterrecoveryService.Responses;
using Oci.DisasterrecoveryService.Models;
using Oci.Common.Model;

namespace Oci.DisasterrecoveryService.Cmdlets
{
    [Cmdlet("Get", "OCIDisasterrecoveryDrPlansList")]
    [OutputType(new System.Type[] { typeof(Oci.DisasterrecoveryService.Models.DrPlanCollection), typeof(Oci.DisasterrecoveryService.Responses.ListDrPlansResponse) })]
    public class GetOCIDisasterrecoveryDrPlansList : OCIDisasterRecoveryCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the DR protection group. Mandatory query param.

Example: `ocid1.drprotectiongroup.oc1..uniqueID`")]
        public string DrProtectionGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only DR plans that match the given lifecycle state.")]
        public System.Nullable<Oci.DisasterrecoveryService.Models.DrPlanLifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the DR plan.

Example: `ocid1.drplan.oc1..uniqueID`")]
        public string DrPlanId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The DR plan type.")]
        public System.Nullable<Oci.DisasterrecoveryService.Models.DrPlanType> DrPlanType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the given display name.

Example: `MyResourceDisplayName`")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. 1 is the minimum, 1000 is the maximum.

For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `100`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call.

For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DisasterrecoveryService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending. If no value is specified timeCreated is default.

Example: `MyResourceDisplayName`")]
        public System.Nullable<Oci.DisasterrecoveryService.Requests.ListDrPlansRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only DR plans that match the given lifecycle sub-state.")]
        public System.Nullable<Oci.DisasterrecoveryService.Models.DrPlanLifecycleSubState> LifecycleSubState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDrPlansRequest request;

            try
            {
                request = new ListDrPlansRequest
                {
                    DrProtectionGroupId = DrProtectionGroupId,
                    LifecycleState = LifecycleState,
                    DrPlanId = DrPlanId,
                    DrPlanType = DrPlanType,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    LifecycleSubState = LifecycleSubState
                };
                IEnumerable<ListDrPlansResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DrPlanCollection, true);
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
            IEnumerable<ListDrPlansResponse> DefaultRequest(ListDrPlansRequest request) => Enumerable.Repeat(client.ListDrPlans(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDrPlansResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDrPlansResponse response;
        private delegate IEnumerable<ListDrPlansResponse> RequestDelegate(ListDrPlansRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
