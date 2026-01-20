/*
 * Copyright (c) 2020, 2026, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ObjectstorageService.Requests;
using Oci.ObjectstorageService.Transfer;

namespace Oci.ObjectstorageService.Cmdlets
{
    [Cmdlet("Write", "OCIObjectstorageuploadmanagerObject")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.ObjectstorageService.Responses.PutObjectResponse) })]
    public class WriteOCIObjectstorageuploadmanagerObject : OCIObjectStorageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Object Storage namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the bucket. Avoid entering confidential information. Example: `my-new-bucket1`")]
        public string BucketName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the object. Avoid entering confidential information. Example: `test/object1.log`")]
        public string ObjectName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The content length of the body.")]
        public System.Nullable<long> ContentLength { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The object to upload to the object store.", ParameterSetName = FromStreamSet)]
        public System.IO.Stream PutObjectBody { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Use this parameter to provide the file location from where the input stream to be read. The object to upload to the object store.", ParameterSetName = FromFileSet)]
        public String PutObjectBodyFromFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to match with the ETag of an existing resource. If the specified ETag matches the ETag of the existing resource, GET and HEAD requests will return the resource and PUT and POST requests will upload the resource.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity tag (ETag) to avoid matching. The only valid value is '*', which indicates that the request should fail if the resource already exists.")]
        public string IfNoneMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcClientRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"100-continue")]
        public string Expect { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional base-64 header that defines the encoded MD5 hash of the body. If the optional Content-MD5 header is present, Object Storage performs an integrity check on the body of the HTTP request by computing the MD5 hash for the body and comparing it to the MD5 hash supplied in the header. If the two hashes do not match, the object is rejected and an HTTP-400 Unmatched Content MD5 error is returned with the message:
        ""The computed MD5 of the request body (ACTUAL_MD5) does not match the Content-MD5 header (HEADER_MD5)""")]
        public string ContentMD5 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional Content-Type header that defines the standard MIME type format of the object. Content type defaults to 'application/octet-stream' if not specified in the PutObject call. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to identify and perform special operations on text only objects.")]
        public string ContentType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional Content-Language header that defines the content language of the object to upload. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to identify and differentiate objects based on a particular language.")]
        public string ContentLanguage { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional Content-Encoding header that defines the content encodings that were applied to the object to upload. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to determine what decoding mechanisms need to be applied to obtain the media-type specified by the Content-Type header of the object.")]
        public string ContentEncoding { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional Content-Disposition header that defines presentational information for the object to be returned in GetObject and HeadObject responses. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to let users download objects with custom filenames in a browser.")]
        public string ContentDisposition { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional Cache-Control header that defines the caching behavior value to be returned in GetObject and HeadObject responses. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to identify objects that require caching restrictions.")]
        public string CacheControl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies ""AES256"" as the encryption algorithm. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerAlgorithm { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies the base64-encoded 256-bit encryption key to use to encrypt or decrypt the data. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The optional header that specifies the base64-encoded SHA256 hash of the encryption key. This value is used to check the integrity of the encryption key. For more information, see [Using Your Own Keys for Server-Side Encryption](https://docs.cloud.oracle.com/Content/Object/Tasks/usingyourencryptionkeys.htm).")]
        public string OpcSseCustomerKeySha256 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The storage tier that the object should be stored in. If not specified, the object will be stored in the same storage tier as the bucket.")]
        public System.Nullable<Oci.ObjectstorageService.Models.StorageTier> StorageTier { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Optional user-defined metadata key and value.")]
        public System.Collections.Generic.Dictionary<string, string> OpcMeta { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Length in MiB for each part of a multi-part upload. Default is 128.")]
        [ValidateRange(MINIMUM_ALLOWED_LENGTH_PER_PART_MB, MAXIMUM_ALLOWED_LENGTH_PER_PART_MB)]
        public long LengthPerUploadPartInMiB { get; set; } = DEFAULT_LENGTH_PER_UPLOAD_PART;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Flag to indicate that multi-part uploads can be used. Default is true.")]
        public bool AllowMultipartUploads { get; set; } = true;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The number of worker threads to use in parallel for uploading individual parts of a multipart upload. Defaults value is  3. Users can disable parallel part uploads by setting this value to 1.")]
        public int ParallelUploadCount { get; set; } = DEFAULT_PARALLEL_THREADS;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Flag to indicate that failed uploads should not be automatically aborted.")]
        public SwitchParameter DisableAutoAbort { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Flag to indicate that MD5 should be set on every part of a multi-part upload. The MD5 is calculated before uploading for each part it creates.")]
        public SwitchParameter EnforceMd5MultipartUpload { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Flag to indicate that MD5 should be set on every PutObject call. If not provided, it is calculated automatically before uploading the object.")]
        public SwitchParameter EnforceMd5Upload { get; set; }

        public const long MINIMUM_ALLOWED_LENGTH_PER_PART_MB = 1L; // 1 MiB
        public const long MAXIMUM_ALLOWED_LENGTH_PER_PART_MB = 50L * 1024L; // 50 GiB
        public const long DEFAULT_LENGTH_PER_UPLOAD_PART = 128;
        public const int DEFAULT_PARALLEL_THREADS = 3;

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PutObjectRequest request;
            UploadManager uploadManager;
            UploadManager.UploadRequest uploadRequest;
            UploadConfiguration uploadConfiguration;

            if (ParameterSetName.Equals(FromFileSet))
            {
                PutObjectBody = System.IO.File.OpenRead(GetAbsoluteFilePath(PutObjectBodyFromFile));
            }

            try
            {
                request = new PutObjectRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    ObjectName = ObjectName,
                    ContentLength = ContentLength,
                    PutObjectBody = PutObjectBody,
                    IfMatch = IfMatch,
                    IfNoneMatch = IfNoneMatch,
                    OpcClientRequestId = OpcClientRequestId,
                    Expect = Expect,
                    ContentMD5 = ContentMD5,
                    ContentType = ContentType,
                    ContentLanguage = ContentLanguage,
                    ContentEncoding = ContentEncoding,
                    ContentDisposition = ContentDisposition,
                    CacheControl = CacheControl,
                    OpcSseCustomerAlgorithm = OpcSseCustomerAlgorithm,
                    OpcSseCustomerKey = OpcSseCustomerKey,
                    OpcSseCustomerKeySha256 = OpcSseCustomerKeySha256,
                    StorageTier = StorageTier,
                    OpcMeta = OpcMeta
                };

                uploadConfiguration = new UploadConfiguration
                {
                    LengthPerUploadPartInMiB = LengthPerUploadPartInMiB,
                    AllowMultipartUploads = AllowMultipartUploads,
                    ParallelUploadCount = ParallelUploadCount,
                    DisableAutoAbort = DisableAutoAbort,
                    EnforceMd5MultipartUpload = EnforceMd5MultipartUpload,
                    EnforceMd5Upload = EnforceMd5Upload
                };

                uploadManager = new UploadManager(client, uploadConfiguration);
                uploadRequest = new UploadManager.UploadRequest(request);

                uploadResponse = uploadManager.Upload(uploadRequest).GetAwaiter().GetResult();
                WriteOutput(uploadResponse);
                FinishProcessing(uploadResponse);
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

        private UploadManager.UploadResponse uploadResponse;
        private const string FromFileSet = "FromFile";
        private const string FromStreamSet = "FromStream";
    }
}
