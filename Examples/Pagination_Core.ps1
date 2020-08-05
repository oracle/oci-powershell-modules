<#
This example demonstrates Pagination concept introduced by OCI PS Modules.
This example requires:
1) Module OCI.PSModules.Core. Install the module from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the module
    Import-Module OCI.PSModules.Core

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    #Get "All" available images(Auto-Paginate)
    Write-Host "Get-OCIComputeImagesList -CompartmentId $CompartmentId -All"
    Get-OCIComputeImagesList -CompartmentId $CompartmentId -All

    #Set 5 results per page as Limit and Page(iterate) through all available images until there is a opc-next-page token in the service response
    $Opcnextpage = $null
    $Count = 1
    $Limit = 5
    do {
        Write-Host "Page Number($Count) Get-OCIComputeImagesList -CompartmentId $CompartmentId -Limit $Limit -Page $Opcnextpage"
        Get-OCIComputeImagesList -CompartmentId $CompartmentId -Limit $Limit -Page $Opcnextpage
        $Opcnextpage = $OCICmdletHistory.LastResponse.OpcNextPage
        $Count++
    } while ($null -ne $Opcnextpage) 
}
finally {
    
    $ErrorActionPreference = $UserErrorActionPreference
}
