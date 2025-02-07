/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210610
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.JmsService.Requests;
using Oci.JmsService.Responses;
using Oci.JmsService.Models;
using Oci.Common.Model;

namespace Oci.JmsService.Cmdlets
{
    [Cmdlet("Update", "OCIJmsPlugin")]
    [OutputType(new System.Type[] { typeof(Oci.JmsService.Models.JmsPlugin), typeof(Oci.JmsService.Responses.UpdateJmsPluginResponse) })]
    public class UpdateOCIJmsPlugin : OCIJavaManagementServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the JmsPlugin.")]
        public string JmsPluginId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The new details for the JmsPlugin.")]
        public UpdateJmsPluginDetails UpdateJmsPluginDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the ETag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the ETag you provide matches the resource's current ETag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateJmsPluginRequest request;

            try
            {
                request = new UpdateJmsPluginRequest
                {
                    JmsPluginId = JmsPluginId,
                    UpdateJmsPluginDetails = UpdateJmsPluginDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateJmsPlugin(request).GetAwaiter().GetResult();
                WriteOutput(response, response.JmsPlugin);
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

        private UpdateJmsPluginResponse response;
    }
}
