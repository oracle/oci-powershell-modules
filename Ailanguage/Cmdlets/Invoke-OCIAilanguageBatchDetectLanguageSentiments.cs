/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20221001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AilanguageService.Requests;
using Oci.AilanguageService.Responses;
using Oci.AilanguageService.Models;
using Oci.Common.Model;

namespace Oci.AilanguageService.Cmdlets
{
    [Cmdlet("Invoke", "OCIAilanguageBatchDetectLanguageSentiments")]
    [OutputType(new System.Type[] { typeof(Oci.AilanguageService.Models.BatchDetectLanguageSentimentsResult), typeof(Oci.AilanguageService.Responses.BatchDetectLanguageSentimentsResponse) })]
    public class InvokeOCIAilanguageBatchDetectLanguageSentiments : OCIAIServiceLanguageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details to make sentiment detect call.")]
        public BatchDetectLanguageSentimentsDetails BatchDetectLanguageSentimentsDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Set this parameter for sentence and aspect level sentiment analysis. Allowed values are:    - ASPECT    - SENTENCE")]
        public System.Collections.Generic.List<Oci.AilanguageService.Requests.BatchDetectLanguageSentimentsRequest.LevelEnum> Level { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            BatchDetectLanguageSentimentsRequest request;

            try
            {
                request = new BatchDetectLanguageSentimentsRequest
                {
                    BatchDetectLanguageSentimentsDetails = BatchDetectLanguageSentimentsDetails,
                    OpcRequestId = OpcRequestId,
                    Level = Level
                };

                response = client.BatchDetectLanguageSentiments(request).GetAwaiter().GetResult();
                WriteOutput(response, response.BatchDetectLanguageSentimentsResult);
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

        private BatchDetectLanguageSentimentsResponse response;
    }
}
