/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DevopsService.Requests;
using Oci.DevopsService.Responses;
using Oci.DevopsService.Models;
using Oci.Common.Model;

namespace Oci.DevopsService.Cmdlets
{
    [Cmdlet("Invoke", "OCIDevopsSummarizeProjectRepositoryAnalytics")]
    [OutputType(new System.Type[] { typeof(Oci.DevopsService.Models.RepositoryMetricAggregation), typeof(Oci.DevopsService.Responses.SummarizeProjectRepositoryAnalyticsResponse) })]
    public class InvokeOCIDevopsSummarizeProjectRepositoryAnalytics : OCIDevopsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique project identifier.")]
        public string ProjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details to fetch the repository analytics.")]
        public SummarizeProjectRepositoryAnalyticsDetails SummarizeProjectRepositoryAnalyticsDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request.  If you need to contact Oracle about a particular request, provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeProjectRepositoryAnalyticsRequest request;

            try
            {
                request = new SummarizeProjectRepositoryAnalyticsRequest
                {
                    ProjectId = ProjectId,
                    SummarizeProjectRepositoryAnalyticsDetails = SummarizeProjectRepositoryAnalyticsDetails,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeProjectRepositoryAnalytics(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RepositoryMetricAggregation);
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

        private SummarizeProjectRepositoryAnalyticsResponse response;
    }
}