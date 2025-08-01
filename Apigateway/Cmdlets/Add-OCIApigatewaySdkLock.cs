/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ApigatewayService.Requests;
using Oci.ApigatewayService.Responses;
using Oci.ApigatewayService.Models;
using Oci.Common.Model;

namespace Oci.ApigatewayService.Cmdlets
{
    [Cmdlet("Add", "OCIApigatewaySdkLock")]
    [OutputType(new System.Type[] { typeof(Oci.ApigatewayService.Models.Sdk), typeof(Oci.ApigatewayService.Responses.AddSdkLockResponse) })]
    public class AddOCIApigatewaySdkLock : OCIApiGatewayCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ocid of the SDK.")]
        public string SdkId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"AddResourceLockDetails body parameter")]
        public AddResourceLockDetails AddResourceLockDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            AddSdkLockRequest request;

            try
            {
                request = new AddSdkLockRequest
                {
                    SdkId = SdkId,
                    AddResourceLockDetails = AddResourceLockDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.AddSdkLock(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Sdk);
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

        private AddSdkLockResponse response;
    }
}
