/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220504
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.GovernancerulescontrolplaneService.Requests;
using Oci.GovernancerulescontrolplaneService.Responses;
using Oci.GovernancerulescontrolplaneService.Models;
using Oci.Common.Model;

namespace Oci.GovernancerulescontrolplaneService.Cmdlets
{
    [Cmdlet("Get", "OCIGovernancerulescontrolplaneTenancyAttachmentsList")]
    [OutputType(new System.Type[] { typeof(Oci.GovernancerulescontrolplaneService.Models.TenancyAttachmentCollection), typeof(Oci.GovernancerulescontrolplaneService.Responses.ListTenancyAttachmentsResponse) })]
    public class GetOCIGovernancerulescontrolplaneTenancyAttachmentsList : OCIGovernanceRuleCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique tenancy attachment identifier.")]
        public string TenancyAttachmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique governance rule identifier.")]
        public string GovernanceRuleId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources when their lifecycle state matches the given lifecycle state.")]
        public System.Nullable<Oci.GovernancerulescontrolplaneService.Models.TenancyAttachment.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only governance rules that match the given tenancy id.")]
        public string ChildTenancyId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.GovernancerulescontrolplaneService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending.")]
        public System.Nullable<Oci.GovernancerulescontrolplaneService.Requests.ListTenancyAttachmentsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListTenancyAttachmentsRequest request;

            try
            {
                request = new ListTenancyAttachmentsRequest
                {
                    CompartmentId = CompartmentId,
                    TenancyAttachmentId = TenancyAttachmentId,
                    GovernanceRuleId = GovernanceRuleId,
                    LifecycleState = LifecycleState,
                    ChildTenancyId = ChildTenancyId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListTenancyAttachmentsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.TenancyAttachmentCollection, true);
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
            IEnumerable<ListTenancyAttachmentsResponse> DefaultRequest(ListTenancyAttachmentsRequest request) => Enumerable.Repeat(client.ListTenancyAttachments(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListTenancyAttachmentsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListTenancyAttachmentsResponse response;
        private delegate IEnumerable<ListTenancyAttachmentsResponse> RequestDelegate(ListTenancyAttachmentsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}