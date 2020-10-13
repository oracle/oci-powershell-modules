<#
This example demonstrates per Session Preferences concept introduced by OCI PS Modules. 
This example requires:
1) Modules OCI.PSModules.Limits. Install the modules from Powershell Gallery.
2) Setting up the environment variable TenancyId to a Tenancy OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:TenancyId)) {
    Throw 'Configure $env:TenancyId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.Limits

    #Setup
    $TenancyId = $env:TenancyId
    $Preference = $DebugPreference

    #Enable to see debug logs 
    Write-Host "Enabling debug logs..."
    $DebugPreference = "Continue"

    #User can set any region ID to be used for making calls through out that particular Powershell Session rather than specifying the region ID in each cmdlet invocation.
    #To do so the user can specify region ID for the scope of the session using Set-OCIClientSession
    Write-Host "Set-OCIClientSession -RegionId 'us-ashburn-1'"
    Set-OCIClientSession -RegionId "us-ashburn-1" | Out-Host

    #Add a profile value to the current session scope while retaining what is already configured
    Write-Host "Set-OCIClientSession -Profile 'DEFAULT'" 
    Set-OCIClientSession -Profile 'DEFAULT' | Out-Host

    #Get the metdata of the resource limits definition list currently supported in the tenancy
    Write-Host "Get-OCILimitsLimitDefinitionsList -CompartmentId $TenancyId -Limit 3"
    $LimitDefinitions = Get-OCILimitsLimitDefinitionsList -CompartmentId $TenancyId -Limit 3

    $LimitDefinitions

    #For each resource Limit definition returned by the Service get the available resource limit count
    Write-Host "LimitDefinitions(List) | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId"
    $LimitDefinitions | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId | Out-Host

    #Get the configurred session preference
    Write-Host "Get-OCIClientSession"
    Get-OCIClientSession | Out-Host

    #To clear an existing profile - session preference
    Write-Host "Clear-OCIClientSession -Profile"
    Clear-OCIClientSession -Profile | Out-Host

    Get-OCIClientSession

    #Get the limits for the first definition in the list
    Write-Host "LimitDefinitions[0] | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId"
    $LimitDefinitions[0] | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId | Out-Host

    #Remove session preferences
    Write-Host "Clear-OCIClientSession -All"
    Clear-OCIClientSession -All | Out-Host

    Get-OCIClientSession

    #Get the limits for the first definition in the list
    Write-Host "LimitDefinitions[0] | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId"
    $LimitDefinitions[0] | Get-OCILimitsLimitValuesList -CompartmentId $TenancyId | Out-Host

}
finally {
    #To Maximize possible clean ups continue on error 
    $ErrorActionPreference = "Continue"
    #Clean up
    Write-Host "Cleaning up..."
    $DebugPreference = $Preference
    $ErrorActionPreference = $UserErrorActionPreference
}
