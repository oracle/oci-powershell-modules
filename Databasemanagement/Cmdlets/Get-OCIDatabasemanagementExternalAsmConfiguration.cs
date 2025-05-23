/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;
using Oci.Common.Model;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabasemanagementExternalAsmConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.ExternalAsmConfiguration), typeof(Oci.DatabasemanagementService.Responses.GetExternalAsmConfigurationResponse) })]
    public class GetOCIDatabasemanagementExternalAsmConfiguration : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the external ASM.")]
        public string ExternalAsmId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the Named Credential.")]
        public string OpcNamedCredentialId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetExternalAsmConfigurationRequest request;

            try
            {
                request = new GetExternalAsmConfigurationRequest
                {
                    ExternalAsmId = ExternalAsmId,
                    OpcRequestId = OpcRequestId,
                    OpcNamedCredentialId = OpcNamedCredentialId
                };

                response = client.GetExternalAsmConfiguration(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ExternalAsmConfiguration);
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

        private GetExternalAsmConfigurationResponse response;
    }
}
