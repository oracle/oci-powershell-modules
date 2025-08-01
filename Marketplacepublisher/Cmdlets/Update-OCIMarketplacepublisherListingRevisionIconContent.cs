/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20241201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.MarketplacepublisherService.Requests;
using Oci.MarketplacepublisherService.Responses;
using Oci.MarketplacepublisherService.Models;
using Oci.Common.Model;

namespace Oci.MarketplacepublisherService.Cmdlets
{
    [Cmdlet("Update", "OCIMarketplacepublisherListingRevisionIconContent")]
    [OutputType(new System.Type[] { typeof(Oci.MarketplacepublisherService.Models.ListingRevision), typeof(Oci.MarketplacepublisherService.Responses.UpdateListingRevisionIconContentResponse) })]
    public class UpdateOCIMarketplacepublisherListingRevisionIconContent : OCIMarketplacePublisherCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"listing revision")]
        public string ListingRevisionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The listing revision icon to be updated.", ParameterSetName = FromStreamSet)]
        public System.IO.Stream UpdateListingRevisionIconContent { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Use this parameter to provide the file location from where the input stream to be read. The listing revision icon to be updated.", ParameterSetName = FromFileSet)]
        public String UpdateListingRevisionIconContentFromFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateListingRevisionIconContentRequest request;

            if (ParameterSetName.Equals(FromFileSet))
            {
                UpdateListingRevisionIconContent = System.IO.File.OpenRead(GetAbsoluteFilePath(UpdateListingRevisionIconContentFromFile));
            }
            

            try
            {
                request = new UpdateListingRevisionIconContentRequest
                {
                    ListingRevisionId = ListingRevisionId,
                    UpdateListingRevisionIconContent = UpdateListingRevisionIconContent,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateListingRevisionIconContent(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ListingRevision);
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

        private UpdateListingRevisionIconContentResponse response;
        private const string FromFileSet = "FromFile";
        private const string FromStreamSet = "FromStream";
    }
}
