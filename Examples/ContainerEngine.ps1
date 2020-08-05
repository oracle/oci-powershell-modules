<#
This example demonstrates working with various resources in Container Engine Service. 
This example requires:
1) Modules OCI.PSModules.ContainerEngine. Install the modules from Powershell Gallery.
2) Modules OCI.PSModules.Core. Install the modules from Powershell Gallery.
3) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.ContainerEngine
    Import-Module OCI.PSModules.Core

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $CidrBlock = '10.0.0.0/16'
    $AvailabilityDomain = 'Iocq:PHX-AD-1'

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

    #2 Subnets - 1 for Cluster and 1 for Node Pool
    $SubnetList = New-Object 'Collections.Generic.List[string]'
    $SubnetCount = 0
    do {
        #Set Subnet properties
        $SubnetProperties = @{
            displayName   = $DisplayName + "Subnet$SubnetCount"
            cidrBlock     = "10.0.$SubnetCount.0/24"
            vcnId         = $Vcn.Id
            compartmentId = $CompartmentId
        }

        #Create a subnet details object
        $SubnetDetails = New-Object -TypeName 'Oci.CoreService.Models.CreateSubnetDetails' -Property $SubnetProperties

        #Create a Subnet
        Write-Host "New-OCIVirtualNetworkSubnet -CreateSubnetDetails $SubnetDetails"
        $Subnet = New-OCIVirtualNetworkSubnet -CreateSubnetDetails $SubnetDetails
        $SubnetList.Add($Subnet.Id)
        #Examine the created subnet
        $Subnet
        $SubnetCount++

    }while ($SubnetCount -lt 2)

    Write-Host "Get-OCIContainerEngineClusterOptions -ClusterOptionId "all" -CompartmentId $env:CompartmentId"
    Get-OCIContainerEngineClusterOptions -ClusterOptionId "all" -CompartmentId $env:CompartmentId | Out-Host

    $KubeVersion = $OCICmdletHistory.LastResponse.ClusterOptions.KubernetesVersions[0]

    $CreateClusterDetails = New-Object "Oci.ContainerengineService.Models.CreateClusterDetails"
    $CreateClusterDetails.CompartmentId = $CompartmentId
    $CreateClusterDetails.KubernetesVersion = $KubeVersion
    $CreateClusterDetails.Name = $DisplayName
    $CreateClusterDetails.VcnId = $Vcn.Id
    $CreateClusterDetails.Options = New-Object Oci.ContainerengineService.Models.ClusterCreateOptions
    $CreateClusterDetails.Options.ServiceLbSubnetIds = $SubnetList[0]

    #Create a new cluster
    Write-Host "New-OCIContainerEngineCluster -CreateClusterDetails $CreateClusterDetails"
    New-OCIContainerEngineCluster -CreateClusterDetails $CreateClusterDetails | Out-Host

    #Wait for the cluster to be created
    Write-Host "Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus 'Succeeded' -MaxWaitAttempts 15"
    Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus "Succeeded" -MaxWaitAttempts 15 | Out-Host

    Write-Host "Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.WorkRequest.Id"
    Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.WorkRequest.Id | Out-Host

    #Only one resource associated with this work request so just fetch index 0
    $ClusterId = $OCICmdletHistory.LastResponse.WorkRequest.Resources[0].Identifier
    Write-Host "Get-OCIContainerEngineCluster -ClusterId $ClusterId"
    Get-OCIContainerEngineCluster -ClusterId $ClusterId | Out-Host

    #Update the name of the created resource
    $UpdateClusterDetails = New-Object "Oci.ContainerengineService.Models.UpdateClusterDetails"
    $UpdateClusterDetails.Name = $DisplayName + "-2.0"
    Write-Host "Update-OCIContainerEngineCluster -ClusterId $ClusterId -UpdateClusterDetails $UpdateClusterDetails"
    Update-OCIContainerEngineCluster -ClusterId $ClusterId -UpdateClusterDetails $UpdateClusterDetails | Out-Host

    Write-Host "Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus 'Succeeded' -MaxWaitAttempts 15"
    Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus "Succeeded" -MaxWaitAttempts 15 | Out-Host

    Write-Host "Get-OCIContainerEngineCluster -ClusterId $ClusterId"
    Get-OCIContainerEngineCluster -ClusterId $ClusterId | Out-Host

    $CreateNodePoolDetails = New-Object Oci.ContainerengineService.Models.CreateNodePoolDetails
    $CreateNodePoolDetails.Name = $DisplayName
    $CreateNodePoolDetails.NodeShape = "VM.Standard2.1"
    $CreateNodePoolDetails.CompartmentId = $CompartmentId
    $CreateNodePoolDetails.ClusterId = $ClusterId
    $CreateNodePoolDetails.KubernetesVersion = $KubeVersion
    $CreateNodePoolDetails.NodeImageName = "Oracle-Linux-7.6"
    $CreateNodePoolDetails.NodeConfigDetails = New-Object Oci.ContainerengineService.Models.CreateNodePoolNodeConfigDetails
    $CreateNodePoolDetails.NodeConfigDetails.Size = 1
    $NodePlacementConfig = New-Object Oci.ContainerengineService.Models.NodePoolPlacementConfigDetails
    $NodePlacementConfig.SubnetId = $SubnetList[1]
    $NodePlacementConfig.AvailabilityDomain = $AvailabilityDomain
    $CreateNodePoolDetails.NodeConfigDetails.PlacementConfigs = New-Object "Collections.Generic.List[Oci.ContainerengineService.Models.NodePoolPlacementConfigDetails]"
    $CreateNodePoolDetails.NodeConfigDetails.PlacementConfigs.Add($NodePlacementConfig)

    #Create Node pool in the cluster
    Write-Host "New-OCIContainerEngineNodePool -CreateNodePoolDetails $CreateNodePoolDetails"
    New-OCIContainerEngineNodePool -CreateNodePoolDetails $CreateNodePoolDetails

    #Wait for node pool to be created
    Write-Host "Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus 'Succeeded' -MaxWaitAttempts 15"
    Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.OpcWorkRequestId -WaitForStatus "Succeeded" -MaxWaitAttempts 15 | Out-Host

    Write-Host "Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.WorkRequest.Id"
    Get-OCIContainerEngineWorkRequest -WorkRequestId $OCICmdletHistory.LastResponse.WorkRequest.Id | Out-Host

    $NodePoolId = $OCICmdletHistory.LastResponse.WorkRequest.Resources[0].Identifier
    Write-Host "Get-OCIContainerEngineNodePool -NodePoolId $NodePoolId "
    Get-OCIContainerEngineNodePool -NodePoolId $NodePoolId | Out-Host
}
finally {
    #cleanup
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
    
    Write-Host "Clean up started ..."
    if ($null -ne $NodePoolId) {
        Write-Host "Remove-OCIContainerEngineNodePool -NodePoolId $NodePoolId"
        Remove-OCIContainerEngineNodePool -NodePoolId $NodePoolId | Out-Host
    }

    if ($null -ne $ClusterId) {
        Write-Host "Remove-OCIContainerEngineCluster -ClusterId $ClusterId" | Out-Host
        Remove-OCIContainerEngineCluster -ClusterId $ClusterId
    }

    if ($SubnetList.Count -gt 0) {
        $SubnetList | ForEach-Object {
            Write-Host "Remove-OCIVirtualNetworkSubnet -SubnetId $_"
            Remove-OCIVirtualNetworkSubnet -SubnetId $_ | Out-Host
        }
    }

    if ($null -ne $Vcn.Id) {
        Write-Host "Remove-OCIVirtualNetworkVcn -VcnId $Vcn.Id"
        Remove-OCIVirtualNetworkVcn -VcnId $Vcn.Id | Out-Host
    }

    Write-Warning "Resources might be getting cleaned up in the tenancy.."
    $ErrorActionPreference = $UserErrorActionPreference
}
