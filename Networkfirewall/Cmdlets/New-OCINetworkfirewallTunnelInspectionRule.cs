/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20230501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.NetworkfirewallService.Requests;
using Oci.NetworkfirewallService.Responses;
using Oci.NetworkfirewallService.Models;
using Oci.Common.Model;

namespace Oci.NetworkfirewallService.Cmdlets
{
    [Cmdlet("New", "OCINetworkfirewallTunnelInspectionRule")]
    [OutputType(new System.Type[] { typeof(Oci.NetworkfirewallService.Models.TunnelInspectionRule), typeof(Oci.NetworkfirewallService.Responses.CreateTunnelInspectionRuleResponse) })]
    public class NewOCINetworkfirewallTunnelInspectionRule : OCINetworkFirewallCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Network Firewall Policy identifier")]
        public string NetworkFirewallPolicyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Request Details to create the network firewall policy resource. This parameter also accepts subtype <Oci.NetworkfirewallService.Models.CreateVxlanInspectionRuleDetails> of type <Oci.NetworkfirewallService.Models.CreateTunnelInspectionRuleDetails>.")]
        public CreateTunnelInspectionRuleDetails CreateTunnelInspectionRuleDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateTunnelInspectionRuleRequest request;

            try
            {
                request = new CreateTunnelInspectionRuleRequest
                {
                    NetworkFirewallPolicyId = NetworkFirewallPolicyId,
                    CreateTunnelInspectionRuleDetails = CreateTunnelInspectionRuleDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateTunnelInspectionRule(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TunnelInspectionRule);
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

        private CreateTunnelInspectionRuleResponse response;
    }
}
