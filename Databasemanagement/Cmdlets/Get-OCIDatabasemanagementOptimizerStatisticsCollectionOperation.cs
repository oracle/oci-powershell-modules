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
    [Cmdlet("Get", "OCIDatabasemanagementOptimizerStatisticsCollectionOperation")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.OptimizerStatisticsCollectionOperation), typeof(Oci.DatabasemanagementService.Responses.GetOptimizerStatisticsCollectionOperationResponse) })]
    public class GetOCIDatabasemanagementOptimizerStatisticsCollectionOperation : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the Optimizer Statistics Collection operation.")]
        public System.Nullable<decimal> OptimizerStatisticsCollectionOperationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the Named Credential.")]
        public string OpcNamedCredentialId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOptimizerStatisticsCollectionOperationRequest request;

            try
            {
                request = new GetOptimizerStatisticsCollectionOperationRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    OptimizerStatisticsCollectionOperationId = OptimizerStatisticsCollectionOperationId,
                    OpcRequestId = OpcRequestId,
                    OpcNamedCredentialId = OpcNamedCredentialId
                };

                response = client.GetOptimizerStatisticsCollectionOperation(request).GetAwaiter().GetResult();
                WriteOutput(response, response.OptimizerStatisticsCollectionOperation);
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

        private GetOptimizerStatisticsCollectionOperationResponse response;
    }
}
