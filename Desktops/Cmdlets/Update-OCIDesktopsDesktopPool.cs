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
    [Cmdlet("Update", "OCIDesktopsDesktopPool")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.DesktopsService.Responses.UpdateDesktopPoolResponse) })]
    public class UpdateOCIDesktopsDesktopPool : OCIDesktopServiceCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the desktop pool.")]
        public string DesktopPoolId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the update.")]
        public UpdateDesktopPoolDetails UpdateDesktopPoolDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier of the request.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateDesktopPoolRequest request;

            try
            {
                request = new UpdateDesktopPoolRequest
                {
                    DesktopPoolId = DesktopPoolId,
                    UpdateDesktopPoolDetails = UpdateDesktopPoolDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.UpdateDesktopPool(request).GetAwaiter().GetResult();
                WriteOutput(response, CreateWorkRequestObject(response.OpcWorkRequestId));
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

        private UpdateDesktopPoolResponse response;
    }
}
