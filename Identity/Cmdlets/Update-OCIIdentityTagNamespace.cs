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
    [Cmdlet("Update", "OCIIdentityTagNamespace")]
    [OutputType(new System.Type[] { typeof(Oci.IdentityService.Models.TagNamespace), typeof(Oci.IdentityService.Responses.UpdateTagNamespaceResponse) })]
    public class UpdateOCIIdentityTagNamespace : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the tag namespace.")]
        public string TagNamespaceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request object for updating a namespace.")]
        public UpdateTagNamespaceDetails UpdateTagNamespaceDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Whether to override locks (if any exist).")]
        public System.Nullable<bool> IsLockOverride { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateTagNamespaceRequest request;

            try
            {
                request = new UpdateTagNamespaceRequest
                {
                    TagNamespaceId = TagNamespaceId,
                    UpdateTagNamespaceDetails = UpdateTagNamespaceDetails,
                    IsLockOverride = IsLockOverride
                };

                response = client.UpdateTagNamespace(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TagNamespace);
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

        private UpdateTagNamespaceResponse response;
    }
}
