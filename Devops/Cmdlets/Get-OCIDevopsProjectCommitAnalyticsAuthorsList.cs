/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210630
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DevopsService.Requests;
using Oci.DevopsService.Responses;
using Oci.DevopsService.Models;
using Oci.Common.Model;

namespace Oci.DevopsService.Cmdlets
{
    [Cmdlet("Get", "OCIDevopsProjectCommitAnalyticsAuthorsList")]
    [OutputType(new System.Type[] { typeof(Oci.DevopsService.Models.CommitAnalyticsAuthorCollection), typeof(Oci.DevopsService.Responses.ListProjectCommitAnalyticsAuthorsResponse) })]
    public class GetOCIDevopsProjectCommitAnalyticsAuthorsList : OCIDevopsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique project identifier.")]
        public string ProjectId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use. Use either ascending or descending.")]
        public System.Nullable<Oci.DevopsService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request.  If you need to contact Oracle about a particular request, provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort by value is supported for this parameter. Default order for author name is ascending.")]
        public System.Nullable<Oci.DevopsService.Requests.ListProjectCommitAnalyticsAuthorsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListProjectCommitAnalyticsAuthorsRequest request;

            try
            {
                request = new ListProjectCommitAnalyticsAuthorsRequest
                {
                    ProjectId = ProjectId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    OpcRequestId = OpcRequestId,
                    SortBy = SortBy
                };
                IEnumerable<ListProjectCommitAnalyticsAuthorsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.CommitAnalyticsAuthorCollection, true);
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
            IEnumerable<ListProjectCommitAnalyticsAuthorsResponse> DefaultRequest(ListProjectCommitAnalyticsAuthorsRequest request) => Enumerable.Repeat(client.ListProjectCommitAnalyticsAuthors(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListProjectCommitAnalyticsAuthorsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListProjectCommitAnalyticsAuthorsResponse response;
        private delegate IEnumerable<ListProjectCommitAnalyticsAuthorsResponse> RequestDelegate(ListProjectCommitAnalyticsAuthorsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}