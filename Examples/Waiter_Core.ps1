<#
This examples demonstrates waiters concept introduced by OCI PS Modules.
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
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $AvailabilityDomain = 'Iocq:PHX-AD-1'
    $CidrBlock = '10.0.0.0/16'

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

    #Pick the first available image for the compute instance
    Write-Host "Get-OCIComputeImagesList -Limit 1 -CompartmentId $CompartmentId"
    $Image = Get-OCIComputeImagesList -Limit 1 -CompartmentId $CompartmentId

    #Print the image details
    $Image

    #Create compute instance properties
    $LaunchDetails = New-Object -TypeName Oci.CoreService.Models.LaunchInstanceDetails
    $LaunchDetails.AvailabilityDomain = $AvailabilityDomain
    $LaunchDetails.CompartmentId = $CompartmentId
    $LaunchDetails.ImageId = $Image.Id
    $LaunchDetails.Shape = 'VM.Standard2.1'
    $LaunchDetails.SubnetId = $Subnet.Id
    $LaunchDetails.DisplayName = $DisplayName

    #Create a new compute instance and wait for the instance work request to succeed
    Write-Host "New-OCIComputeInstance -LaunchInstanceDetails $LaunchDetails -WaitForStatus Succeeded -MaxWaitAttempts 20"
    $ComputeInstance = New-OCIComputeInstance -LaunchInstanceDetails $LaunchDetails -WaitForStatus Succeeded -MaxWaitAttempts 20 

    #Created compute instance
    $ComputeInstance

    #Get the status of compute instance
    Write-Host "Get-OCIComputeInstance -InstanceId $ComputeInstance.Id"
    Get-OCIComputeInstance -InstanceId $ComputeInstance.Id | Out-Host

    #Force terminate the compuet instance without asking for confirmation to terminate the instance
    Write-Host "Invoke-OCIComputeTerminateInstance -InstanceId $ComputeInstance.Id -Force -FullResponse"
    Invoke-OCIComputeTerminateInstance -InstanceId $ComputeInstance.Id -Force -FullResponse | Out-Host

    #Wait for the compute instance to be terminated
    Write-Host "Get-OCIComputeInstance -InstanceId $ComputeInstance.Id -WaitForLifecycleState Terminated -MaxWaitAttempts 15"
    Get-OCIComputeInstance -InstanceId $ComputeInstance.Id -WaitForLifecycleState Terminated -MaxWaitAttempts 15 | Out-Host
}
finally {
    #To Maximize possible clean ups continue on error 
    $ErrorActionPreference = "Continue"
        
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
