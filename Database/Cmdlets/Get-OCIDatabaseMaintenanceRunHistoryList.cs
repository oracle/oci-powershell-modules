/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatabaseService.Requests;
using Oci.DatabaseService.Responses;
using Oci.DatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DatabaseService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabaseMaintenanceRunHistoryList")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.MaintenanceRunHistorySummary), typeof(Oci.DatabaseService.Responses.ListMaintenanceRunHistoryResponse) })]
    public class GetOCIDatabaseMaintenanceRunHistoryList : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The compartment [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The target resource ID.")]
        public string TargetResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The type of the target resource.")]
        public System.Nullable<Oci.DatabaseService.Models.MaintenanceRunSummary.TargetResourceTypeEnum> TargetResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maintenance type.")]
        public System.Nullable<Oci.DatabaseService.Models.MaintenanceRunSummary.MaintenanceTypeEnum> MaintenanceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return per page.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The pagination token to continue listing from.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by.  You can provide one sort order (`sortOrder`).  Default order for TIME_SCHEDULED and TIME_ENDED is descending. Default order for DISPLAYNAME is ascending. The DISPLAYNAME sort order is case sensitive.

**Note:** If you do not include the availability domain filter, the resources are grouped by availability domain, then sorted.")]
        public System.Nullable<Oci.DatabaseService.Requests.ListMaintenanceRunHistoryRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.DatabaseService.Requests.ListMaintenanceRunHistoryRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The state of the maintenance run history.")]
        public System.Nullable<Oci.DatabaseService.Models.MaintenanceRunSummary.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the given availability domain exactly.")]
        public string AvailabilityDomain { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sub-type of the maintenance run.")]
        public System.Nullable<Oci.DatabaseService.Models.MaintenanceRunSummary.MaintenanceSubtypeEnum> MaintenanceSubtype { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListMaintenanceRunHistoryRequest request;

            try
            {
                request = new ListMaintenanceRunHistoryRequest
                {
                    CompartmentId = CompartmentId,
                    TargetResourceId = TargetResourceId,
                    TargetResourceType = TargetResourceType,
                    MaintenanceType = MaintenanceType,
                    Limit = Limit,
                    Page = Page,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    LifecycleState = LifecycleState,
                    AvailabilityDomain = AvailabilityDomain,
                    MaintenanceSubtype = MaintenanceSubtype
                };
                IEnumerable<ListMaintenanceRunHistoryResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListMaintenanceRunHistoryResponse> DefaultRequest(ListMaintenanceRunHistoryRequest request) => Enumerable.Repeat(client.ListMaintenanceRunHistory(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListMaintenanceRunHistoryResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListMaintenanceRunHistoryResponse response;
        private delegate IEnumerable<ListMaintenanceRunHistoryResponse> RequestDelegate(ListMaintenanceRunHistoryRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
