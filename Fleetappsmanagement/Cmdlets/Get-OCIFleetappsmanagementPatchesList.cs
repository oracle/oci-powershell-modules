/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20250228
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.FleetappsmanagementService.Requests;
using Oci.FleetappsmanagementService.Responses;
using Oci.FleetappsmanagementService.Models;
using Oci.Common.Model;

namespace Oci.FleetappsmanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIFleetappsmanagementPatchesList")]
    [OutputType(new System.Type[] { typeof(Oci.FleetappsmanagementService.Models.PatchCollection), typeof(Oci.FleetappsmanagementService.Responses.ListPatchesResponse) })]
    public class GetOCIFleetappsmanagementPatchesList : OCIFleetAppsManagementOperationsCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources. Empty only if the resource OCID query param is not specified.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Product platformConfigurationId associated with the Patch.")]
        public string ProductId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Product version.")]
        public string Version { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"DefinedBy type.")]
        public System.Nullable<Oci.FleetappsmanagementService.Models.Patch.TypeEnum> Type { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Patch Type platformConfigurationId associated with the Patch.")]
        public string PatchTypeId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire name given.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier or OCID for listing a single Patch by id. Either compartmentId or id must be provided.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return patches whose release date is greater than or equal to the given date.")]
        public System.Nullable<System.DateTime> TimeReleasedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return patches whose release date is less than the given date.")]
        public System.Nullable<System.DateTime> TimeReleasedLessThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter patch based on compliance policy rules for the Product.")]
        public System.Nullable<bool> ShouldCompliancePolicyRulesBeApplied { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The current state of the Patch.")]
        public System.Nullable<Oci.FleetappsmanagementService.Models.Patch.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for name is ascending.")]
        public System.Nullable<Oci.FleetappsmanagementService.Models.PatchSortBy> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.FleetappsmanagementService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListPatchesRequest request;

            try
            {
                request = new ListPatchesRequest
                {
                    CompartmentId = CompartmentId,
                    ProductId = ProductId,
                    Version = Version,
                    Type = Type,
                    PatchTypeId = PatchTypeId,
                    Name = Name,
                    Id = Id,
                    TimeReleasedGreaterThanOrEqualTo = TimeReleasedGreaterThanOrEqualTo,
                    TimeReleasedLessThan = TimeReleasedLessThan,
                    ShouldCompliancePolicyRulesBeApplied = ShouldCompliancePolicyRulesBeApplied,
                    Limit = Limit,
                    Page = Page,
                    LifecycleState = LifecycleState,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListPatchesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.PatchCollection, true);
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
            IEnumerable<ListPatchesResponse> DefaultRequest(ListPatchesRequest request) => Enumerable.Repeat(client.ListPatches(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListPatchesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListPatchesResponse response;
        private delegate IEnumerable<ListPatchesResponse> RequestDelegate(ListPatchesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
