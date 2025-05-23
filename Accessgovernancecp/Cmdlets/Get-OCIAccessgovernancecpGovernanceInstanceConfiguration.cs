/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220518
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AccessgovernancecpService.Requests;
using Oci.AccessgovernancecpService.Responses;
using Oci.AccessgovernancecpService.Models;
using Oci.Common.Model;

namespace Oci.AccessgovernancecpService.Cmdlets
{
    [Cmdlet("Get", "OCIAccessgovernancecpGovernanceInstanceConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.AccessgovernancecpService.Models.GovernanceInstanceConfiguration), typeof(Oci.AccessgovernancecpService.Responses.GetGovernanceInstanceConfigurationResponse) })]
    public class GetOCIAccessgovernancecpGovernanceInstanceConfiguration : OCIAccessGovernanceCPCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment in which resources are listed.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetGovernanceInstanceConfigurationRequest request;

            try
            {
                request = new GetGovernanceInstanceConfigurationRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetGovernanceInstanceConfiguration(request).GetAwaiter().GetResult();
                WriteOutput(response, response.GovernanceInstanceConfiguration);
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

        private GetGovernanceInstanceConfigurationResponse response;
    }
}
