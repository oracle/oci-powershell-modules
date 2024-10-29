/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20240815
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.SecurityattributeService.Requests;
using Oci.SecurityattributeService.Responses;
using Oci.SecurityattributeService.Models;
using Oci.Common.Model;

namespace Oci.SecurityattributeService.Cmdlets
{
    [Cmdlet("New", "OCISecurityattribute")]
    [OutputType(new System.Type[] { typeof(Oci.SecurityattributeService.Models.SecurityAttribute), typeof(Oci.SecurityattributeService.Responses.CreateSecurityAttributeResponse) })]
    public class NewOCISecurityattribute : OCISecurityAttributeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the security attribute namespace.")]
        public string SecurityAttributeNamespaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for creating a new security attribute in the specified security attribute namespace.")]
        public CreateSecurityAttributeDetails CreateSecurityAttributeDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID. The only valid characters for request IDs are letters, numbers, underscore, and dash.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of running that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and removed from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateSecurityAttributeRequest request;

            try
            {
                request = new CreateSecurityAttributeRequest
                {
                    SecurityAttributeNamespaceId = SecurityAttributeNamespaceId,
                    CreateSecurityAttributeDetails = CreateSecurityAttributeDetails,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateSecurityAttribute(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SecurityAttribute);
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

        private CreateSecurityAttributeResponse response;
    }
}