/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210330
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.StackmonitoringService.Requests;
using Oci.StackmonitoringService.Responses;
using Oci.StackmonitoringService.Models;
using Oci.Common.Model;

namespace Oci.StackmonitoringService.Cmdlets
{
    [Cmdlet("Invoke", "OCIStackmonitoringRequestMonitoredResourcesSummarizedCount")]
    [OutputType(new System.Type[] { typeof(Oci.StackmonitoringService.Models.MonitoredResourcesCountAggregationCollection), typeof(Oci.StackmonitoringService.Responses.RequestMonitoredResourcesSummarizedCountResponse) })]
    public class InvokeOCIStackmonitoringRequestMonitoredResourcesSummarizedCount : OCIStackMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which data is listed.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to group by. Default group by is 'resourceType'.")]
        public System.Nullable<Oci.StackmonitoringService.Requests.RequestMonitoredResourcesSummarizedCountRequest.GroupByEnum> GroupBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter to return resource counts that match with the given licence edition.")]
        public System.Nullable<Oci.StackmonitoringService.Models.LicenseType> License { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return resource counts that match exact resource type.")]
        public string ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"If this query parameter is specified, the result is sorted by this query parameter value.")]
        public System.Nullable<Oci.StackmonitoringService.Requests.RequestMonitoredResourcesSummarizedCountRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.StackmonitoringService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RequestMonitoredResourcesSummarizedCountRequest request;

            try
            {
                request = new RequestMonitoredResourcesSummarizedCountRequest
                {
                    CompartmentId = CompartmentId,
                    GroupBy = GroupBy,
                    License = License,
                    ResourceType = ResourceType,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };

                response = client.RequestMonitoredResourcesSummarizedCount(request).GetAwaiter().GetResult();
                WriteOutput(response, response.MonitoredResourcesCountAggregationCollection);
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

        private RequestMonitoredResourcesSummarizedCountResponse response;
    }
}
