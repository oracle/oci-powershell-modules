/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CoreService.Requests;
using Oci.CoreService.Responses;
using Oci.CoreService.Models;
using Oci.Common.Model;

namespace Oci.CoreService.Cmdlets
{
    [Cmdlet("Get", "OCIComputeManagementInstanceConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.CoreService.Models.InstanceConfiguration), typeof(Oci.CoreService.Responses.GetInstanceConfigurationResponse) })]
    public class GetOCIComputeManagementInstanceConfiguration : OCIComputeManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the instance configuration.")]
        public string InstanceConfigurationId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetInstanceConfigurationRequest request;

            try
            {
                request = new GetInstanceConfigurationRequest
                {
                    InstanceConfigurationId = InstanceConfigurationId
                };

                response = client.GetInstanceConfiguration(request).GetAwaiter().GetResult();
                WriteOutput(response, response.InstanceConfiguration);
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

        private GetInstanceConfigurationResponse response;
    }
}
