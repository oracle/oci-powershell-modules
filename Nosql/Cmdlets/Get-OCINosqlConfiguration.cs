/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190828
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.NosqlService.Requests;
using Oci.NosqlService.Responses;
using Oci.NosqlService.Models;
using Oci.Common.Model;

namespace Oci.NosqlService.Cmdlets
{
    [Cmdlet("Get", "OCINosqlConfiguration")]
    [OutputType(new System.Type[] { typeof(Oci.NosqlService.Models.Configuration), typeof(Oci.NosqlService.Responses.GetConfigurationResponse) })]
    public class GetOCINosqlConfiguration : OCINosqlCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of a table's compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetConfigurationRequest request;

            try
            {
                request = new GetConfigurationRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetConfiguration(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Configuration);
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

        private GetConfigurationResponse response;
    }
}
