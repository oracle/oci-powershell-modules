/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20220901
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2023, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.OsmanagementhubService.Requests;
using Oci.OsmanagementhubService.Responses;
using Oci.OsmanagementhubService.Models;
using Oci.Common.Model;

namespace Oci.OsmanagementhubService.Cmdlets
{
    [Cmdlet("New", "OCIOsmanagementhubProfile")]
    [OutputType(new System.Type[] { typeof(Oci.OsmanagementhubService.Models.Profile), typeof(Oci.OsmanagementhubService.Responses.CreateProfileResponse) })]
    public class NewOCIOsmanagementhubProfile : OCIOnboardingCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the new registration profile. This parameter also accepts subtypes <Oci.OsmanagementhubService.Models.CreateGroupProfileDetails>, <Oci.OsmanagementhubService.Models.CreateStationProfileDetails>, <Oci.OsmanagementhubService.Models.CreateSoftwareSourceProfileDetails>, <Oci.OsmanagementhubService.Models.CreateLifecycleProfileDetails> of type <Oci.OsmanagementhubService.Models.CreateProfileDetails>.")]
        public CreateProfileDetails CreateProfileDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateProfileRequest request;

            try
            {
                request = new CreateProfileRequest
                {
                    CreateProfileDetails = CreateProfileDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateProfile(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Profile);
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

        private CreateProfileResponse response;
    }
}