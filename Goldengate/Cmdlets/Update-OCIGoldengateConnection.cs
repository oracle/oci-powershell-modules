/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200407
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.GoldengateService.Requests;
using Oci.GoldengateService.Responses;
using Oci.GoldengateService.Models;
using Oci.Common.Model;

namespace Oci.GoldengateService.Cmdlets
{
    [Cmdlet("Update", "OCIGoldengateConnection")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.GoldengateService.Responses.UpdateConnectionResponse) })]
    public class UpdateOCIGoldengateConnection : OCIGoldenGateCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of a Connection.")]
        public string ConnectionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The new Connection specifications to apply. This parameter also accepts subtypes <Oci.GoldengateService.Models.UpdateElasticsearchConnectionDetails>, <Oci.GoldengateService.Models.UpdateGoogleBigQueryConnectionDetails>, <Oci.GoldengateService.Models.UpdateOracleConnectionDetails>, <Oci.GoldengateService.Models.UpdateAmazonRedshiftConnectionDetails>, <Oci.GoldengateService.Models.UpdateOciObjectStorageConnectionDetails>, <Oci.GoldengateService.Models.UpdateRedisConnectionDetails>, <Oci.GoldengateService.Models.UpdateMongoDbConnectionDetails>, <Oci.GoldengateService.Models.UpdateGoogleCloudStorageConnectionDetails>, <Oci.GoldengateService.Models.UpdateMicrosoftFabricConnectionDetails>, <Oci.GoldengateService.Models.UpdatePostgresqlConnectionDetails>, <Oci.GoldengateService.Models.UpdateMicrosoftSqlserverConnectionDetails>, <Oci.GoldengateService.Models.UpdateSnowflakeConnectionDetails>, <Oci.GoldengateService.Models.UpdateHdfsConnectionDetails>, <Oci.GoldengateService.Models.UpdateDatabricksConnectionDetails>, <Oci.GoldengateService.Models.UpdateKafkaConnectionDetails>, <Oci.GoldengateService.Models.UpdateAzureDataLakeStorageConnectionDetails>, <Oci.GoldengateService.Models.UpdateAmazonKinesisConnectionDetails>, <Oci.GoldengateService.Models.UpdateJavaMessageServiceConnectionDetails>, <Oci.GoldengateService.Models.UpdateGoldenGateConnectionDetails>, <Oci.GoldengateService.Models.UpdateGooglePubSubConnectionDetails>, <Oci.GoldengateService.Models.UpdateOracleNosqlConnectionDetails>, <Oci.GoldengateService.Models.UpdateKafkaSchemaRegistryConnectionDetails>, <Oci.GoldengateService.Models.UpdateAmazonS3ConnectionDetails>, <Oci.GoldengateService.Models.UpdateMysqlConnectionDetails>, <Oci.GoldengateService.Models.UpdateDb2ConnectionDetails>, <Oci.GoldengateService.Models.UpdateIcebergConnectionDetails>, <Oci.GoldengateService.Models.UpdateGenericConnectionDetails>, <Oci.GoldengateService.Models.UpdateAzureSynapseConnectionDetails> of type <Oci.GoldengateService.Models.UpdateConnectionDetails>.")]
        public UpdateConnectionDetails UpdateConnectionDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource.  The resource is updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Whether to override locks (if any exist).")]
        public System.Nullable<bool> IsLockOverride { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateConnectionRequest request;

            try
            {
                request = new UpdateConnectionRequest
                {
                    ConnectionId = ConnectionId,
                    UpdateConnectionDetails = UpdateConnectionDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId,
                    IsLockOverride = IsLockOverride
                };

                response = client.UpdateConnection(request).GetAwaiter().GetResult();
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

        private UpdateConnectionResponse response;
    }
}
