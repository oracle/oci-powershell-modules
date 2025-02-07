/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OsmanagementhubService.Requests;
using Oci.OsmanagementhubService.Responses;
using Oci.OsmanagementhubService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementhubService.Cmdlets
{
    [Cmdlet("Get", "OCIOsmanagementhubScheduledJobsList")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementhubService.Models.ScheduledJobCollection), typeof(Oci.OsmanagementhubService.Responses.ListScheduledJobsResponse) })]
    public class GetOCIOsmanagementhubScheduledJobsList : OCIScheduledJobCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment that contains the resources to list. This filter returns only resources contained within the specified compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resources that match the given user-friendly name.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resources that may partially match the given display name.")]
        public string DisplayNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only scheduled jobs currently in the given state.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.ScheduledJob.LifecycleStateEnum> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the managed instance. This filter returns resources associated with this managed instance.")]
        public string ManagedInstanceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the managed instance group. This filter returns resources associated with this group.")]
        public string ManagedInstanceGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the managed compartment. This filter returns resources associated with this compartment.")]
        public string ManagedCompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the lifecycle stage. This resource returns resources associated with this lifecycle stage.")]
        public string LifecycleStageId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only scheduled jobs with the given operation type.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.OperationTypes> OperationType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only scheduled jobs of the given scheduling type (one-time or recurring).")]
        public System.Nullable<Oci.OsmanagementhubService.Models.ScheduleTypes> ScheduleType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources with a date on or after the given value, in ISO 8601 format.

Example: 2017-07-14T02:40:00.000Z")]
        public System.Nullable<System.DateTime> TimeStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources with a date on or before the given value, in ISO 8601 format.

Example: 2017-07-14T02:40:00.000Z")]
        public System.Nullable<System.DateTime> TimeEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `50`", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Example: `3`")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.OsmanagementhubService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. Default order for displayName is ascending.")]
        public System.Nullable<Oci.OsmanagementhubService.Requests.ListScheduledJobsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only restricted scheduled jobs.")]
        public System.Nullable<bool> IsRestricted { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the scheduled job. A filter to return the specified job.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates whether to include subcompartments in the returned results. Default is false.")]
        public System.Nullable<bool> CompartmentIdInSubtree { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources whose location matches the given value.")]
        public System.Collections.Generic.List<Oci.OsmanagementhubService.Models.ManagedInstanceLocation> Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources whose location does not match the given value.")]
        public System.Collections.Generic.List<Oci.OsmanagementhubService.Models.ManagedInstanceLocation> LocationNotEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates whether to list only resources managed by the Autonomous Linux service.")]
        public System.Nullable<bool> IsManagedByAutonomousLinux { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListScheduledJobsRequest request;

            try
            {
                request = new ListScheduledJobsRequest
                {
                    CompartmentId = CompartmentId,
                    DisplayName = DisplayName,
                    DisplayNameContains = DisplayNameContains,
                    LifecycleState = LifecycleState,
                    ManagedInstanceId = ManagedInstanceId,
                    ManagedInstanceGroupId = ManagedInstanceGroupId,
                    ManagedCompartmentId = ManagedCompartmentId,
                    LifecycleStageId = LifecycleStageId,
                    OperationType = OperationType,
                    ScheduleType = ScheduleType,
                    TimeStart = TimeStart,
                    TimeEnd = TimeEnd,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    IsRestricted = IsRestricted,
                    Id = Id,
                    CompartmentIdInSubtree = CompartmentIdInSubtree,
                    Location = Location,
                    LocationNotEqualTo = LocationNotEqualTo,
                    IsManagedByAutonomousLinux = IsManagedByAutonomousLinux
                };
                IEnumerable<ListScheduledJobsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.ScheduledJobCollection, true);
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
            IEnumerable<ListScheduledJobsResponse> DefaultRequest(ListScheduledJobsRequest request) => Enumerable.Repeat(client.ListScheduledJobs(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListScheduledJobsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListScheduledJobsResponse response;
        private delegate IEnumerable<ListScheduledJobsResponse> RequestDelegate(ListScheduledJobsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
