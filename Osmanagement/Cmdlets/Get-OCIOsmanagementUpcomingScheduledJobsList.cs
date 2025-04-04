/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190801
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OsmanagementService.Requests;
using Oci.OsmanagementService.Responses;
using Oci.OsmanagementService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIOsmanagementUpcomingScheduledJobsList")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementService.Models.ScheduledJobSummary), typeof(Oci.OsmanagementService.Responses.ListUpcomingScheduledJobsResponse) })]
    public class GetOCIOsmanagementUpcomingScheduledJobsList : OCIOsManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The cut-off time before which to list all upcoming schedules, in ISO 8601 format

Example: 2017-07-14T02:40:00.000Z")]
        public System.Nullable<System.DateTime> TimeEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A user-friendly name. Does not have to be unique, and it's changeable.

Example: `My new resource`")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.OsmanagementService.Requests.ListUpcomingScheduledJobsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. If no value is specified TIMECREATED is default.")]
        public System.Nullable<Oci.OsmanagementService.Requests.ListUpcomingScheduledJobsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the tag.")]
        public string TagName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value for the tag.")]
        public string TagValue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The current lifecycle state for the object.")]
        public System.Nullable<Oci.OsmanagementService.Models.LifecycleStates> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OS family for which to list resources.")]
        public System.Nullable<Oci.OsmanagementService.Models.OsFamilies> OsFamily { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListUpcomingScheduledJobsRequest request;

            try
            {
                request = new ListUpcomingScheduledJobsRequest
                {
                    CompartmentId = CompartmentId,
                    TimeEnd = TimeEnd,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    TagName = TagName,
                    TagValue = TagValue,
                    LifecycleState = LifecycleState,
                    OpcRequestId = OpcRequestId,
                    OsFamily = OsFamily
                };
                IEnumerable<ListUpcomingScheduledJobsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListUpcomingScheduledJobsResponse> DefaultRequest(ListUpcomingScheduledJobsRequest request) => Enumerable.Repeat(client.ListUpcomingScheduledJobs(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListUpcomingScheduledJobsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListUpcomingScheduledJobsResponse response;
        private delegate IEnumerable<ListUpcomingScheduledJobsResponse> RequestDelegate(ListUpcomingScheduledJobsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
