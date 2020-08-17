<#
This example helps look into resources that got created as a part of running OCI PS Modules examples and optionally allows some resources to be cleaned up.
This example also demonstrates the power of powershell pipelines https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_pipelines.
This example requires:
1) Modules OCI.PSModules.Database,OCI.PSModules.Resourcesearch,OCI.PSModule.Identity,OCI.PSModules.Core. Install the modules from Powershell Gallery.
#>

$UserErrorActionPreference = $ErrorActionPreference

function ConfirmDelete {
    $Title = 'Delete Resource?'
    $Question = 'Can the above resource be cleaned up?'
    $Choices = '&Yes', '&No'
    $Decision = $Host.UI.PromptForChoice($Title, $Question, $Choices, 1)
    if (0 -eq $Decision) {
        return $true
    }
    return $false
}

$ErrorActionPreference = "Stop" 
try {
    Import-Module OCI.PSModules.Core
    Import-Module OCI.PSModules.Database
    Import-Module OCI.PSModules.Resourcesearch
    Import-Module OCI.PSModules.Identity
    
    #setup
    $SearchText = 'psexample'
    $AvailableState = 'Available'
    $RunningState = 'Running'
    $ActiveState = 'Active'

    $SearchDetails = New-Object -TypeName Oci.ResourcesearchService.Models.FreeTextSearchDetails
    $SearchDetails.Type = "FreeText"
    $SearchDetails.Text = $SearchText

    #search resources
    Invoke-OCIResourceSearchSearchResources -SearchDetails $searchDetails | Out-Null

    $PSExampleResources = $OCICmdletHistory.LastResponse.ResourceSummaryCollection.Items 
    if ($PSExampleResources.Count -ne 0) {
        Write-Host "Search Results for text '$SearchText'"
        $PSExampleResources | Select-Object -Property ResourceType, DisplayName, TimeCreated, LifecycleState | Out-Host
        
        #Remove DBSystem
        $PSExampleResources |
        Where-Object { $_.ResourceType -eq 'DbSystem' -and $_.LifecycleState -eq $AvailableState }  | ForEach-Object {
            $_ | Out-Host
            Write-Host "Confirm to delete the above resource?"
            $_ | Select-Object -Property @{name = "DbSystemId"; Expression = { $_.Identifier } } | Invoke-OCIDatabaseTerminateDbSystem  -WaitForStatus Succeeded -MaxWaitAttempts 10 | Out-Host
        }
    
        #Remove Instances
        $PSExampleResources |
        Where-Object { $_.ResourceType -eq 'Instance' -and $_.LifecycleState -eq $RunningState }  | ForEach-Object {
            $Instance = $_
            $Instance
            if (ConfirmDelete) {
                $Instance | Select-Object -Property @{name = "InstanceId"; Expression = { $_.Identifier } } | Invoke-OCIComputeTerminateInstance -Force | Out-Host
                $Instance | Select-Object -Property @{name = "InstanceId"; Expression = { $_.Identifier } } | Get-OCIComputeInstance -WaitForLifecycleState Terminated -MaxWaitAttempts 15 
            }
    
        }
    
        #Remove Subnets
        $PSExampleResources |
        Where-Object { $_.ResourceType -eq 'Subnet' -and $_.LifecycleState -eq $AvailableState }  | ForEach-Object {
            $_ | Out-Host
            Write-Host "Confirm to delete the above resource?"
            $_ | Select-Object -Property @{name = "SubnetId"; Expression = { $_.Identifier } } | Remove-OCIVirtualNetworkSubnet | Out-Host
        }
    
        #Remove Vcn
        $PSExampleResources |
        Where-Object { $_.ResourceType -eq 'Vcn' -and $_.LifecycleState -eq $AvailableState }  | ForEach-Object {
            $_ | Out-Host
            Write-Host "Confirm to delete the above resource?"
            $_ | Select-Object -Property @{name = "VcnId"; Expression = { $_.Identifier } } | Remove-OCIVirtualNetworkVcn | Out-Host
        }
    
        #Remove Compartments
        $PSExampleResources |
        Where-Object { $_.ResourceType -eq 'Compartment' -and $_.LifecycleState -eq $ActiveState }  | ForEach-Object {
            $_ | Out-Host
            Write-Host "Confirm to delete the above resource?"
            $_ | Select-Object -Property @{name = "CompartmentId"; Expression = { $_.Identifier } } | Remove-OCIIdentityCompartment | Out-Host 
        }    
    }
    else {
        Write-Host "No resource containing the name '$SearchText' was found."
    }
    
}
finally {
    $ErrorActionPreference = $UserErrorActionPreference
}