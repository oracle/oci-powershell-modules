/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
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
    [Cmdlet("Write", "OCIQueueMessages")]
    [OutputType(new System.Type[] { typeof(Oci.QueueService.Models.PutMessages), typeof(Oci.QueueService.Responses.PutMessagesResponse) })]
    public class WriteOCIQueueMessages : OCIQueueCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique queue identifier.")]
        public string QueueId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the messages to publish.")]
        public PutMessagesDetails PutMessagesDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PutMessagesRequest request;

            try
            {
                request = new PutMessagesRequest
                {
                    QueueId = QueueId,
                    PutMessagesDetails = PutMessagesDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.PutMessages(request).GetAwaiter().GetResult();
                WriteOutput(response, response.PutMessages);
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

        private PutMessagesResponse response;
    }
}
