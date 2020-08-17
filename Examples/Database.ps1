<#
This example demonstrates working with various resources in Database Service.
This example requires:
1) Modules OCI.PSModules.Database,OCI.PSModules.Identity,OCI.PSModules.Core. Install the modules from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>

$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.Database
    Import-Module OCI.PSModules.Identity
    Import-Module OCI.PSModules.Core

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    #Setup
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $CidrBlock = '10.0.0.0/16'
    $HostName = $DisplayName + 'Host'
    $DbName = 'Db' + $RandomSufix
    $DbDomain = $DisplayName + 'Domain'
    $DbHomeName = $DisplayName + 'DbHome'
    $DbShape = 'BM.DenseIO2.52'

    #Get Availability domain list
    Write-Host "Get-OCIIdentityAvailabilityDomainsList -CompartmentId $CompartmentId"
    Get-OCIIdentityAvailabilityDomainsList -CompartmentId $CompartmentId | Out-Host

    Write-Host "Picking AD :"
    $AD = $OCICmdletHistory.LastResponse.Items | Select-Object -first 1

    $AD

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

    #Create SSH-Keys
    $Basepath = Get-Location
    $Filepath = Join-Path $Basepath 'examplekey'
    $Pubkeypath = $Filepath + ".pub"
    ssh-keygen -f $Filepath -N "encrypt" #This example uses bare minimum detils to generate keys. In production specify more secure key gen options. 
    $Pubkey = [IO.File]::ReadAllText($Pubkeypath);
    $Keylist = New-Object 'Collections.Generic.List[string]'
    $Keylist.Add($Pubkey)

    $Pubkey

    #Create DB Details
    $CreateDbDetails = New-Object "Oci.DatabaseService.Models.CreateDatabaseDetails"
    $CreateDbDetails.AdminPassword = "ATle##19chars"
    $CreateDbDetails.DbName = $DbName

    $CreateDbHomeDetails = New-Object "Oci.DatabaseService.Models.CreateDbHomeDetails"
    $CreateDbHomeDetails.DbVersion = '12.1.0.2'
    $CreateDbHomeDetails.DisplayName = $DbHomeName
    $CreateDbHomeDetails.Database = $CreateDbDetails

    $LaunchDbSystemDetails = New-Object "Oci.DatabaseService.Models.LaunchDbSystemDetails"
    $LaunchDbSystemDetails.AvailabilityDomain = $AD.Name
    $LaunchDbSystemDetails.CompartmentId = $CompartmentId
    $LaunchDbSystemDetails.CpuCoreCount = 4
    $LaunchDbSystemDetails.Shape = $DbShape
    $LaunchDbSystemDetails.SshPublicKeys = $Keylist
    $LaunchDbSystemDetails.SubnetId = $Subnet.Id
    $LaunchDbSystemDetails.DatabaseEdition = [Oci.DatabaseService.Models.LaunchDbSystemDetails+DatabaseEditionEnum]::StandardEdition
    $LaunchDbSystemDetails.DisplayName = $DisplayName
    $LaunchDbSystemDetails.Domain = $DbDomain
    $LaunchDbSystemDetails.Hostname = $HostName
    $LaunchDbSystemDetails.DbHome = $CreateDbHomeDetails

    #Create new database system
    Write-Host "New-OCIDatabaseDbSystem -LaunchDbSystemDetails $LaunchDbSystemDetails"
    $DB = New-OCIDatabaseDbSystem -LaunchDbSystemDetails $LaunchDbSystemDetails

    $DB

    #Wait for the dbsystem to become available.
    #Since DBSystems usually take a long time to become available, attempt to wait for 1 hour (60 attempts with 60 sec duration between attempts)
    Write-Host "Get-OCIDatabaseDbSystem -DbSystemId $Db.Id -WaitForLifecycleState Available -MaxWaitAttempts 60 -WaitIntervalSeconds 60"
    Get-OCIDatabaseDbSystem -DbSystemId $Db.Id -WaitForLifecycleState Available -MaxWaitAttempts 60 -WaitIntervalSeconds 60 | Out-Host

}
finally {
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
        
    #Terminate the dbsystem asking user's confirmation
    if ($null -ne $Db.Id) {
        Write-Host "Invoke-OCIDatabaseTerminateDbSystem -DbSystemId $Db.Id -WaitForStatus Succeeded -MaxWaitAttempts 10"
        Invoke-OCIDatabaseTerminateDbSystem -DbSystemId $Db.Id -WaitForStatus Succeeded -MaxWaitAttempts 10 | Out-Host
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
    #Cleanup
    if (Test-Path -Path $Filepath) {
        rm $Filepath
    }

    if (Test-Path -Path $Pubkeypath) {
        rm $Pubkeypath
    }
    $ErrorActionPreference = $UserErrorActionPreference
}
