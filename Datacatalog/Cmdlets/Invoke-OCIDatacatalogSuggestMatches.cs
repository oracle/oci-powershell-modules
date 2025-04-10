/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;
using Oci.Common.Model;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Invoke", "OCIDatacatalogSuggestMatches")]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.SuggestResults), typeof(Oci.DatacatalogService.Responses.SuggestMatchesResponse) })]
    public class InvokeOCIDatacatalogSuggestMatches : OCIDataCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.")]
        public string CatalogId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Text input string used for computing potential matching suggestions.")]
        public string InputText { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A search timeout string (for example, timeout=4000ms), bounding the search request to be executed within the specified time value and bail with the hits accumulated up to that point when expired. Defaults to no timeout.")]
        public string Timeout { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Limit for the list of potential matches returned from the Suggest API. If not specified, will default to 10.")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SuggestMatchesRequest request;

            try
            {
                request = new SuggestMatchesRequest
                {
                    CatalogId = CatalogId,
                    InputText = InputText,
                    Timeout = Timeout,
                    Limit = Limit,
                    OpcRequestId = OpcRequestId
                };

                response = client.SuggestMatches(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SuggestResults);
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

        private SuggestMatchesResponse response;
    }
}
