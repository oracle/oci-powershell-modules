/**
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
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
        #endregion

        #region properties
        public string RegionId { get { return Environment.GetEnvironmentVariable(ENV_REGION_NAME); } }

        public string Profile { get { return Environment.GetEnvironmentVariable(ENV_PROFILE_NAME); } }

        public string Config { get { return Environment.GetEnvironmentVariable(ENV_CONFIG_NAME); } }
        #endregion

        #region fields
        private const string ENV_PROFILE_NAME = "OCI_PS_PROFILE";

        private const string ENV_REGION_NAME = "OCI_PS_REGION";

        private const string ENV_CONFIG_NAME = "OCI_PS_CONFIG";
        #endregion

        #region constructor
        private OCIClientSession() { }
        #endregion

        #region methods
        public void SetSession(string regionId, string profile, string config)
        {
            SetEnvVariable(ENV_REGION_NAME, regionId);
            SetEnvVariable(ENV_CONFIG_NAME, config);
            SetEnvVariable(ENV_PROFILE_NAME, profile);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void SetEnvVariable(string varName, string value = null)
        {
            if (value != null)
            {
                //clear existing values
                if (value.Length == 0)
                {
                    value = null;
                }
                //sets the process level environment variable
                Environment.SetEnvironmentVariable(varName, value);
            }
        }
        #endregion
    }
}