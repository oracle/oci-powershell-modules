# Oracle Cloud Infrastructure Modules for PowerShell

## About

PowerShell script examples contained herein uses modules published to [PowerShell Gallery](https://www.powershellgallery.com/).
1. [Setup](https://docs.cloud.oracle.com/en-us/iaas/Content/API/Concepts/sdkconfig.htm) a config file with `DEFAULT` profile at `(~/.oci/config)`.
2. Install the required modules before running the scripts.
```
Install-Module <Module-Name> <-options>
```
3. Most examples require setting an environment variable in your Powershell console.
```
([Environment]::SetEnvironmentVariable("name", "value"))
```
4. These examples help users get started in using OCI Modules for Powershell.
5. To clean up some resources remaining from running the examples given here, run the `PipelineCleanup_ResourceSearch.ps1` example script in this folder. 
---
### Note

- Cmdlets optionally pipeline their output to Out-Host to instantly  flush the pipeline output to the console for better readability as the script is executed. 
- Each example script might attempt to clean up the resources spawned/revert changes made to resources at the end of the script however it is advised to make sure all resources are cleaned up and changes made to resource states were reverted after executing these examples. 
- These examples uses bare minimal data needed to interact with Oracle Cloud Services and yield sub-optimal performance. 