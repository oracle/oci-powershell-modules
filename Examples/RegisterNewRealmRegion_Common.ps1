<#
This example demonstrates how to register a new realm and region not supported by this version of PowerShell modules.
This example requires:
1) Modules OCI.PSModules.Common. Install the modules from Powershell Gallery.
#>

$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 

try {
    #Import the modules
    #Import-Module OCI.PSModules.Common

    Write-Host "Realms currently supported:"
    Get-OCIRealmsList | Out-Host

    Write-Host "Regions currently supported:"
    Get-OCIRegionsList | Out-Host

    Write-Host "Register-OCIRealm -RealmId 'ocxx' -SecondLevelDomain 'oracleexamplecloud.com'"
    $realm = Register-OCIRealm -RealmId "ocxx" -SecondLevelDomain "oracleexamplecloud.com"
    $realm

    Write-Host "Register-OCIRegion -RegionId 'un-earth-1' -RegionCode 'blu' -Realm $realm"
    Register-OCIRegion -RegionId 'un-earth-1' -RegionCode 'blu' -Realm $realm | Out-Host

    Write-Host "Get-OCIRealm -RealmId 'ocxx'"
    $realm =  Get-OCIRealm -RealmId 'ocxx'

    Write-Host "Register-OCIRegion -RegionId 'un-mars-1' -RegionCode 'red' -Realm $realm"
    Register-OCIRegion -RegionId 'un-mars-1' -RegionCode 'red' -Realm $realm | Out-Host

    Write-Host "Realms currently supported:"
    Get-OCIRealmsList | Out-Host

    Write-Host "Regions currently supported:"
    Get-OCIRegionsList | Out-Host

}
finally {
    $ErrorActionPreference = $UserErrorActionPreference
}
