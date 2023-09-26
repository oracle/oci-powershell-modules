/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ArtifactsService.Requests;
using Oci.ArtifactsService.Responses;
using Oci.ArtifactsService.Models;
using Oci.Common.Model;

namespace Oci.ArtifactsService.Cmdlets
{
    [Cmdlet("Update", "OCIArtifactsContainerImage")]
    [OutputType(new System.Type[] { typeof(Oci.ArtifactsService.Models.ContainerImage), typeof(Oci.ArtifactsService.Responses.UpdateContainerImageResponse) })]
    public class UpdateOCIArtifactsContainerImage : OCIArtifactsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the container image.

Example: `ocid1.containerimage.oc1..exampleuniqueID`")]
        public string ImageId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Update container image details.")]
        public UpdateContainerImageDetails UpdateContainerImageDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateContainerImageRequest request;

            try
            {
                request = new UpdateContainerImageRequest
                {
                    ImageId = ImageId,
                    UpdateContainerImageDetails = UpdateContainerImageDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateContainerImage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ContainerImage);
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

        private UpdateContainerImageResponse response;
    }
}