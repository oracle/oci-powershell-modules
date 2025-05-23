/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.HealthchecksService.Requests;
using Oci.HealthchecksService.Responses;
using Oci.HealthchecksService.Models;
using Oci.Common.Model;

namespace Oci.HealthchecksService.Cmdlets
{
    [Cmdlet("New", "OCIHealthchecksOnDemandHttpProbe")]
    [OutputType(new System.Type[] { typeof(Oci.HealthchecksService.Models.HttpProbe), typeof(Oci.HealthchecksService.Responses.CreateOnDemandHttpProbeResponse) })]
    public class NewOCIHealthchecksOnDemandHttpProbe : OCIHealthChecksCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The configuration of the HTTP probe.")]
        public CreateOnDemandHttpProbeDetails CreateOnDemandHttpProbeDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateOnDemandHttpProbeRequest request;

            try
            {
                request = new CreateOnDemandHttpProbeRequest
                {
                    CreateOnDemandHttpProbeDetails = CreateOnDemandHttpProbeDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateOnDemandHttpProbe(request).GetAwaiter().GetResult();
                WriteOutput(response, response.HttpProbe);
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

        private CreateOnDemandHttpProbeResponse response;
    }
}
