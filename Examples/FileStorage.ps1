<#
This example demonstrates working with various operations in File Storage Service. 
This example requires:
1) Modules OCI.PSModules.Filestorage. Install the modules from Powershell Gallery.
2) Modules OCI.PSModules.Core.  Install the modules from Powershell Gallery.
3) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.Core
    Import-Module OCI.PSModules.Filestorage

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $AvailabilityDomain = 'Iocq:PHX-AD-2'
    $CidrBlock = '10.0.0.0/16'
    $ExportPath = '/ExampleFiles'

    #Create Vcn Details
    $CreateVcnDetails = New-Object "Oci.CoreService.Models.CreateVcnDetails"
    $CreateVcnDetails.CidrBlock = $CidrBlock
    $CreateVcnDetails.CompartmentId = $CompartmentId
    $CreateVcnDetails.DisplayName = $DisplayName

    #Create a Virtual Network VCN
    Write-Host "New-OCIVirtualNetworkVcn -CreateVcnDetails $CreateVcnDetails"
    $Vcn = New-OCIVirtualNetworkVcn -CreateVcnDetails $CreateVcnDetails

    #Inspect the created VCN
    $Vcn

    #Wait for the VCN to become 'Available'
    Write-Host "Get-OCIVirtualNetworkVcn -VcnId $Vcn.Id -WaitForLifecycleState 'Available' -WaitIntervalSeconds 30"
    Get-OCIVirtualNetworkVcn -VcnId $Vcn.Id -WaitForLifecycleState 'Available' -WaitIntervalSeconds 30  | Out-Host

    #Set Subnet properties
    $SubnetProperties = @{
        displayName   = $DisplayName + "Subnet"
        cidrBlock     = $CidrBlock
        vcnId         = $Vcn.Id
        compartmentId = $CompartmentId
    }

    #Create a subnet details object
    $SubnetDetails = New-Object -TypeName 'Oci.CoreService.Models.CreateSubnetDetails' -Property $SubnetProperties

    #Create a Subnet
    Write-Host "New-OCIVirtualNetworkSubnet -CreateSubnetDetails $SubnetDetails"
    $Subnet = New-OCIVirtualNetworkSubnet -CreateSubnetDetails $SubnetDetails

    #Examine the created subnet
    $Subnet

    $CreateFileSystemDetails = New-Object Oci.FilestorageService.Models.CreateFileSystemDetails
    $CreateFileSystemDetails.AvailabilityDomain = $AvailabilityDomain
    $CreateFileSystemDetails.CompartmentId = $CompartmentId
    $CreateFileSystemDetails.DisplayName = $DisplayName

    Write-Host "New-OCIFileStorageFileSystem -CreateFileSystemDetails $CreateFileSystemDetails"
    $FileSysytem = New-OCIFileStorageFileSystem -CreateFileSystemDetails $CreateFileSystemDetails

    $FileSysytem 

    $MountTargetDetails = New-Object Oci.FilestorageService.Models.CreateMountTargetDetails
    $MountTargetDetails.AvailabilityDomain = $AvailabilityDomain
    $MountTargetDetails.CompartmentId = $CompartmentId
    $MountTargetDetails.DisplayName = $DisplayName
    $MountTargetDetails.SubnetId = $Subnet.Id

    Write-Host "New-OCIFileStorageMountTarget -CreateMountTargetDetails $MountTargetDetails"
    $MountTarget = New-OCIFileStorageMountTarget -CreateMountTargetDetails $MountTargetDetails

    $MountTarget

    $MountTargetState = [Oci.FilestorageService.Models.MountTarget+LifecycleStateEnum]::Active
    Write-Host "Get-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id -WaitForLifecycleState $MountTargetState"
    Get-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id -WaitForLifecycleState $MountTargetState

    $CreateExportDetails = New-Object Oci.FilestorageService.Models.CreateExportDetails
    $CreateExportDetails.ExportSetId = $MountTarget.ExportSetId
    $CreateExportDetails.FileSystemId = $FileSysytem.Id
    $CreateExportDetails.Path = $ExportPath

    Write-Host "New-OCIFileStorageExport -CreateExportDetails $CreateExportDetails"
    $Export = New-OCIFileStorageExport -CreateExportDetails $CreateExportDetails

    $Export

    $FileStorageState = [Oci.FilestorageService.Models.Export+LifecycleStateEnum]::Active
    Write-Host "Get-OCIFileStorageExport -ExportId $Export.Id -WaitForLifecycleState $FileStorageState"
    Get-OCIFileStorageExport -ExportId $Export.Id -WaitForLifecycleState $FileStorageState | Out-Host

    Write-Host "Get-OCIFileStorageExportsList -CompartmentId $CompartmentId -All"
    Get-OCIFileStorageExportsList -CompartmentId $CompartmentId -All | Out-Host

    $CreateSnapshotDetails = New-Object Oci.FilestorageService.Models.CreateSnapshotDetails
    $CreateSnapshotDetails.Name = $DisplayName
    $CreateSnapshotDetails.FileSystemId = $FileSysytem.Id

    Write-Host "New-OCIFileStorageSnapshot -CreateSnapshotDetails $CreateSnapshotDetails"
    $Snapshot = New-OCIFileStorageSnapshot -CreateSnapshotDetails $CreateSnapshotDetails

    $Snapshot

    $SnapshotState = [Oci.FilestorageService.Models.Snapshot+LifecycleStateEnum]::Active
    Write-Host "Get-OCIFileStorageSnapshot -SnapshotId $Snapshot.Id -WaitForLifecycleState  $SnapshotState"
    Get-OCIFileStorageSnapshot -SnapshotId $Snapshot.Id -WaitForLifecycleState  $SnapshotState | Out-Host

    #Clean up
    Write-Host "Remove-OCIFileStorageSnapshot -SnapshotId $Snapshot.Id"
    Remove-OCIFileStorageSnapshot -SnapshotId $Snapshot.Id

    Write-Host "Remove-OCIFileStorageExport -ExportId $Export.Id"
    Remove-OCIFileStorageExport -ExportId $Export.Id

    Write-Host "Remove-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id"
    Remove-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id

    #Wait for Mount target to get deleted https://docs.cloud.oracle.com/en-us/iaas/Content/File/Troubleshooting/orphanedmounttarget.htm
    $MountTargetState = [Oci.FilestorageService.Models.MountTarget+LifecycleStateEnum]::Deleted
    Write-Host "Get-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id -WaitForLifecycleState $MountTargetState"
    Get-OCIFileStorageMountTarget -MountTargetId $MountTarget.Id -WaitForLifecycleState $MountTargetState
}
finally {
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
        
    if ($null -ne $FileSysytem.Id) {
        Write-Host "Remove-OCIFileStorageFileSystem -FileSystemId $FileSysytem.Id"
        Remove-OCIFileStorageFileSystem -FileSystemId $FileSysytem.Id
    }

    if ($null -ne $Subnet.Id) {
        #Force Remove the Subnet
        Write-Host "Remove-OCIVirtualNetworkSubnet -SubnetId $Subnet.Id -Force -FullResponse"
        Remove-OCIVirtualNetworkSubnet -SubnetId $Subnet.Id -Force -FullResponse | Out-Host
    }

    if ($null -ne $Vcn.Id) {
        #Force Remove the created Vcn and associated resources (defaults)
        Write-Host "Remove-OCIVirtualNetworkVcn -VcnId $Vcn.Id -Force -FullResponse"
        Remove-OCIVirtualNetworkVcn -VcnId $Vcn.Id -Force -FullResponse | Out-Host
    }
    $ErrorActionPreference = $UserErrorActionPreference
}
