/**
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */
﻿using System;
using System.IO;

namespace Oci.PSModules.Common.Cmdlets.ClientManagement
{
    public class OCIFileUtils
    {
        /// <summary>
        /// Create a directory if it doesn't exist.
        /// </summary>
        /// <param name="dirPath">Path to create a new directory</param>
        /// <returns>Boolean indicating directory creation</returns>
        public static bool CreateDirectory(string dirPath)
        {
            bool ret = false;
            if (!String.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath))
            {
                DirectoryInfo dirInfo = Directory.CreateDirectory(dirPath);
                ret = true;
                //<TODO>: Restrict directory access permissions; Currently .Net Standard doesn't support ACL Permissions. 
                //DirectorySecurity dirSecurity = new DirectorySecurity(dirPath, AccessControlSections.Owner);
                //dirInfo.SetAccessControl(dirSecurity);
                //FileSystemAclExtensions.SetAccessControl(dirInfo, dirSecurity);
            }
            return ret;
        }
    }
}
