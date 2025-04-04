/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.IdentityService.Requests;
using Oci.IdentityService.Responses;
using Oci.IdentityService.Models;
using Oci.Common.Model;

namespace Oci.IdentityService.Cmdlets
{
    [Cmdlet("New", "OCIIdentityDynamicGroup")]
    [OutputType(new System.Type[] { typeof(Oci.IdentityService.Models.DynamicGroup), typeof(Oci.IdentityService.Responses.CreateDynamicGroupResponse) })]
    public class NewOCIIdentityDynamicGroup : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for creating a new dynamic group.")]
        public CreateDynamicGroupDetails CreateDynamicGroupDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDynamicGroupRequest request;

            try
            {
                request = new CreateDynamicGroupRequest
                {
                    CreateDynamicGroupDetails = CreateDynamicGroupDetails,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.CreateDynamicGroup(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DynamicGroup);
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

        private CreateDynamicGroupResponse response;
    }
}
