/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230831
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.FleetappsmanagementService.Requests;
using Oci.FleetappsmanagementService.Responses;
using Oci.FleetappsmanagementService.Models;
using Oci.Common.Model;

namespace Oci.FleetappsmanagementService.Cmdlets
{
    [Cmdlet("Invoke", "OCIFleetappsmanagementSummarizeSchedulerJobCounts")]
    [OutputType(new System.Type[] { typeof(Oci.FleetappsmanagementService.Models.SchedulerJobAggregationCollection), typeof(Oci.FleetappsmanagementService.Responses.SummarizeSchedulerJobCountsResponse) })]
    public class InvokeOCIFleetappsmanagementSummarizeSchedulerJobCounts : OCIFleetAppsManagementOperationsCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token representing the position at which to start retrieving results. This must come from the `opc-next-page` header field of a previous response.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'ASC' or 'DESC'.")]
        public System.Nullable<Oci.FleetappsmanagementService.Models.SortOrder> SortOrder { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeSchedulerJobCountsRequest request;

            try
            {
                request = new SummarizeSchedulerJobCountsRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder
                };

                response = client.SummarizeSchedulerJobCounts(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SchedulerJobAggregationCollection);
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

        private SummarizeSchedulerJobCountsResponse response;
    }
}