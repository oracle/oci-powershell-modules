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
    [Cmdlet("Update", "OCIManagementagentInstallKey")]
    [OutputType(new System.Type[] { typeof(Oci.ManagementagentService.Models.ManagementAgentInstallKey), typeof(Oci.ManagementagentService.Responses.UpdateManagementAgentInstallKeyResponse) })]
    public class UpdateOCIManagementagentInstallKey : OCIManagementAgentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Management Agent Install Key identifier")]
        public string ManagementAgentInstallKeyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details required for changing the modifiable properties of the Management Agent install key.")]
        public UpdateManagementAgentInstallKeyDetails UpdateManagementAgentInstallKeyDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateManagementAgentInstallKeyRequest request;

            try
            {
                request = new UpdateManagementAgentInstallKeyRequest
                {
                    ManagementAgentInstallKeyId = ManagementAgentInstallKeyId,
                    UpdateManagementAgentInstallKeyDetails = UpdateManagementAgentInstallKeyDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateManagementAgentInstallKey(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ManagementAgentInstallKey);
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

        private UpdateManagementAgentInstallKeyResponse response;
    }
}
