/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200430
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DataintegrationService.Requests;
using Oci.DataintegrationService.Responses;
using Oci.DataintegrationService.Models;
using Oci.Common.Model;

namespace Oci.DataintegrationService.Cmdlets
{
    [Cmdlet("Get", "OCIDataintegrationTaskRunLineagesList")]
    [OutputType(new System.Type[] { typeof(Oci.DataintegrationService.Models.TaskRunLineageSummaryCollection), typeof(Oci.DataintegrationService.Responses.ListTaskRunLineagesResponse) })]
    public class GetOCIDataintegrationTaskRunLineagesList : OCIDataIntegrationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The workspace ID.")]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The application key.")]
        public string ApplicationKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to get for an object.")]
        public System.Collections.Generic.List<string> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value for this parameter is the `opc-next-page` or the `opc-prev-page` response header from the previous `List` call. See [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Sets the maximum number of results per page, or items to return in a paginated `List` call. See [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies sort order to use, either `ASC` (ascending) or `DESC` (descending).")]
        public System.Nullable<Oci.DataintegrationService.Requests.ListTaskRunLineagesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the field to sort by. Accepts only one field. By default, when you sort by time fields, results are shown in descending order. All other fields default to ascending order. Sorting related parameters are ignored when parameter `query` is present (search operation and sorting order is by relevance score in descending order).")]
        public System.Nullable<Oci.DataintegrationService.Requests.ListTaskRunLineagesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This filter parameter can be used to filter by model specific queryable fields of the object <br><br><B>Examples:-</B><br> <ul> <li><B>?filter=status eq Failed</B> returns all objects that have a status field with value Failed</li> </ul>")]
        public System.Collections.Generic.List<string> Filter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This parameter allows users to get objects which were updated after a certain time. The format of timeUpdatedGreaterThan is ""YYYY-MM-dd'T'HH:mm:ss.SSS'Z'""")]
        public System.Nullable<System.DateTime> TimeUpdatedGreaterThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This parameter allows users to get objects which were updated after and at a certain time. The format of timeUpdatedGreaterThanOrEqualTo is ""YYYY-MM-dd'T'HH:mm:ss.SSS'Z'""")]
        public System.Nullable<System.DateTime> TimeUpdatedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This parameter allows users to get objects which were updated before a certain time. The format of timeUpatedLessThan is ""YYYY-MM-dd'T'HH:mm:ss.SSS'Z'""")]
        public System.Nullable<System.DateTime> TimeUpatedLessThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This parameter allows users to get objects which were updated before and at a certain time. The format of timeUpatedLessThanOrEqualTo is ""YYYY-MM-dd'T'HH:mm:ss.SSS'Z'""")]
        public System.Nullable<System.DateTime> TimeUpatedLessThanOrEqualTo { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListTaskRunLineagesRequest request;

            try
            {
                request = new ListTaskRunLineagesRequest
                {
                    WorkspaceId = WorkspaceId,
                    ApplicationKey = ApplicationKey,
                    OpcRequestId = OpcRequestId,
                    Fields = Fields,
                    Page = Page,
                    Limit = Limit,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    Filter = Filter,
                    TimeUpdatedGreaterThan = TimeUpdatedGreaterThan,
                    TimeUpdatedGreaterThanOrEqualTo = TimeUpdatedGreaterThanOrEqualTo,
                    TimeUpatedLessThan = TimeUpatedLessThan,
                    TimeUpatedLessThanOrEqualTo = TimeUpatedLessThanOrEqualTo
                };
                IEnumerable<ListTaskRunLineagesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.TaskRunLineageSummaryCollection, true);
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
            IEnumerable<ListTaskRunLineagesResponse> DefaultRequest(ListTaskRunLineagesRequest request) => Enumerable.Repeat(client.ListTaskRunLineages(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListTaskRunLineagesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListTaskRunLineagesResponse response;
        private delegate IEnumerable<ListTaskRunLineagesResponse> RequestDelegate(ListTaskRunLineagesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
