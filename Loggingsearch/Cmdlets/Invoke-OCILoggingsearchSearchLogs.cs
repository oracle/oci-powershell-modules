/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190909
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoggingsearchService.Requests;
using Oci.LoggingsearchService.Responses;
using Oci.LoggingsearchService.Models;
using Oci.Common.Model;

namespace Oci.LoggingsearchService.Cmdlets
{
    [Cmdlet("Invoke", "OCILoggingsearchSearchLogs")]
    [OutputType(new System.Type[] { typeof(Oci.LoggingsearchService.Models.SearchResponse), typeof(Oci.LoggingsearchService.Responses.SearchLogsResponse) })]
    public class InvokeOCILoggingsearchSearchLogs : OCILogSearchCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Search request.")]
        public SearchLogsDetails SearchLogsDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a response. Pagination is not supported in this API.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the opc-next-page response header from the previous ""Search"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SearchLogsRequest request;

            try
            {
                request = new SearchLogsRequest
                {
                    SearchLogsDetails = SearchLogsDetails,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page
                };

                response = client.SearchLogs(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SearchResponse);
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

        private SearchLogsResponse response;
    }
}
