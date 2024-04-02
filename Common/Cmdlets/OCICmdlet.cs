/**
 * Copyright (c) 2020, 2024, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using Oci.Common;
using Oci.Common.Auth;
using Oci.Common.Model;
using Oci.Common.DeveloperToolConfigurations;
using Oci.PSModules.Common.Cmdlets.ClientManagement;
using Oci.PSModules.Common.Cmdlets.CmdletHistory;

namespace Oci.PSModules.Common.Cmdlets
{
    public abstract class OCICmdlet : PSCmdlet
    {
        #region Properties
        [Parameter(Mandatory = false, HelpMessage = "The path to the config file.")]
        public string ConfigFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value to use as the service endpoint, including any required API version path.")]
        public virtual string Endpoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disable retry logic for calls to services.")]
        public SwitchParameter NoRetry { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The profile in the config file to load.")]
        public string Profile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Region-id of the region to make calls against. eg) us-phoenix-1, ap-singapore-1")]
        public string Region { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Output the complete response returned by the API Operation. Using this switch will make this Cmdlet output an object containing response headers in-addition to an optional response body.")]
        public virtual SwitchParameter FullResponse { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Max wait time in milliseconds for the API request to complete. Default is 100000 millis(100 secs).")]
        [ValidateRange(1, int.MaxValue)]
        public int TimeOutInMillis { get; set; } = TIMEOUT_MILLIS;

        [Parameter(Mandatory = false, HelpMessage = "Type of authentication to use for making API requests. Default is Key based Authentication.")]
        public AuthenticationType AuthType { get; set; } = default(AuthenticationType);

        public const int MAX_WAITER_ATTEMPTS = 3;

        public const int WAIT_INTERVAL_SECONDS = 30;

        public const int TIMEOUT_MILLIS = 100 * 1000;

        public IBasicAuthenticationDetailsProvider AuthProvider { get; set; }

        protected string PSUserAgent { get; } = $"{PS_APPNAME}/{Version.GetVersion()}";
        #endregion

        #region Methods
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            start = DateTime.Now;
            try
            {
                SetLoggingPreferences();
                this.AuthProvider = GetAuthenticationDetailsProvider();
                DeveloperToolConfiguration.ReInitialize();
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteDebug("Choosing Parameter Set:" + ParameterSetName);
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            ResetLoggingPreferences();
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
        /// Gets the preferred authentication type for the current invocation
        /// </summary>
        /// <returns>Oci.PSModules.Common.Cmdlets.AuthenticatonType</returns>
        protected AuthenticationType GetPreferredAuthType()
        {
            if (MyInvocation.BoundParameters.ContainsKey("AuthType"))
            {
                return AuthType;
            }
            else if (null != OCIClientSession.Instance.AuthType)
            {
                return (AuthenticationType)OCIClientSession.Instance.AuthType;
            }
            WriteVerbose($"Authentication type defaults to {AuthType}");
            return AuthType;
        }

        /// <summary>
        /// Gets if the cmdlet invocation prefers to avoid retrying failed API calls with retriable error codes.
        /// </summary>
        /// <returns>Bool true/false indicating to avoid/allow retries. </returns>
        protected bool AvoidRetry()
        {
            if (MyInvocation.BoundParameters.ContainsKey("NoRetry"))
            {
                return NoRetry;
            }
            return OCIClientSession.Instance.NoRetry ?? false;
        }

        /// <summary>
        /// Gets the preferred max timeout milliseconds for a cmdlet invocation.
        /// </summary>
        /// <returns>int indicating time in millis.</returns>
        protected int GetPreferredTimeout()
        {
            if (MyInvocation.BoundParameters.ContainsKey("TimeOutInMillis"))
            {
                return TimeOutInMillis;
            }
            else if (null != OCIClientSession.Instance.TimeOutInMillis)
            {
                return (int)OCIClientSession.Instance.TimeOutInMillis;
            }
            WriteVerbose($"Cmdlet timeout defaults to {TimeOutInMillis} milliseconds.");
            return TimeOutInMillis;
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
        protected async void WriteOutput(Object response, Object responseBody, bool enumerateCollection = false)
        {
            string ContentType = ((OciResponse) response).httpResponseMessage.Content.Headers.ContentType?.MediaType;
            if (FullResponse)
            {
                WriteObject(response, enumerateCollection);
            }
            else if ("text/event-stream".Equals(ContentType, StringComparison.OrdinalIgnoreCase))
            {
                WriteDebug("ContentType is text/event-stream, output is a stream");
                using (Stream stream = await ((OciResponse) response).httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    WriteObject(stream);
                }
            }
            else
            {
                WriteObject(responseBody, enumerateCollection);
            }
        }

        /// <summary>
        /// This method updates the OCI Cmdlet history and throws a terminating error.
        /// </summary>
        /// <returns>void</returns>
        protected virtual void TerminatingErrorDuringExecution(Exception ex)
        {
            ErrorRecord er;
            if (ex == null)
            {
                ex = new OperationCanceledException("Cmdlet execution interrupted");
                er = new ErrorRecord(ex, "Interrupted", ErrorCategory.OperationStopped, null);
            }
            else
            {
                er = new ErrorRecord(ex, ex.GetType().ToString(), ErrorCategory.NotSpecified, null);
                if (ex is OperationCanceledException)
                {
                    er.ErrorDetails = new ErrorDetails("Operation timed out. Retry with a larger TimeOutInMillis value");
                }
            }
            FinishProcessing(ex);
            //ThrowTerminatingError will be the last statement as this throws pipeline stopped
            //exception which is unhandled by any OCICmdlet and control flow goes to the caller of the cmdlet
            ThrowTerminatingError(er);
        }

        /// <summary>
        /// This method updates the OCI Cmdlet history and throws a terminating error with a OciPSException.
        /// </summary>
        /// <returns>void</returns>
        protected virtual void TerminatingErrorDuringExecution(OciException ex)
        {
            OciPSException e = new OciPSException(ex);
            ErrorRecord er = new ErrorRecord(e, e.ServiceCode, ErrorCategory.NotSpecified, null);
            er.ErrorDetails = new ErrorDetails(e.ToString());
            FinishProcessing(e);
            //ThrowTerminatingError will be the last statement as this throws pipeline stopped
            //exception which is unhandled by any OCICmdlet and control flow goes to the caller of the cmdlet
            ThrowTerminatingError(er);
        }

        private void SetLoggingPreferences()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var console = new NLog.Targets.ConsoleTarget("logconsole");
            // Keep loglevel off by default.
            NLog.LogLevel minLogLevel;

            // If both Debug and Verbose are passed, Debug takes priority as NLog.Debug loglevel ranks lower than NLog.Info.
            // We will display all the log levels in between NLOG.Debug to NLog.Fatal(includes NLog.Info).
            if (MyInvocation.BoundParameters.ContainsKey("Debug"))
            {
                minLogLevel = NLog.LogLevel.Debug;
            }
            else if (MyInvocation.BoundParameters.ContainsKey("Verbose"))
            {
                minLogLevel = NLog.LogLevel.Info;
            }
            else
            {
                minLogLevel = NLog.LogLevel.Off;
            }

            config.AddRule(minLogLevel, NLog.LogLevel.Fatal, console);
            NLog.LogManager.Configuration = config;
        }

        private void ResetLoggingPreferences()
        {
            NLog.LogManager.Configuration = null;
        }

        private IBasicAuthenticationDetailsProvider GetAuthenticationDetailsProvider()
        {
            AuthenticationType? auth = null;
            try
            {
                auth = GetPreferredAuthType();
                string config = GetPreferredConfig();
                string profile = GetPreferredProfile();
                switch (auth)
                {
                    case AuthenticationType.InstancePrincipal:
                        WriteDebug($"Authentication Type: {AuthenticationType.InstancePrincipal}");
                        return new InstancePrincipalsAuthenticationDetailsProvider();

                    case AuthenticationType.SessionToken:
                        WriteDebug($"Authentication Type: {AuthenticationType.SessionToken}");
                        if (profile != null)
                        {
                            WriteDebug("Choosing Profile:" + profile);
                        }
                        if (config != null)
                        {
                            WriteDebug("Choosing Config:" + config);
                            return new SessionTokenAuthenticationDetailsProvider(config, profile);
                        }
                        return new SessionTokenAuthenticationDetailsProvider(profile);

                    default:
                        WriteDebug($"Authentication Type: {AuthenticationType.ApiKey}");
                        if (profile != null)
                        {
                            WriteDebug("Choosing Profile:" + profile);
                        }
                        if (config != null)
                        {
                            WriteDebug("Choosing Config:" + config);
                            return new ConfigFileAuthenticationDetailsProvider(config, profile);
                        }
                        return new ConfigFileAuthenticationDetailsProvider(profile);
                }
            }
            catch (OciException ex)
            {
                throw new OciPSException(IP_ERROR_MESSAGE,IP_TROUBLESHOOTING_LINK,ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error instantiating {auth} authentication provider. {ex.Message}");
            }
        }
        #endregion

        #region fields
        protected DateTime start;
        protected DateTime end;
        private static readonly string WHAT_IF_PARAM = "WhatIf";
        private static readonly string FORCE_PARAM = "Force";
        private static readonly string PS_APPNAME = "Oracle-PowerShell";
        private const string WRITTEN_TO_FILE = "Output written to ";
        private static string IP_TROUBLESHOOTING_LINK = "https://docs.oracle.com/en-us/iaas/Content/Identity/Tasks/callingservicesfrominstances.htm";
        private static string IP_ERROR_MESSAGE = $"Received non successful response while trying to get the region of the instance."
            + $"\nInstance principals authentication can only be used on OCI compute instances. Please confirm this code is running on an OCI compute instance. See {IP_TROUBLESHOOTING_LINK} for more info.";
        #endregion
    }
}