/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.JmsjavadownloadsService.Requests;
using Oci.JmsjavadownloadsService.Responses;
using Oci.JmsjavadownloadsService.Models;
using Oci.Common.Model;

namespace Oci.JmsjavadownloadsService.Cmdlets
{
    [Cmdlet("Get", "OCIJmsjavadownloadsJavaLicensesList")]
    [OutputType(new System.Type[] { typeof(Oci.JmsjavadownloadsService.Models.JavaLicenseCollection), typeof(Oci.JmsjavadownloadsService.Responses.ListJavaLicensesResponse) })]
    public class GetOCIJmsjavadownloadsJavaLicensesList : OCIJavaDownloadCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Java license type.")]
        public System.Nullable<Oci.JmsjavadownloadsService.Models.LicenseType> LicenseType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the display name.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. The token is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.JmsjavadownloadsService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. If no value is specified, _licenseType_ is the default.")]
        public System.Nullable<Oci.JmsjavadownloadsService.Models.LicenseSortBy> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListJavaLicensesRequest request;

            try
            {
                request = new ListJavaLicensesRequest
                {
                    LicenseType = LicenseType,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListJavaLicensesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.JavaLicenseCollection, true);
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
            IEnumerable<ListJavaLicensesResponse> DefaultRequest(ListJavaLicensesRequest request) => Enumerable.Repeat(client.ListJavaLicenses(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListJavaLicensesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListJavaLicensesResponse response;
        private delegate IEnumerable<ListJavaLicensesResponse> RequestDelegate(ListJavaLicensesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
