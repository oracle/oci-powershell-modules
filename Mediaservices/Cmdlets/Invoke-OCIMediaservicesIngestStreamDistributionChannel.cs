/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20211101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.MediaservicesService.Requests;
using Oci.MediaservicesService.Responses;
using Oci.MediaservicesService.Models;
using Oci.Common.Model;

namespace Oci.MediaservicesService.Cmdlets
{
    [Cmdlet("Invoke", "OCIMediaservicesIngestStreamDistributionChannel")]
    [OutputType(new System.Type[] { typeof(Oci.MediaservicesService.Models.IngestStreamDistributionChannelResult), typeof(Oci.MediaservicesService.Responses.IngestStreamDistributionChannelResponse) })]
    public class InvokeOCIMediaservicesIngestStreamDistributionChannel : OCIMediaServicesCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Stream Distribution Channel path identifier.")]
        public string StreamDistributionChannelId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Playlist entry information. This parameter also accepts subtype <Oci.MediaservicesService.Models.AssetMetadataEntryDetails> of type <Oci.MediaservicesService.Models.IngestStreamDistributionChannelDetails>.")]
        public IngestStreamDistributionChannelDetails IngestStreamDistributionChannelDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without the risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            IngestStreamDistributionChannelRequest request;

            try
            {
                request = new IngestStreamDistributionChannelRequest
                {
                    StreamDistributionChannelId = StreamDistributionChannelId,
                    IngestStreamDistributionChannelDetails = IngestStreamDistributionChannelDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.IngestStreamDistributionChannel(request).GetAwaiter().GetResult();
                WriteOutput(response, response.IngestStreamDistributionChannelResult);
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

        private IngestStreamDistributionChannelResponse response;
    }
}