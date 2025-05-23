/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabaseService.Requests;
using Oci.DatabaseService.Responses;
using Oci.DatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DatabaseService.Cmdlets
{
    [Cmdlet("Get", "OCIDatabaseCloudAutonomousVmClusterResourceUsage")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.CloudAutonomousVmClusterResourceUsage), typeof(Oci.DatabaseService.Responses.GetCloudAutonomousVmClusterResourceUsageResponse) })]
    public class GetOCIDatabaseCloudAutonomousVmClusterResourceUsage : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Cloud VM cluster [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm).")]
        public string CloudAutonomousVmClusterId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetCloudAutonomousVmClusterResourceUsageRequest request;

            try
            {
                request = new GetCloudAutonomousVmClusterResourceUsageRequest
                {
                    CloudAutonomousVmClusterId = CloudAutonomousVmClusterId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetCloudAutonomousVmClusterResourceUsage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CloudAutonomousVmClusterResourceUsage);
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

        private GetCloudAutonomousVmClusterResourceUsageResponse response;
    }
}
