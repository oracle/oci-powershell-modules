/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabaseService.Requests;
using Oci.DatabaseService.Responses;
using Oci.DatabaseService.Models;
using Oci.Common.Model;

namespace Oci.DatabaseService.Cmdlets
{
    [Cmdlet("New", "OCIDatabaseBackupDestination")]
    [OutputType(new System.Type[] { typeof(Oci.DatabaseService.Models.BackupDestination), typeof(Oci.DatabaseService.Responses.CreateBackupDestinationResponse) })]
    public class NewOCIDatabaseBackupDestination : OCIDatabaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request to create a new backup destination. This parameter also accepts subtypes <Oci.DatabaseService.Models.CreateNFSBackupDestinationDetails>, <Oci.DatabaseService.Models.CreateRecoveryApplianceBackupDestinationDetails> of type <Oci.DatabaseService.Models.CreateBackupDestinationDetails>.")]
        public CreateBackupDestinationDetails CreateBackupDestinationDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateBackupDestinationRequest request;

            try
            {
                request = new CreateBackupDestinationRequest
                {
                    CreateBackupDestinationDetails = CreateBackupDestinationDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateBackupDestination(request).GetAwaiter().GetResult();
                WriteOutput(response, response.BackupDestination);
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

        private CreateBackupDestinationResponse response;
    }
}
