/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210224
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CertificatesService.Requests;
using Oci.CertificatesService.Responses;
using Oci.CertificatesService.Models;
using Oci.Common.Model;

namespace Oci.CertificatesService.Cmdlets
{
    [Cmdlet("Get", "OCICertificatesCertificateBundleVersionsList")]
    [OutputType(new System.Type[] { typeof(Oci.CertificatesService.Models.CertificateBundleVersionCollection), typeof(Oci.CertificatesService.Responses.ListCertificateBundleVersionsResponse) })]
    public class GetOCICertificatesCertificateBundleVersionsList : OCICertificatesCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the certificate.")]
        public string CertificateId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can specify only one sort order. The default order for `VERSION_NUMBER` is ascending.")]
        public System.Nullable<Oci.CertificatesService.Requests.ListCertificateBundleVersionsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`).")]
        public System.Nullable<Oci.CertificatesService.Requests.ListCertificateBundleVersionsRequest.SortOrderEnum> SortOrder { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListCertificateBundleVersionsRequest request;

            try
            {
                request = new ListCertificateBundleVersionsRequest
                {
                    CertificateId = CertificateId,
                    OpcRequestId = OpcRequestId,
                    SortBy = SortBy,
                    SortOrder = SortOrder
                };

                response = client.ListCertificateBundleVersions(request).GetAwaiter().GetResult();
                WriteOutput(response, response.CertificateBundleVersionCollection);
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

        private ListCertificateBundleVersionsResponse response;
    }
}
