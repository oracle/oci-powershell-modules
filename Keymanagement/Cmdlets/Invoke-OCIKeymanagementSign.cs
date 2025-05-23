/*
 * NOTE: Generated using OracleSDKGenerator, API Version: release
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.KeymanagementService.Requests;
using Oci.KeymanagementService.Responses;
using Oci.KeymanagementService.Models;
using Oci.Common.Model;

namespace Oci.KeymanagementService.Cmdlets
{
    [Cmdlet("Invoke", "OCIKeymanagementSign")]
    [OutputType(new System.Type[] { typeof(Oci.KeymanagementService.Models.SignedData), typeof(Oci.KeymanagementService.Responses.SignResponse) })]
    public class InvokeOCIKeymanagementSign : OCIKmsCryptoCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"SignDataDetails")]
        public SignDataDetails SignDataDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If provided, the returned request ID will include this value. Otherwise, a random request ID will be generated by the service.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SignRequest request;

            try
            {
                request = new SignRequest
                {
                    SignDataDetails = SignDataDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.Sign(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SignedData);
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

        private SignResponse response;
    }
}
