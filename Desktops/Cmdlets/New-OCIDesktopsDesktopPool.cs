/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220618
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DesktopsService.Requests;
using Oci.DesktopsService.Responses;
using Oci.DesktopsService.Models;
using Oci.Common.Model;

namespace Oci.DesktopsService.Cmdlets
{
    [Cmdlet("New", "OCIDesktopsDesktopPool")]
    [OutputType(new System.Type[] { typeof(Oci.DesktopsService.Models.DesktopPool), typeof(Oci.DesktopsService.Responses.CreateDesktopPoolResponse) })]
    public class NewOCIDesktopsDesktopPool : OCIDesktopServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the desktop pool to create.")]
        public CreateDesktopPoolDetails CreateDesktopPoolDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier of the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDesktopPoolRequest request;

            try
            {
                request = new CreateDesktopPoolRequest
                {
                    CreateDesktopPoolDetails = CreateDesktopPoolDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateDesktopPool(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DesktopPool);
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

        private CreateDesktopPoolResponse response;
    }
}
