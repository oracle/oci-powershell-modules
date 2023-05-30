## Oracle Cloud Infrastructure Modules for PowerShell

### About

[Oracle Cloud Infrastructure(OCI) Modules for PowerShell](https://docs.cloud.oracle.com/en-us/iaas/Content/API/SDKDocs/powershell.htm) is a set of cmdlet modules that can be used with PowerShell Core to manage Oracle Cloud Infrastructure resources. You can invoke these cmdlets from the PowerShell command-line and with the associated PowerShell scripting language.

The project is open source and maintained by Oracle Corp.

### Supported PowerShell Versions

- PowerShell Core 6.0 and higher

### Install

#### From PowerShell Gallery:
The modules are published to [PowerShell Gallery](https://www.powershellgallery.com/).

Install the modules from PowerShell Gallery using `Install-Module` as explained [here](https://docs.microsoft.com/en-us/powershell/module/powershellget/install-module).

```
#Install module for Audit Service
Install-Module OCI.PSModules.Audit
```

To install all OCI modules:
```
Install-Module OCI.PSModules
```
Note: Uninstalling `OCI.PSModules` will not uninstall other OCI modules. To uninstall a specific OCI module installed by this module, `OCI.PSModules` will have to be uninstalled first.

#### From Github:
PowerShell modules are published to [GitHub](https://github.com/oracle/oci-powershell-modules/releases).

* Download `oci-psmodules-artifacts-<version>.zip` file attached to the latest release in the Assets section.
* Extract `oci-psmodules-artifacts-<version>.zip` to a local directory.
* Register the extracted directory as the local PowerShell repository using the following cmdlet:
    ```powershell
    Register-PSRepository -Name "LocalRepo" -SourceLocation <extractedlocation>
    ```
* Find the modules available in the local repository using the following cmdlet:
    ```powershell
    Find-Module -Repository "LocalRepo"
    ```
* Install the desired module:
    ```powershell
    Install-Module -Name OCI.PSModules.Objectstorage -Verbose -Repository LocalRepo
    Install-Module -Name OCI.PSModules.Core -Verbose -Repository LocalRepo
    ```

### Configuring

Before using the cmdlets, set up a config file with the required credentials. Refer [setup](https://docs.cloud.oracle.com/en-us/iaas/Content/API/SDKDocs/powershellgettingstarted.htm#powershellsdkgettingstarted_topic_setup) for instructions.

```
Import-Module OCI.PSModules.Common

#To setup a new config file
Set-OCIClientConfig
```

### Examples

Some examples can be found [here](/Examples).

### Building and Testing

#### Build

Modules can be built at the solution level or at the individual project level under the solution folder.
At the root level, to build all the modules, run the dotnet cli command:

```
dotnet build
```

Alternatively, individual projects(modules) can be built by using dotnet cli commands inside project directory.

#### Test

1. The repository has some Pester unit test scripts [unit tests](/Tests).
These test scripts can be run in PowerShell.

```
#Install Pester module
Install-Module -Name Pester

#Dot-source common utilities for tests
. ./Common.ps1

#Set the path to config file in an env variable
([Environment]::SetEnvironmentVariable("ConfigFile", "~/.oci/config"))

#Run individual test script
Invoke-Pester ./<<Test-Script>>.ps1

#Run all test scripts
Invoke-Pester
```
2. To test code changes, publish and import the service module.

Individual services can be published by executing the `dotnet publish` command from inside the project directory.
```
#Navigate to the project directory
cd <<ServiceName>>

#Publish assemblies
dotnet publish -o assemblies/
```
If you haven't loaded the required common module dependecy in your PowerShell session previously, load the common module.
```
cd ./oci-powershell-modules/Common/

Import-Module ./OCI.PSModules.Common.psd1
```

Import the published module into current PowerShell session from inside the project directory.
```
Import-Module OCI.PSModules.<<ServiceName>>.psd1
```

### Help

The [Issues](https://github.com/oracle/oci-powershell-modules/issues) page of this GitHub repository.
To raise questions on Stack Overflow, use the [oracle-cloud-infrastructure](https://stackoverflow.com/questions/tagged/oracle-cloud-infrastructure) and [oci-powershell-modules](https://stackoverflow.com/questions/tagged/oci-powershell-modules) tags in your post.
[Developer Tools](https://community.oracle.com/community/groundbreakers/oracle-cloud/cloud-infrastructure/content) section of the Oracle Cloud forums.
[My Oracle Support](https://support.oracle.com/portal/).

### Contributing

```oci-powershell-modules``` is an open source project. See [CONTRIBUTING](https://github.com/oracle/oci-powershell-modules/blob/master/CONTRIBUTING.md) for details.

Oracle gratefully acknowledges the contributions to ```oci-powershell-modules``` that have been made by the community.

### License

Copyright (c) 2020, Oracle and/or its affiliates. All rights reserved. This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0; third-party content is separately licensed as described in the code.

See [LICENSE](https://github.com/oracle/oci-powershell-modules/blob/master/License.txt) for more details.

### Changes

See [CHANGELOG](https://github.com/oracle/oci-powershell-modules/blob/master/CHANGELOG.md)

### Known Issues

You can find information on any known issues with the OCI modules for PowerShell at [Oracle Cloud Infrastructure Known Issues](https://docs.cloud.oracle.com/en-us/iaas/Content/knownissues.htm) and under the [Issues](https://github.com/oracle/oci-powershell-modules/Issues) tab of this project's GitHub repository.

### Related Links

Read more about OCI Modules for PowerShell at https://docs.cloud.oracle.com/en-us/iaas/Content/API/SDKDocs/powershell.htm