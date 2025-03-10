/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20240102
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DblmService.Requests;
using Oci.DblmService.Responses;
using Oci.DblmService.Models;
using Oci.Common.Model;

namespace Oci.DblmService.Cmdlets
{
    [Cmdlet("Get", "OCIDblmNotificationsList")]
    [OutputType(new System.Type[] { typeof(Oci.DblmService.Models.NotificationCollection), typeof(Oci.DblmService.Responses.ListNotificationsResponse) })]
    public class GetOCIDblmNotificationsList : OCIDbLifeCycleManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The required ID of the compartment in which to list resources.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.")]
        public System.Nullable<int> Limit { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListNotificationsRequest request;

            try
            {
                request = new ListNotificationsRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit
                };

                response = client.ListNotifications(request).GetAwaiter().GetResult();
                WriteOutput(response, response.NotificationCollection);
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

        private ListNotificationsResponse response;
    }
}
