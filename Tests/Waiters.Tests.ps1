BeforeAll {
    GenerateModuleAssemblies "Common"
    GenerateModuleAssemblies "Core"
    Import-Module $PSScriptRoot/../Common/OCI.PSModules.Common.psd1
    Import-Module $PSScriptRoot/../Core/OCI.PSModules.Core.psd1

    if (![string]::IsNullOrEmpty($env:CompartmentId)) {
        $CompartmentId = $env:CompartmentId
    }
    else {
        $CompartmentId = GetRootCompartmentId
    }
    
    $ConfigFileLocation = $env:ConfigFile
}

Describe "TestWaiters" {
    It "Verify Waiters params" {
        (Get-Command Get-OCIVirtualNetworkVcn).Parameters.ContainsKey("WaitForLifecycleState") | Should -BeTrue
        (Get-Command Get-OCIVirtualNetworkVcn).Parameters.ContainsKey("WaitIntervalSeconds") | Should -BeTrue
        (Get-Command Get-OCIVirtualNetworkVcn).Parameters.ContainsKey("MaxWaitAttempts") | Should -BeTrue
    }

    Context "Create Virtual Newtorn VCN" {
        It "Verify VCN is created" {
            $RandomSufix = Get-Random -Minimum 1 -Maximum 100000
            $CreateVcnDetails = New-Object "Oci.CoreService.Models.CreateVcnDetails"
            $CreateVcnDetails.CidrBlock = "10.0.0.0/16"
            $CreateVcnDetails.CompartmentId = $CompartmentId
            $CreateVcnDetails.DnsLabel = "PSTest$($RandomSufix)"
            $CreateVcnDetails.DisplayName = "PSTest.$($RandomSufix)"
            $script:vcn = New-OCIVirtualNetworkVcn -CreateVcnDetails $CreateVcnDetails -ConfigFile $ConfigFileLocation
            $script:vcn.id | Should -Not -BeNullOrEmpty
        }
    }

    Context "Verify wait for state" {
        It "Verify the target lifecycle state" {
            $script:vcn = Get-OCIVirtualNetworkVcn -VcnId $vcn.id -WaitForLifecycleState Available, Terminated -WaitIntervalSeconds 30 -ConfigFile $ConfigFileLocation
            $script:vcn.LifecycleState | Should -BeExactly "Available"
        }
        It "Perform Deletion" {
            Remove-OCIVirtualNetworkVcn -VcnId $script:vcn.id -Force -ConfigFile $ConfigFileLocation
        }
    }
}