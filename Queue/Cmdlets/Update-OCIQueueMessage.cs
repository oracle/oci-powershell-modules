/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.QueueService.Requests;
using Oci.QueueService.Responses;
using Oci.QueueService.Models;
using Oci.Common.Model;

namespace Oci.QueueService.Cmdlets
{
    [Cmdlet("Update", "OCIQueueMessage")]
    [OutputType(new System.Type[] { typeof(Oci.QueueService.Models.UpdatedMessage), typeof(Oci.QueueService.Responses.UpdateMessageResponse) })]
    public class UpdateOCIQueueMessage : OCIQueueCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique Queue identifier")]
        public string QueueId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The receipt of the message retrieved from a GetMessages call.")]
        public string MessageReceipt { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the message to update.")]
        public UpdateMessageDetails UpdateMessageDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateMessageRequest request;

            try
            {
                request = new UpdateMessageRequest
                {
                    QueueId = QueueId,
                    MessageReceipt = MessageReceipt,
                    UpdateMessageDetails = UpdateMessageDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateMessage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.UpdatedMessage);
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

        private UpdateMessageResponse response;
    }
}