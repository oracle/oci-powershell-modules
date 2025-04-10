/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210330
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.StackmonitoringService.Requests;
using Oci.StackmonitoringService.Responses;
using Oci.StackmonitoringService.Models;
using Oci.Common.Model;

namespace Oci.StackmonitoringService.Cmdlets
{
    [Cmdlet("Update", "OCIStackmonitoringConfig")]
    [OutputType(new System.Type[] { typeof(Oci.StackmonitoringService.Models.Config), typeof(Oci.StackmonitoringService.Responses.UpdateConfigResponse) })]
    public class UpdateOCIStackmonitoringConfig : OCIStackMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Config identifier.")]
        public string ConfigId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the configuration to be updated. This parameter also accepts subtypes <Oci.StackmonitoringService.Models.UpdateComputeAutoActivatePluginConfigDetails>, <Oci.StackmonitoringService.Models.UpdateLicenseEnterpriseExtensibilityConfigDetails>, <Oci.StackmonitoringService.Models.UpdateAutoPromoteConfigDetails>, <Oci.StackmonitoringService.Models.UpdateLicenseAutoAssignConfigDetails>, <Oci.StackmonitoringService.Models.UpdateOnboardConfigDetails> of type <Oci.StackmonitoringService.Models.UpdateConfigDetails>.")]
        public UpdateConfigDetails UpdateConfigDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateConfigRequest request;

            try
            {
                request = new UpdateConfigRequest
                {
                    ConfigId = ConfigId,
                    UpdateConfigDetails = UpdateConfigDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateConfig(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Config);
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

        private UpdateConfigResponse response;
    }
}
