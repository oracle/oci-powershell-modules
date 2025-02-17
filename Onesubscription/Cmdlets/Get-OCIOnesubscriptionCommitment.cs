/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190111
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OnesubscriptionService.Requests;
using Oci.OnesubscriptionService.Responses;
using Oci.OnesubscriptionService.Models;
using Oci.Common.Model;

namespace Oci.OnesubscriptionService.Cmdlets
{
    [Cmdlet("Get", "OCIOnesubscriptionCommitment")]
    [OutputType(new System.Type[] { typeof(Oci.OnesubscriptionService.Models.Commitment), typeof(Oci.OnesubscriptionService.Responses.GetCommitmentResponse) })]
    public class GetOCIOnesubscriptionCommitment : OCICommitmentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Commitment Id")]
        public string CommitmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetCommitmentRequest request;

            try
            {
                request = new GetCommitmentRequest
                {
                    CommitmentId = CommitmentId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetCommitment(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Commitment);
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

        private GetCommitmentResponse response;
    }
}
