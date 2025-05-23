/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OpsiService.Requests;
using Oci.OpsiService.Responses;
using Oci.OpsiService.Models;
using Oci.Common.Model;

namespace Oci.OpsiService.Cmdlets
{
    [Cmdlet("Invoke", "OCIOpsiSummarizeAwrSourcesSummaries")]
    [OutputType(new System.Type[] { typeof(Oci.OpsiService.Models.SummarizeAwrSourcesSummariesCollection), typeof(Oci.OpsiService.Responses.SummarizeAwrSourcesSummariesResponse) })]
    public class InvokeOCIOpsiSummarizeAwrSourcesSummaries : OCIOperationsInsightsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Awr Hub identifier")]
        public string AwrHubId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Name for an Awr source database")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine). Example: `50`")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The order in which Awr sources summary records are listed")]
        public System.Nullable<Oci.OpsiService.Requests.SummarizeAwrSourcesSummariesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.OpsiService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeAwrSourcesSummariesRequest request;

            try
            {
                request = new SummarizeAwrSourcesSummariesRequest
                {
                    AwrHubId = AwrHubId,
                    CompartmentId = CompartmentId,
                    Name = Name,
                    Limit = Limit,
                    Page = Page,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId
                };

                response = client.SummarizeAwrSourcesSummaries(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SummarizeAwrSourcesSummariesCollection);
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

        private SummarizeAwrSourcesSummariesResponse response;
    }
}
