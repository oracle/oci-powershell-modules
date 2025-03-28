/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Responses;
using Oci.ObjectstorageService.Models;
using Oci.Common.Model;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("Get", "OCIObjectstorageBucket")]
    [OutputType(new System.Type[] { typeof(Oci.ObjectstorageService.Models.Bucket), typeof(Oci.ObjectstorageService.Responses.GetBucketResponse) })]
    public class GetOCIObjectstorageBucket : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to match with the ETag of an existing resource. If the specified ETag matches the ETag of the existing resource, GET and HEAD requests will return the resource and PUT and POST requests will upload the resource.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to avoid matching. Wildcards ('*') are not allowed. If the specified ETag does not match the ETag of the existing resource, the request returns the expected response. If the ETag matches the ETag of the existing resource, the request returns an HTTP 304 status without a response body.")]
        public string IfNoneMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Bucket summary includes the 'namespace', 'name', 'compartmentId', 'createdBy', 'timeCreated', and 'etag' fields. This parameter can also include 'approximateCount' (approximate number of objects), 'approximateSize' (total approximate size in bytes of all objects) and 'autoTiering' (state of auto tiering on the bucket). For example 'approximateCount,approximateSize,autoTiering'.")]
        public System.Collections.Generic.List<Oci.ObjectstorageService.Requests.GetBucketRequest.FieldsEnum> Fields { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetBucketRequest request;

            try
            {
                request = new GetBucketRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    IfMatch = IfMatch,
                    IfNoneMatch = IfNoneMatch,
                    OpcClientRequestId = OpcClientRequestId,
                    Fields = Fields
                };

                response = client.GetBucket(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Bucket);
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

        private GetBucketResponse response;
    }
}
