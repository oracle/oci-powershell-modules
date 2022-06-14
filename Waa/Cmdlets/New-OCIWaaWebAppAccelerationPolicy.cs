/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20211230
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.WaaService.Requests;
using Oci.WaaService.Responses;
using Oci.WaaService.Models;
using Oci.Common.Model;

namespace Oci.WaaService.Cmdlets
{
    [Cmdlet("New", "OCIWaaWebAppAccelerationPolicy")]
    [OutputType(new System.Type[] { typeof(Oci.WaaService.Models.WebAppAccelerationPolicy), typeof(Oci.WaaService.Responses.CreateWebAppAccelerationPolicyResponse) })]
    public class NewOCIWaaWebAppAccelerationPolicy : OCIWaaCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the new WebAppAccelerationPolicy.")]
        public CreateWebAppAccelerationPolicyDetails CreateWebAppAccelerationPolicyDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateWebAppAccelerationPolicyRequest request;

            try
            {
                request = new CreateWebAppAccelerationPolicyRequest
                {
                    CreateWebAppAccelerationPolicyDetails = CreateWebAppAccelerationPolicyDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateWebAppAccelerationPolicy(request).GetAwaiter().GetResult();
                WriteOutput(response, response.WebAppAccelerationPolicy);
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

        private CreateWebAppAccelerationPolicyResponse response;
    }
}