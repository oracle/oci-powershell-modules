/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181001
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AutoscalingService.Requests;
using Oci.AutoscalingService.Responses;
using Oci.AutoscalingService.Models;
using Oci.Common.Model;

namespace Oci.AutoscalingService.Cmdlets
{
    [Cmdlet("Get", "OCIAutoscalingPolicy")]
    [OutputType(new System.Type[] { typeof(Oci.AutoscalingService.Models.AutoScalingPolicy), typeof(Oci.AutoscalingService.Responses.GetAutoScalingPolicyResponse) })]
    public class GetOCIAutoscalingPolicy : OCIAutoScalingCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the autoscaling configuration.")]
        public string AutoScalingConfigurationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the autoscaling policy.")]
        public string AutoScalingPolicyId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetAutoScalingPolicyRequest request;

            try
            {
                request = new GetAutoScalingPolicyRequest
                {
                    AutoScalingConfigurationId = AutoScalingConfigurationId,
                    AutoScalingPolicyId = AutoScalingPolicyId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetAutoScalingPolicy(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AutoScalingPolicy);
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

        private GetAutoScalingPolicyResponse response;
    }
}
