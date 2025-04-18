/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;
using Oci.ObjectstorageService.Models;
using Oci.Common.Model;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("Get", "OCIObjectstoragePreauthenticatedRequestsList")]
    [OutputType(new System.Type[] { typeof(Oci.ObjectstorageService.Models.PreauthenticatedRequestSummary), typeof(Oci.ObjectstorageService.Responses.ListPreauthenticatedRequestsResponse) })]
    public class GetOCIObjectstoragePreauthenticatedRequestsList : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"User-specified object name prefixes can be used to query and return a list of pre-authenticated requests.")]
        public string ObjectNamePrefix { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListPreauthenticatedRequestsRequest request;

            try
            {
                request = new ListPreauthenticatedRequestsRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    ObjectNamePrefix = ObjectNamePrefix,
                    Limit = Limit,
                    Page = Page,
                    OpcClientRequestId = OpcClientRequestId
                };
                IEnumerable<ListPreauthenticatedRequestsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
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
            IEnumerable<ListPreauthenticatedRequestsResponse> DefaultRequest(ListPreauthenticatedRequestsRequest request) => Enumerable.Repeat(client.ListPreauthenticatedRequests(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListPreauthenticatedRequestsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListPreauthenticatedRequestsResponse response;
        private delegate IEnumerable<ListPreauthenticatedRequestsResponse> RequestDelegate(ListPreauthenticatedRequestsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
