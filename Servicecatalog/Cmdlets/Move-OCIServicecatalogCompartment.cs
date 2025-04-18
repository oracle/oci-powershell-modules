/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210527
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ServicecatalogService.Requests;
using Oci.ServicecatalogService.Responses;
using Oci.ServicecatalogService.Models;
using Oci.Common.Model;

namespace Oci.ServicecatalogService.Cmdlets
{
    [Cmdlet("Move", "OCIServicecatalogCompartment")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.ServicecatalogService.Responses.ChangeServiceCatalogCompartmentResponse) })]
    public class MoveOCIServicecatalogCompartment : OCIServiceCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique identifier for the service catalog.")]
        public string ServiceCatalogId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details of the request to change the compartment of a given service catalog.")]
        public ChangeServiceCatalogCompartmentDetails ChangeServiceCatalogCompartmentDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource.  The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ChangeServiceCatalogCompartmentRequest request;

            try
            {
                request = new ChangeServiceCatalogCompartmentRequest
                {
                    ServiceCatalogId = ServiceCatalogId,
                    ChangeServiceCatalogCompartmentDetails = ChangeServiceCatalogCompartmentDetails,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch
                };

                response = client.ChangeServiceCatalogCompartment(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private ChangeServiceCatalogCompartmentResponse response;
    }
}
