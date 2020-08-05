<#
This example demonstrates working with History Store introduced by OCI PS Modules.
This example requires:
1) Modules OCI.PSModules.Identity. Install the modules from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
3) Setting up the environment variable TenancyId to a Tenancy OCID.
#>

$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId) -or [string]::IsNullOrEmpty($env:TenancyId)) {
    Throw 'Configure $env:CompartmentId and $env:TenancyId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.Identity

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $TenancyId = $env:TenancyId
    $UserName = 'PShellBot'

    #Get available regions list
    Write-Host "Get-OCIIdentityRegionsList"
    Get-OCIIdentityRegionsList | Out-Host

    #Get subscribed regions list
    Write-Host "Get-OCIIdentityRegionSubscriptionsList -TenancyId $TenancyId"
    Get-OCIIdentityRegionSubscriptionsList -TenancyId $TenancyId | Out-Host

    #Create user details
    $UserDetails = New-Object -TypeName Oci.IdentityService.Models.CreateUserDetails
    $UserDetails.CompartmentId = $TenancyId
    $UserDetails.Name = $UserName
    $UserDetails.Email = $UserName + "@oraclecloud.com"
    $UserDetails.Description = "Delete me! Example user" + $UserName

    #Create a new user
    Write-Host "New-OCIIdentityUser -CreateUserDetails $UserDetails"
    New-OCIIdentityUser -CreateUserDetails $UserDetails | Out-Host

    #Remove the created user asking user confirmation
    Write-Host "Remove-OCIIdentityUser -UserId $OCICmdletHistory.LastResponse.User.Id -FullResponse"
    Remove-OCIIdentityUser -UserId $OCICmdletHistory.LastResponse.User.Id -FullResponse | Out-Host

    <#
OCI Modules for Powershell maintains the history of Cmdlet invocations and the 
corresponsing responses returned by the Cloud services they interact with.
Examples shown below explains possible ways to access/read/modify the stored information.
#>

    $Size = 4

    #Resize the history store 
    Write-Host "Set-OCICmdletHistory -Size $Size"
    Set-OCICmdletHistory -Size $Size | Out-Host

    #Get the history list stored in history store
    Write-Host "Get-OCICmdletHistory"
    Get-OCICmdletHistory | Out-Host

    #Get the size of the current history store
    Write-Host "Get-OCICmdletHistory -Size"
    Get-OCICmdletHistory -Size | Out-Host

    #Expand the current store size
    $Size += 2

    #Resize the history store
    Write-Host "Set-OCICmdletHistory -Size $Size" 
    Set-OCICmdletHistory -Size $Size | Out-Host

    #Execute more cmdlets that interacts with the cloud services to populate history
    Write-Host "Get-OCIIdentityAvailabilityDomainsList -CompartmentId $CompartmentId"
    Get-OCIIdentityAvailabilityDomainsList -CompartmentId $CompartmentId | Out-Host
    Write-Host "Get-OCIIdentityRegionsList"
    Get-OCIIdentityRegionsList | Out-Host

    #Get the history list stored in history store
    Write-Host "Get-OCICmdletHistory"
    Get-OCICmdletHistory | Out-Host

    #Shrink the current store size
    $Size -= 2

    #Reduce the size of the history store
    Write-Host "Set-OCICmdletHistory -Size $Size"
    Set-OCICmdletHistory -Size $Size | Out-Host

    #Accessing stored history through environment variable
    #Last response received
    Write-Host "Get the response of the last executed cmdlet:"
    $OCICmdletHistory.LastResponse | Out-Host

    #List fo past cmdlet history entries
    Write-Host "List all the history entries:"
    $OCICmdletHistory.Entries | Out-Host

    #Index based history store access
    #Index '0' being the oldest and index 'n-1' latest, where n is the size of the history store
    Write-Host "Access the oldest history stored:"
    $OCICmdletHistory.Entries[0] | Out-Host

    #Size of the history store
    Write-Host "Size of the history store:"
    $OCICmdletHistory.Size | Out-Host

    #Clear the history store
    Write-Host "Clearing the stored history!"
    Clear-OCICmdletHistory
}
finally {
    $ErrorActionPreference = $UserErrorActionPreference
}
