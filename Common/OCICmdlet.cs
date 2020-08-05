/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.IO;
using System.Management.Automation;
using Oci.Common.Auth;
using Oci.PSModules.Common.Cmdlets.ClientManagement;
using Oci.PSModules.Common.Cmdlets.CmdletHistory;

namespace Oci.PSModules.Common.Cmdlets
{
    public class OCICmdlet : PSCmdlet
    {
        #region Properties
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The path to the config file.")]
        public string ConfigFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value to use as the service endpoint, including any required API version path.")]
        public virtual string Endpoint { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Disable retry logic for calls to services.")]
        public SwitchParameter NoRetry { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The profile in the config file to load.")]
        public string Profile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Region-id of the region to make calls against. eg) us-phoenix-1, ap-singapore-1")]
        public string Region { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Output the complete response returned by the API Operation. Using this switch will make this Cmdlet output an object containing response headers in-addition to an optional response body.")]
        public virtual SwitchParameter FullResponse { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Max wait time in milliseconds for the API request to complete. Default is 100000 millis(100 secs)")]
        public int TimeOutInMillis { get; set; } = 100 * 1000;

        public const int MAX_WAITER_ATTEMPTS = 3;

        public const int WAIT_INTERVAL_SECONDS = 30;

        public IBasicAuthenticationDetailsProvider AuthProvider { get; set; }

        protected string PSUserAgent { get; } = $"{PS_APPNAME}/{Version.GetVersion()}";
        #endregion

        #region Methods
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            SetLoggingPreferences();
            string config = GetPreferredConfig();
            string profile = GetPreferredProfile();
            if (config != null)
            {
                WriteDebug("Choosing Config:" + config);
            }
            if (profile != null)
            {
                WriteDebug("Choosing Profile:" + profile);
            }
            if (config == null)
            {
                this.AuthProvider = new ConfigFileAuthenticationDetailsProvider(profile);
            }
            else
            {
                this.AuthProvider = new ConfigFileAuthenticationDetailsProvider(config, profile);
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            start = DateTime.Now;
            WriteDebug("Choosing Parameter Set:" + ParameterSetName);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            ResetLoggingPreferences();
        }

        /// <summary>
        /// This method helps record history of the cmdlet invocation and api responses  for all sub class cmdlets
        /// </summary>
        /// <param name="response">Last API response received by the cmdlet invocation</param>
        protected virtual void FinishProcessing(Object response)
        {
            end = DateTime.Now;
            OCICmdletHistory historyObj = new OCICmdletHistory(start, end)
            {
                Command = this.MyInvocation,
                Response = new PSObject(response)
            };
            OCICmdletHistoryStore.Instance.Update(historyObj, this.SessionState);
        }


        /// <summary>
        /// Utility method to handle resource delete confirmation.
        /// * WhatIf: User passes WhatIf parameter, this method returns false(executes ShouldProcess) and prints What If actions to the console. This has higher precedence than Force param.
        /// * Force: If force param is passed, method returns true. If both WhatIf and Force are passed, method returns False as WhatIf has higher precedence.
        /// * No Force or WhatIf param as passed: ShouldProcess will execute and prompts the user to confirm the action.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected bool ConfirmDelete(string target, string action)
        {
            // Check if WhatIf is present.
            bool isWhatIfEnabled = MyInvocation.BoundParameters.ContainsKey(WHAT_IF_PARAM);
            // disable force if WhatIf is passed.
            bool isForceEnabled = isWhatIfEnabled ? false : MyInvocation.BoundParameters.ContainsKey(FORCE_PARAM);

            if (isForceEnabled)
            {
                return true;
            }

            return ShouldProcess(target, action);
        }

        /// <summary>
        /// Utility method to file absolute path of the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected string GetAbsoluteFilePath(string filePath)
        {
            return SessionState.Path.GetUnresolvedProviderPathFromPSPath(filePath);
        }

        /// <summary>
        /// Utility method for writing the output stream to the provided file path.
        ///  - Creates the file if not present.
        ///  - Creates the entire folder structure if any of the subdirectories don't exist
        ///  - Overrides the file if it's already present.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputStream"></param>
        protected void WriteToOutputFile(string filePath, Stream outputStream)
        {
            var absolutePath = GetAbsoluteFilePath(filePath);
            var dir = Path.GetDirectoryName(absolutePath);
            OCIFileUtils.CreateDirectory(dir);
            using (Stream fileStream = File.Create(absolutePath))
            {
                outputStream.CopyTo(fileStream);
            }
            Host.UI.WriteLine($"{WRITTEN_TO_FILE}{absolutePath}");
        }

        /// <summary>
        /// Gets the user preferred Config file path for current invocation
        /// </summary>
        /// <returns>Path to the config file</returns>
        protected string GetPreferredConfig()
        {
            return ConfigFile ??
                    OCIClientSession.Instance.Config;
        }

        /// <summary>
        /// Gets the user preferred profile for current invocation
        /// </summary>
        /// <returns>Profile name</returns>
        protected string GetPreferredProfile()
        {
            return Profile ??
                    OCIClientSession.Instance.Profile;
        }

        /// <summary>
        /// Gets the user preferred region id for current invocation
        /// </summary>
        /// <returns>Region ID</returns>
        protected string GetPreferredRegion()
        {
            return Region ??
                    OCIClientSession.Instance.RegionId;
        }

        /// <summary>
        /// Creates a work request wrapper object for the passed opcWorkRequestID
        /// </summary>
        /// <param name="opcWorkRequestId">The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the work request.</param>
        /// <returns>Work Request Object</returns>
        protected WorkRequest CreateWorkRequestObject(string opcWorkRequestId)
        {
            return new WorkRequest
            {
                OpcWorkRequestId = opcWorkRequestId
            };
        }

        /// <summary>
        /// For operations without a response body(return type),
        /// Outputs the complete response if Response switch parameter is present
        /// </summary>
        /// <param name="response"></param>
        protected void WriteOutput(Object response)
        {
            if (FullResponse)
            {
                WriteObject(response);
            }
        }

        /// <summary>
        /// For operations with a response body(return type),
        /// Outputs either the complete response if Response switch parameter is present or only the response body.
        /// </summary>
        /// <param name="response">Response of the operation API</param>
        /// <param name="responseBody">Resonse body of the operation API</param>
        /// <param name="enumerateCollection">Enumerate response or response body</param>
        protected void WriteOutput(Object response, Object responseBody, bool enumerateCollection = false)
        {
            if (FullResponse)
            {
                WriteObject(response, enumerateCollection);
            }
            else
            {
                WriteObject(responseBody, enumerateCollection);
            }
        }

        private void SetLoggingPreferences()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Verbose") || MyInvocation.BoundParameters.ContainsKey("Debug"))
            {
                var config = new NLog.Config.LoggingConfiguration();
                var console = new NLog.Targets.ConsoleTarget("logconsole");
                // If both Debug and Verbose are passed, Debug takes priority as NLog.Debug loglevel ranks lower than NLog.Info.
                // We will display all the log levels in between NLOG.Debug to NLog.Fatal(includes NLog.Info).
                NLog.LogLevel minLogLevel = NLog.LogLevel.Debug;

                if (!MyInvocation.BoundParameters.ContainsKey("Debug"))
                {
                    minLogLevel = NLog.LogLevel.Info;
                }
                config.AddRule(minLogLevel, NLog.LogLevel.Fatal, console);
                NLog.LogManager.Configuration = config;
            }
        }

        private void ResetLoggingPreferences()
        {
            NLog.LogManager.Configuration = null;
        }
        #endregion

        #region fields
        protected DateTime start;
        protected DateTime end;
        private static readonly string WHAT_IF_PARAM = "WhatIf";
        private static readonly string FORCE_PARAM = "Force";
        private static readonly string PS_APPNAME = "Oracle-PowerShell";
        private const string WRITTEN_TO_FILE = "Output written to ";
        #endregion
    }
}
