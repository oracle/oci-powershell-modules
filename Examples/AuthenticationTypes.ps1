<#
This example demonstrates different authentication types supported by OCI PS Modules.
This example requires:
1) Module OCI.PSModules.Audit. Install the module from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the module
    Import-Module OCI.PSModules.Audit

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    #Use ApiKey configured in config file
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId -AuthType ApiKey"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId -AuthType ApiKey| Out-Host

    #Use InstancePrincipal authentication
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId -AuthType InstancePrincipal"
    #Uncomment if needed. Succeeds when invoked on an oci instance. 
    #Get-OCIAuditConfiguration -CompartmentId $CompartmentId -AuthType InstancePrincipal | Out-Host

    #Backup users debug preference
    $Preference = $DebugPreference
    $DebugPreference = "Continue"

    Write-Host "Default authentication:"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId | Out-Host

    Write-Host "Setting ApiKey authentication as session preference."
    Write-Host "Set-OCIClientSession -AuthType ApiKey"
    Set-OCIClientSession -AuthType ApiKey | Out-Host
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId | Out-Host

    Write-Host "Setting InstancePrincipal authentication as a session preference."
    Write-Host "Set-OCIClientSession -AuthType InstancePrincipal"
    #Uncomment if needed. Succeeds when invoked on an oci instance. 
    #Set-OCIClientSession -AuthType InstancePrincipal | Out-Host
    #Get-OCIAuditConfiguration -CompartmentId $CompartmentId | Out-Host

    #Restore debug preference
    $DebugPreference = $Preference 
}
finally {
    $ErrorActionPreference = $UserErrorActionPreference

    Clear-OCIClientSession -AuthType
}
