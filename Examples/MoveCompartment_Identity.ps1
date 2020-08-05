<#
This example demonstrates Move Compartment operation in Identity service. 
This example requires:
1) Modules OCI.PSModules.Identity. Install the modules from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}

try {
    #Import the modules
    Import-Module OCI.PSModules.Identity

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix

    $SourceCompartmentDetails = New-Object -TypeName Oci.IdentityService.Models.CreateCompartmentDetails
    $SourceCompartmentDetails.Description = $DisplayName + ": source Compartment for Move Compartment operation"
    $SourceCompartmentDetails.Name = $DisplayName + "Source"
    $SourceCompartmentDetails.CompartmentId = $CompartmentId

    $NewParentCompartmentDetails = New-Object -TypeName Oci.IdentityService.Models.CreateCompartmentDetails
    $NewParentCompartmentDetails.Description = $DisplayName + ": New parent Compartment for Move Compartment operation"
    $NewParentCompartmentDetails.Name = $DisplayName + "Parent"
    $NewParentCompartmentDetails.CompartmentId = $CompartmentId

    $ActiveState = [Oci.IdentityService.Models.Compartment+LifeCycleStateEnum]::Active

    Write-Host "New-OCIIdentityCompartment -CreateCompartmentDetails $SourceCompartmentDetails"
    $SourceCompartment = New-OCIIdentityCompartment -CreateCompartmentDetails $SourceCompartmentDetails
    $SourceCompartment

    Write-Host "New-OCIIdentityCompartment -CreateCompartmentDetails $NewParentCompartmentDetails"
    $ParentCompartment = New-OCIIdentityCompartment -CreateCompartmentDetails $NewParentCompartmentDetails
    $ParentCompartment

    Start-Sleep -Seconds 5

    Get-OCIIdentityCompartment -CompartmentId $SourceCompartment.Id -WaitForLifecycleState $ActiveState | Out-Host
    Get-OCIIdentityCompartment -CompartmentId $ParentCompartment.Id -WaitForLifecycleState $ActiveState | Out-Host 

    $MoveCompDetails = New-Object -TypeName Oci.IdentityService.Models.MoveCompartmentDetails
    $MoveCompDetails.TargetCompartmentId = $ParentCompartment.Id
    Write-Host "Move-OCIIdentityCompartment -CompartmentId $($SourceCompartment.Id) -MoveCompartmentDetails $MoveCompDetails"
    Move-OCIIdentityCompartment -CompartmentId $SourceCompartment.Id -MoveCompartmentDetails $MoveCompDetails | Out-Host
}
finally {
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
        
    #Clean up 
    Write-Host "Starting clean up...."

    if ($null -ne $SourceCompartment.Id) {
        Write-Host "Remove-OCIIdentityCompartment -CompartmentId $SourceCompartment.Id"
        Remove-OCIIdentityCompartment -CompartmentId $SourceCompartment.Id  | Out-Host
        Get-OCIIdentityWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus "InProgress" -MaxWaitAttempts 10
    }

    if ($null -ne $ParentCompartment.Id) {
        Write-Host "Remove-OCIIdentityCompartment -CompartmentId $ParentCompartment.Id"
        Remove-OCIIdentityCompartment -CompartmentId $ParentCompartment.Id 
        Get-OCIIdentityWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus "Accepted" 
    }

    Write-Warning "Created compartments might be  getting cleaned up in the tenancy.."

    $ErrorActionPreference = $UserErrorActionPreference
}
