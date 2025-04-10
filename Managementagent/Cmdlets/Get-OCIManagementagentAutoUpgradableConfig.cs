/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200202
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ManagementagentService.Requests;
using Oci.ManagementagentService.Responses;
using Oci.ManagementagentService.Models;
using Oci.Common.Model;

namespace Oci.ManagementagentService.Cmdlets
{
    [Cmdlet("Get", "OCIManagementagentAutoUpgradableConfig")]
    [OutputType(new System.Type[] { typeof(Oci.ManagementagentService.Models.AutoUpgradableConfig), typeof(Oci.ManagementagentService.Responses.GetAutoUpgradableConfigResponse) })]
    public class GetOCIManagementagentAutoUpgradableConfig : OCIManagementAgentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment to which a request will be scoped.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAutoUpgradableConfigRequest request;

            try
            {
                request = new GetAutoUpgradableConfigRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAutoUpgradableConfig(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AutoUpgradableConfig);
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

        private GetAutoUpgradableConfigResponse response;
    }
}
