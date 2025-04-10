/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200131
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.CloudguardService.Requests;
using Oci.CloudguardService.Responses;
using Oci.CloudguardService.Models;
using Oci.Common.Model;

namespace Oci.CloudguardService.Cmdlets
{
    [Cmdlet("Get", "OCICloudguardResourceProfilesList")]
    [OutputType(new System.Type[] { typeof(Oci.CloudguardService.Models.ResourceProfileCollection), typeof(Oci.CloudguardService.Responses.ListResourceProfilesResponse) })]
    public class GetOCICloudguardResourceProfilesList : OCICloudGuardCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Start time for a filter. If start time is not specified, start time will be set to current time - 30 days.")]
        public System.Nullable<System.DateTime> TimeLastDetectedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"End time for a filter. If end time is not specified, end time will be set to current time.")]
        public System.Nullable<System.DateTime> TimeLastDetectedLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Start time for a filter. If start time is not specified, start time will be set to current time - 30 days.")]
        public System.Nullable<System.DateTime> TimeFirstDetectedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"End time for a filter. If end time is not specified, end time will be set to current time.")]
        public System.Nullable<System.DateTime> TimeFirstDetectedLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Default is false. When set to true, the hierarchy of compartments is traversed and all compartments and subcompartments in the tenancy are returned depending on the setting of `accessLevel`.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Valid values are `RESTRICTED` and `ACCESSIBLE`. Default is `RESTRICTED`. Setting this to `ACCESSIBLE` returns only those compartments for which the user has INSPECT permissions directly or indirectly (permissions can be on a resource in a subcompartment). When set to `RESTRICTED` permissions are checked and no partial results are displayed.")]
        public System.Nullable<Oci.CloudguardService.Requests.ListResourceProfilesRequest.AccessLevelEnum> AccessLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the list of resource types given.")]
        public System.Collections.Generic.List<string> ResourceTypes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Risk score filter.")]
        public System.Double RiskScoreGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Risk score filter,")]
        public System.Double RiskScoreLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the list of techniques given.")]
        public System.Collections.Generic.List<string> Techniques { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the list of tactics given.")]
        public System.Collections.Generic.List<string> Tactics { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use")]
        public System.Nullable<Oci.CloudguardService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort resource profiles. Only one sort order may be provided. Default order for timeLastDetected is descending. If no value is specified timeLastDetected is default.")]
        public System.Nullable<Oci.CloudguardService.Requests.ListResourceProfilesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListResourceProfilesRequest request;

            try
            {
                request = new ListResourceProfilesRequest
                {
                    CompartmentId = CompartmentId,
                    TimeLastDetectedGreaterThanOrEqualTo = TimeLastDetectedGreaterThanOrEqualTo,
                    TimeLastDetectedLessThanOrEqualTo = TimeLastDetectedLessThanOrEqualTo,
                    TimeFirstDetectedGreaterThanOrEqualTo = TimeFirstDetectedGreaterThanOrEqualTo,
                    TimeFirstDetectedLessThanOrEqualTo = TimeFirstDetectedLessThanOrEqualTo,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    AccessLevel = AccessLevel,
                    ResourceTypes = ResourceTypes,
                    RiskScoreGreaterThanOrEqualTo = RiskScoreGreaterThanOrEqualTo,
                    RiskScoreLessThanOrEqualTo = RiskScoreLessThanOrEqualTo,
                    Techniques = Techniques,
                    Tactics = Tactics,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListResourceProfilesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ResourceProfileCollection, true);
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
            IEnumerable<ListResourceProfilesResponse> DefaultRequest(ListResourceProfilesRequest request) => Enumerable.Repeat(client.ListResourceProfiles(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListResourceProfilesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListResourceProfilesResponse response;
        private delegate IEnumerable<ListResourceProfilesResponse> RequestDelegate(ListResourceProfilesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
