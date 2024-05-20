/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.MarketplaceprivateofferService.Requests;
using Oci.MarketplaceprivateofferService.Responses;
using Oci.MarketplaceprivateofferService.Models;
using Oci.Common.Model;

namespace Oci.MarketplaceprivateofferService.Cmdlets
{
    [Cmdlet("Get", "OCIMarketplaceprivateofferOfferInternalDetail")]
    [OutputType(new System.Type[] { typeof(Oci.MarketplaceprivateofferService.Models.OfferInternalDetail), typeof(Oci.MarketplaceprivateofferService.Responses.GetOfferInternalDetailResponse) })]
    public class GetOCIMarketplaceprivateofferOfferInternalDetail : OCIOfferCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"unique Offer identifier")]
        public string OfferId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetOfferInternalDetailRequest request;

            try
            {
                request = new GetOfferInternalDetailRequest
                {
                    OfferId = OfferId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetOfferInternalDetail(request).GetAwaiter().GetResult();
                WriteOutput(response, response.OfferInternalDetail);
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

        private GetOfferInternalDetailResponse response;
    }
}