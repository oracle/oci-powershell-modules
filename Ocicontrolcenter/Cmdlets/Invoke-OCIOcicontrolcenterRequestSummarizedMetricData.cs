/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230515
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OcicontrolcenterService.Requests;
using Oci.OcicontrolcenterService.Responses;
using Oci.OcicontrolcenterService.Models;
using Oci.Common.Model;

namespace Oci.OcicontrolcenterService.Cmdlets
{
    [Cmdlet("Invoke", "OCIOcicontrolcenterRequestSummarizedMetricData")]
    [OutputType(new System.Type[] { typeof(Oci.OcicontrolcenterService.Models.SummarizedMetricDataCollection), typeof(Oci.OcicontrolcenterService.Responses.RequestSummarizedMetricDataResponse) })]
    public class InvokeOCIOcicontrolcenterRequestSummarizedMetricData : OCIOccMetricsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filters to apply to the metric data query")]
        public RequestSummarizedMetricDataDetails RequestSummarizedMetricDataDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see <a href=""https://docs.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine"">List Pagination</a>.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            RequestSummarizedMetricDataRequest request;

            try
            {
                request = new RequestSummarizedMetricDataRequest
                {
                    RequestSummarizedMetricDataDetails = RequestSummarizedMetricDataDetails,
                    Page = Page,
                    Limit = Limit,
                    OpcRequestId = OpcRequestId
                };

                response = client.RequestSummarizedMetricData(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SummarizedMetricDataCollection);
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

        private RequestSummarizedMetricDataResponse response;
    }
}