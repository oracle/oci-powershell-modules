/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.GenericartifactscontentService.Requests;
using Oci.GenericartifactscontentService.Responses;
using Oci.GenericartifactscontentService.Models;
using Oci.Common.Model;

namespace Oci.GenericartifactscontentService.Cmdlets
{
    [Cmdlet("Write", "OCIGenericartifactscontentGenericArtifactContentByPath")]
    [OutputType(new System.Type[] { typeof(Oci.GenericartifactscontentService.Models.GenericArtifact), typeof(Oci.GenericartifactscontentService.Responses.PutGenericArtifactContentByPathResponse) })]
    public class WriteOCIGenericartifactscontentGenericArtifactContentByPath : OCIGenericArtifactsContentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the repository.

Example: `ocid1.repository.oc1..exampleuniqueID`")]
        public string RepositoryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"A user-defined path to describe the location of an artifact. You can use slashes to organize the repository, but slashes do not create a directory structure. An artifact path does not include an artifact version.

Example: `project01/my-web-app/artifact-abc`")]
        public string ArtifactPath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"A user-defined string to describe the artifact version.

Example: `1.1.2` or `1.2-beta-2`")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Uploads an artifact. Provide artifact path, version and content. Avoid entering confidential information when you define the path and version.", ParameterSetName = FromStreamSet)]
        public System.IO.Stream GenericArtifactContentBody { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Use this parameter to provide the file location from where the input stream to be read. Uploads an artifact. Provide artifact path, version and content. Avoid entering confidential information when you define the path and version.", ParameterSetName = FromFileSet)]
        public String GenericArtifactContentBodyFromFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the `etag` from a previous GET or POST response for that resource.  The resource will be updated or deleted only if the `etag` you provide matches the resource's current `etag` value. When 'if-match' is provided and its value does not exactly match the 'etag' of the resource on the server, the request fails with the 412 response code.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned [request ID](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm)

Example: `bxxxxxxx-fxxx-4xxx-9xxx-bxxxxxxxxxxx` If you contact Oracle about a request, provide this request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PutGenericArtifactContentByPathRequest request;

            if (ParameterSetName.Equals(FromFileSet))
            {
                GenericArtifactContentBody = System.IO.File.OpenRead(GetAbsoluteFilePath(GenericArtifactContentBodyFromFile));
            }
            

            try
            {
                request = new PutGenericArtifactContentByPathRequest
                {
                    RepositoryId = RepositoryId,
                    ArtifactPath = ArtifactPath,
                    Version = Version,
                    GenericArtifactContentBody = GenericArtifactContentBody,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.PutGenericArtifactContentByPath(request).GetAwaiter().GetResult();
                WriteOutput(response, response.GenericArtifact);
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

        private PutGenericArtifactContentByPathResponse response;
        private const string FromFileSet = "FromFile";
        private const string FromStreamSet = "FromStream";
    }
}
