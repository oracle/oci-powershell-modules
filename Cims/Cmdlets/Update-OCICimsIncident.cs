/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181231
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CimsService.Requests;
using Oci.CimsService.Responses;
using Oci.CimsService.Models;
using Oci.Common.Model;

namespace Oci.CimsService.Cmdlets
{
    [Cmdlet("Update", "OCICimsIncident")]
    [OutputType(new System.Type[] { typeof(Oci.CimsService.Models.Incident), typeof(Oci.CimsService.Responses.UpdateIncidentResponse) })]
    public class UpdateOCICimsIncident : OCIIncidentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the support ticket.")]
        public string IncidentKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details about the support ticket being updated.")]
        public UpdateIncident UpdateIncidentDetails { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the tenancy.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Customer Support Identifier (CSI) number associated with the support account. The CSI is optional for all support request types.")]
        public string Csi { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"User OCID for Oracle Identity Cloud Service (IDCS) users who also have a federated Oracle Cloud Infrastructure account. User OCID is mandatory for OCI Users and optional for Multicloud users.")]
        public string Ocid { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The region of the tenancy.")]
        public string Homeregion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Token type that determine which cloud provider the request come from.")]
        public string Bearertokentype { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Token that provided by multi cloud provider, which help to validate the email.")]
        public string Bearertoken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"IdToken that provided by multi cloud provider, which help to validate the email.")]
        public string Idtoken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of identity domain. DomainID is mandatory if the user is part of Non Default Identity domain.")]
        public string Domainid { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateIncidentRequest request;

            try
            {
                request = new UpdateIncidentRequest
                {
                    IncidentKey = IncidentKey,
                    UpdateIncidentDetails = UpdateIncidentDetails,
                    CompartmentId = CompartmentId,
                    Csi = Csi,
                    OpcRequestId = OpcRequestId,
                    IfMatch = IfMatch,
                    Ocid = Ocid,
                    Homeregion = Homeregion,
                    Bearertokentype = Bearertokentype,
                    Bearertoken = Bearertoken,
                    Idtoken = Idtoken,
                    Domainid = Domainid
                };

                response = client.UpdateIncident(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Incident);
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

        private UpdateIncidentResponse response;
    }
}
