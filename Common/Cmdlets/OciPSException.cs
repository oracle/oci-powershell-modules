/**
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Net;
using Oci.Common.Utils;
using Oci.Common.Model;

namespace Oci.PSModules.Common.Cmdlets
{
    /// <summary>Exceptions from the OCI PS Modules.</summary>
    public class OciPSException : OciException
    {
        public string TroubleShootingLink { get; } = "https://docs.oracle.com/en-us/iaas/Content/API/References/apierrors.htm";
        public string ErrorMessage { get; }
        public string ApiReferenceLinkMessage { get; }
        public string TroubleshootingTips { get; }
        public static string LoggingTips = "Get more information on a failing request by using the -Verbose or -Debug flags. See https://docs.oracle.com/en-us/iaas/Content/API/SDKDocs/powershellconcepts.htm#powershellconcepts_topic_logging";

        public OciPSException(OciException ex) : base(ex.StatusCode, ex.Message, ex.ServiceCode, ex.OpcRequestId, ex.ApiDetails) {
            if (ApiDetails != null)
            {
                int statusCode = (int)StatusCode;
                TroubleShootingLink += $"#apierrors_{statusCode}__{statusCode}_{ServiceCode?.ToLower()}";

                ErrorMessage = $"Error returned by {ApiDetails.ServiceName} Service. Http Status Code: {statusCode}. ServiceCode: {ServiceCode}. OpcRequestId: {OpcRequestId}. Message: {Message}"
                    + $"\nOperation Name: {ApiDetails.OperationName}"
                    + $"\nTimeStamp: {HttpDateUtils.ToRfc3339Format(DateTime.Now)}"
                    + $"\nClient Version: {ApiDetails.UserAgent}"
                    + $"\nRequest Endpoint: {ApiDetails.RequestEndpoint}";
                ApiReferenceLinkMessage = $"For details on this operation's requirements, see {ApiDetails.ApiReferenceLink}.";
                TroubleshootingTips = $"For more information about resolving this error, see {TroubleShootingLink}"
                    + $"\nIf you are unable to resolve this {ApiDetails.ServiceName} issue, please contact Oracle support and provide them this full error message.";
            }
            else
            {
                ErrorMessage = $"Error encountered: StatusCode:{StatusCode}, Message:{Message}, ServiceCode:{ServiceCode}, OpcRequestId:{OpcRequestId}";
                TroubleshootingTips = $"For more information about resolving this error, see {TroubleShootingLink}"
                    + $"\nIf you are unable to resolve this issue, please contact Oracle support and provide them this full error message.";
            }
        }

        public OciPSException(string ErrorMessage, string Link, OciException ex) : base(ex.StatusCode,
                $"Error encountered: StatusCode:{ex.StatusCode}, Message:{ex.Message}, ServiceCode:{ex.ServiceCode}, OpcRequestId:{ex.OpcRequestId}\n{ErrorMessage}",
                ex.ServiceCode, ex.OpcRequestId, ex.ApiDetails) {
            TroubleShootingLink = Link;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(ApiDetails.ApiReferenceLink))
            {
                return $"{ErrorMessage}\n{LoggingTips}\n{TroubleshootingTips}";
            }
            else
            {
                return $"{ErrorMessage}\n{ApiReferenceLinkMessage}\n{LoggingTips}\n{TroubleshootingTips}";
            }
        }
    }
}