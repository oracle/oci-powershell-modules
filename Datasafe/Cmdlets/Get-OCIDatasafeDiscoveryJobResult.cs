/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatasafeService.Requests;
using Oci.DatasafeService.Responses;
using Oci.DatasafeService.Models;
using Oci.Common.Model;

namespace Oci.DatasafeService.Cmdlets
{
    [Cmdlet("Get", "OCIDatasafeDiscoveryJobResult")]
    [OutputType(new System.Type[] { typeof(Oci.DatasafeService.Models.DiscoveryJobResult), typeof(Oci.DatasafeService.Responses.GetDiscoveryJobResultResponse) })]
    public class GetOCIDatasafeDiscoveryJobResult : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the discovery job.")]
        public string DiscoveryJobId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique key that identifies the discovery result.")]
        public string ResultKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetDiscoveryJobResultRequest request;

            try
            {
                request = new GetDiscoveryJobResultRequest
                {
                    DiscoveryJobId = DiscoveryJobId,
                    ResultKey = ResultKey,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetDiscoveryJobResult(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DiscoveryJobResult);
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

        private GetDiscoveryJobResultResponse response;
    }
}
