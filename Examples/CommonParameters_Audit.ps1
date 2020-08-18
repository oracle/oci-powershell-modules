<#
This example demonstrates how to use Common Parameters introduced by OCI PS Modules.
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

    #Get audit configuration without any common parameters
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId | Out-Host

    #Return the complete API Reponse
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId -FullResponse"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId -FullResponse | Out-Host

    #Backup users debug preference
    $Preference = $DebugPreference
    $DebugPreference = "Continue"

    #Changing Endpoint
    $endpoint = "https://audit.us-ashburn-1.oraclecloud.com"
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId -Endpoint $endpoint"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId -Endpoint $endpoint | Out-Host

    #Changing user profile used for accessing the service
    $ociprofile = "DEFAULT" #can be any profile (case-sensitive) you wish to use 
    Write-Host "Get-OCIAuditConfiguration -CompartmentId $CompartmentId -Profile $ociprofile"
    Get-OCIAuditConfiguration -CompartmentId $CompartmentId -Profile $ociprofile | Out-Host

    #Restore debug preference
    $DebugPreference = $Preference 
}
finally {
    $ErrorActionPreference = $UserErrorActionPreference
}
