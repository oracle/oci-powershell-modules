/**
 * Copyright (c) 2020, 2025, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
using System;
using System.Runtime.CompilerServices;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    /// <summary>
    /// OCIClientSession class saves the user preferred OCI Profile, Config and RegionId properties for the current session.
    /// </summary>
    public sealed class OCIClientSession
    {
        #region staticmembers
        /// <summary>
        /// Singleton instance of the OCIClientSession class
        /// </summary>
        public static OCIClientSession Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SingletonLock)
                    {
                        if (instance == null)
                        {
                            instance = new OCIClientSession();
                        }
                    }
                }
                return instance;
            }
        }

        private static readonly object SingletonLock = new object();

        private static OCIClientSession instance;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region properties
        public string RegionId
        {
            get { return Environment.GetEnvironmentVariable(ENV_REGION_NAME); }
            set { SetEnvVariable(ENV_REGION_NAME, value); }
        }

        public string Profile
        {
            get { return Environment.GetEnvironmentVariable(ENV_PROFILE_NAME); }
            set { SetEnvVariable(ENV_PROFILE_NAME, value); }
        }

        public string Config
        {
            get { return Environment.GetEnvironmentVariable(ENV_CONFIG_NAME); }
            set { SetEnvVariable(ENV_CONFIG_NAME, value); }
        }

        public AuthenticationType? AuthType
        {
            get
            {
                string val = Environment.GetEnvironmentVariable(ENV_AUTH_TYPE);
                AuthenticationType? ret = null;
                AuthenticationType temp;
                if (null != val)
                {
                    if (!Enum.TryParse<AuthenticationType>(val, out temp))
                    {
                        throw new Exception($"{val} is not a valid authentication type!");
                    }
                    else
                    {
                        ret = temp;
                    }
                }
                return ret;
            }

            set { SetEnvVariable(ENV_AUTH_TYPE, value?.ToString()); }
        }

        public bool? NoRetry
        {
            get
            {
                string val = Environment.GetEnvironmentVariable(ENV_NORETRY);
                bool? ret = null;
                if (null != val)
                {
                    if (!val.Equals(true.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception($"{val} is not an expected value. Set {ENV_NORETRY} to {true}/null to disable/enable retries.");
                    }
                    else
                    {
                        ret = true;
                    }

                }
                return ret;
            }
            set { SetEnvVariable(ENV_NORETRY, value?.ToString()); }
        }

        public int? TimeOutInMillis
        {
            get
            {
                string val = Environment.GetEnvironmentVariable(ENV_TIMEOUT_MILLIS);
                int? timeout = null;
                int temp;
                if (null != val)
                {
                    if (!int.TryParse(val, out temp) || temp < 1)
                    {
                        throw new Exception($"{ENV_TIMEOUT_MILLIS} value {val} is out of valid range 1 - {int.MaxValue}");
                    }
                    else
                    {
                        timeout = temp;
                    }
                }
                return timeout;
            }
            set { SetEnvVariable(ENV_TIMEOUT_MILLIS, value?.ToString()); }
        }
        #endregion

        #region fields
        private const string ENV_PROFILE_NAME = "OCI_PS_PROFILE";

        private const string ENV_REGION_NAME = "OCI_PS_REGION";

        private const string ENV_CONFIG_NAME = "OCI_PS_CONFIG";

        private const string ENV_AUTH_TYPE = "OCI_PS_AUTH";

        private const string ENV_NORETRY = "OCI_PS_NORETRY";

        private const string ENV_TIMEOUT_MILLIS = "OCI_PS_TIMEOUT";
        #endregion

        #region constructor
        private OCIClientSession() { }
        #endregion

        #region methods

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void SetEnvVariable(string varName, string value = null)
        {
            //clear existing values
            if (value?.Length == 0)
            {
                value = null;
            }
            //sets the process level environment variable
            Environment.SetEnvironmentVariable(varName, value);
        }
        #endregion
    }
}