/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190828
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.NosqlService.Requests;
using Oci.NosqlService.Responses;
using Oci.NosqlService.Models;
using Oci.Common.Model;

namespace Oci.NosqlService.Cmdlets
{
    [Cmdlet("Invoke", "OCINosqlQuery")]
    [OutputType(new System.Type[] { typeof(Oci.NosqlService.Models.QueryResultCollection), typeof(Oci.NosqlService.Responses.QueryResponse) })]
    public class InvokeOCINosqlQuery : OCINosqlCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"SQL query statement and ancillary information.")]
        public QueryDetails QueryDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            QueryRequest request;

            try
            {
                request = new QueryRequest
                {
                    QueryDetails = QueryDetails,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };

                response = client.Query(request).GetAwaiter().GetResult();
                WriteOutput(response, response.QueryResultCollection);
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

        private QueryResponse response;
    }
}
