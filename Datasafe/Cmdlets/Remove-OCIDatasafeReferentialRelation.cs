/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatasafeService.Requests;
using Oci.DatasafeService.Responses;
using Oci.DatasafeService.Models;
using Oci.Common.Model;

namespace Oci.DatasafeService.Cmdlets
{
    [Cmdlet("Remove", "OCIDatasafeReferentialRelation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.DatasafeService.Responses.DeleteReferentialRelationResponse) })]
    public class RemoveOCIDatasafeReferentialRelation : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the sensitive data model.")]
        public string SensitiveDataModelId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique key that identifies the referential relation. It's numeric and unique within a sensitive data model.")]
        public string ReferentialRelationKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIDatasafeReferentialRelation", "Remove"))
            {
               return;
            }

            DeleteReferentialRelationRequest request;

            try
            {
                request = new DeleteReferentialRelationRequest
                {
                    SensitiveDataModelId = SensitiveDataModelId,
                    ReferentialRelationKey = ReferentialRelationKey,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.DeleteReferentialRelation(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private DeleteReferentialRelationResponse response;
    }
}
