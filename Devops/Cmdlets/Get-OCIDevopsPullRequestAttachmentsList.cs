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
    [Cmdlet("Get", "OCIDevopsPullRequestAttachmentsList")]
    [OutputType(new System.Type[] { typeof(Oci.DevopsService.Models.PullRequestAttachmentCollection), typeof(Oci.DevopsService.Responses.ListPullRequestAttachmentsResponse) })]
    public class GetOCIDevopsPullRequestAttachmentsList : OCIDevopsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique PullRequest identifier")]
        public string PullRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use. Use either ascending or descending.")]
        public System.Nullable<Oci.DevopsService.Models.SortOrder> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order is ascending. If no value is specified timeCreated is default.")]
        public System.Nullable<Oci.DevopsService.Requests.ListPullRequestAttachmentsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire file name given.")]
        public string FileName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request.  If you need to contact Oracle about a particular request, provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListPullRequestAttachmentsRequest request;

            try
            {
                request = new ListPullRequestAttachmentsRequest
                {
                    PullRequestId = PullRequestId,
                    CompartmentId = CompartmentId,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    FileName = FileName,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListPullRequestAttachmentsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.PullRequestAttachmentCollection, true);
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
            IEnumerable<ListPullRequestAttachmentsResponse> DefaultRequest(ListPullRequestAttachmentsRequest request) => Enumerable.Repeat(client.ListPullRequestAttachments(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListPullRequestAttachmentsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListPullRequestAttachmentsResponse response;
        private delegate IEnumerable<ListPullRequestAttachmentsResponse> RequestDelegate(ListPullRequestAttachmentsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}