/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180401
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.MonitoringService.Requests;
using Oci.MonitoringService.Responses;
using Oci.MonitoringService.Models;
using Oci.Common.Model;

namespace Oci.MonitoringService.Cmdlets
{
    [Cmdlet("Invoke", "OCIMonitoringSummarizeAlarmSuppressionHistory")]
    [OutputType(new System.Type[] { typeof(Oci.MonitoringService.Models.AlarmSuppressionHistoryItemCollection), typeof(Oci.MonitoringService.Responses.SummarizeAlarmSuppressionHistoryResponse) })]
    public class InvokeOCIMonitoringSummarizeAlarmSuppressionHistory : OCIMonitoringCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of an alarm.")]
        public string AlarmId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).

Default: 1000

Example: 500")]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"summarize history details")]
        public SummarizeAlarmSuppressionHistoryDetails SummarizeAlarmSuppressionHistoryDetails { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            SummarizeAlarmSuppressionHistoryRequest request;

            try
            {
                request = new SummarizeAlarmSuppressionHistoryRequest
                {
                    AlarmId = AlarmId,
                    OpcRequestId = OpcRequestId,
                    Page = Page,
                    Limit = Limit,
                    SummarizeAlarmSuppressionHistoryDetails = SummarizeAlarmSuppressionHistoryDetails
                };

                response = client.SummarizeAlarmSuppressionHistory(request).GetAwaiter().GetResult();
                WriteOutput(response, response.AlarmSuppressionHistoryItemCollection);
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

        private SummarizeAlarmSuppressionHistoryResponse response;
    }
}
