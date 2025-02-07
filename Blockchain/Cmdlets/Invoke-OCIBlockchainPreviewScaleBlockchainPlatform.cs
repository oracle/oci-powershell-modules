/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20191010
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.BlockchainService.Requests;
using Oci.BlockchainService.Responses;
using Oci.BlockchainService.Models;
using Oci.Common.Model;

namespace Oci.BlockchainService.Cmdlets
{
    [Cmdlet("Invoke", "OCIBlockchainPreviewScaleBlockchainPlatform")]
    [OutputType(new System.Type[] { typeof(Oci.BlockchainService.Models.ScaledBlockchainPlatformPreview), typeof(Oci.BlockchainService.Responses.PreviewScaleBlockchainPlatformResponse) })]
    public class InvokeOCIBlockchainPreviewScaleBlockchainPlatform : OCIBlockchainPlatformCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique service identifier.")]
        public string BlockchainPlatformId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Input payload to scaleout blockchain platform. The payload cannot be empty.")]
        public ScaleBlockchainPlatformDetails ScaleBlockchainPlatformDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PreviewScaleBlockchainPlatformRequest request;

            try
            {
                request = new PreviewScaleBlockchainPlatformRequest
                {
                    BlockchainPlatformId = BlockchainPlatformId,
                    ScaleBlockchainPlatformDetails = ScaleBlockchainPlatformDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.PreviewScaleBlockchainPlatform(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ScaledBlockchainPlatformPreview);
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

        private PreviewScaleBlockchainPlatformResponse response;
    }
}
