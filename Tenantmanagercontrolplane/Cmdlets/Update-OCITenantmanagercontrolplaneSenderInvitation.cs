/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230401
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.TenantmanagercontrolplaneService.Requests;
using Oci.TenantmanagercontrolplaneService.Responses;
using Oci.TenantmanagercontrolplaneService.Models;
using Oci.Common.Model;

namespace Oci.TenantmanagercontrolplaneService.Cmdlets
{
    [Cmdlet("Update", "OCITenantmanagercontrolplaneSenderInvitation")]
    [OutputType(new System.Type[] { typeof(Oci.TenantmanagercontrolplaneService.Models.SenderInvitation), typeof(Oci.TenantmanagercontrolplaneService.Responses.UpdateSenderInvitationResponse) })]
    public class UpdateOCITenantmanagercontrolplaneSenderInvitation : OCISenderInvitationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the sender invitation to update.")]
        public string SenderInvitationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The information to be updated.")]
        public UpdateSenderInvitationDetails UpdateSenderInvitationDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateSenderInvitationRequest request;

            try
            {
                request = new UpdateSenderInvitationRequest
                {
                    SenderInvitationId = SenderInvitationId,
                    UpdateSenderInvitationDetails = UpdateSenderInvitationDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateSenderInvitation(request).GetAwaiter().GetResult();
                WriteOutput(response, response.SenderInvitation);
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

        private UpdateSenderInvitationResponse response;
    }
}
