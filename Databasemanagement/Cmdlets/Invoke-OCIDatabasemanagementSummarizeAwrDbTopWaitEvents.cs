/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Invoke", "OCIDatabasemanagementSummarizeAwrDbTopWaitEvents")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.AwrDbTopWaitEventCollection), typeof(Oci.DatabasemanagementService.Responses.SummarizeAwrDbTopWaitEventsResponse) })]
    public class InvokeOCIDatabasemanagementSummarizeAwrDbTopWaitEvents : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The parameter to filter the database by internal ID. Note that the internal ID of the database can be retrieved from the following endpoint: /managedDatabases/{managedDatabaseId}/awrDbs:")]
        public string AwrDbId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional single value query parameter to filter the database instance number.")]
        public string InstNum { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to filter on the snapshot ID.")]
        public System.Nullable<int> BeginSnIdGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter the snapshot ID.")]
        public System.Nullable<int> EndSnIdLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional greater than or equal to query parameter to filter the timestamp.")]
        public System.Nullable<System.DateTime> TimeGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional less than or equal to query parameter to filter the timestamp.")]
        public System.Nullable<System.DateTime> TimeLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional query parameter to filter ASH activities by FOREGROUND or BACKGROUND.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.SummarizeAwrDbTopWaitEventsRequest.SessionTypeEnum> SessionType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional query parameter to filter the database container by an exact ID value. Note that the database container ID can be retrieved from the following endpoint: /managedDatabases/{managedDatabaseId}/awrDbSnapshotRanges")]
        public System.Nullable<int> ContainerId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional query parameter to filter the number of top categories to be returned.")]
        public System.Nullable<int> TopN { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The option to sort the AWR top event summary data.")]
        public System.Nullable<Oci.DatabasemanagementService.Requests.SummarizeAwrDbTopWaitEventsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The option to sort information in ascending ('ASC') or descending ('DESC') order. Descending order is the the default order.")]
        public System.Nullable<Oci.DatabasemanagementService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeAwrDbTopWaitEventsRequest request;

            try
            {
                request = new SummarizeAwrDbTopWaitEventsRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    AwrDbId = AwrDbId,
                    InstNum = InstNum,
                    BeginSnIdGreaterThanOrEqualTo = BeginSnIdGreaterThanOrEqualTo,
                    EndSnIdLessThanOrEqualTo = EndSnIdLessThanOrEqualTo,
                    TimeGreaterThanOrEqualTo = TimeGreaterThanOrEqualTo,
                    TimeLessThanOrEqualTo = TimeLessThanOrEqualTo,
                    SessionType = SessionType,
                    ContainerId = ContainerId,
                    TopN = TopN,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.SummarizeAwrDbTopWaitEvents(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AwrDbTopWaitEventCollection);
                FinishProcessing(response);
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

        private SummarizeAwrDbTopWaitEventsResponse response;
    }
}