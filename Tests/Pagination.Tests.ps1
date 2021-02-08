BeforeAll {
    GenerateModuleAssemblies "Common"
    GenerateModuleAssemblies "Identity"
    GenerateModuleAssemblies "Audit"
    Import-Module $PSScriptRoot/../Common/OCI.PSModules.Common.psd1
    Import-Module $PSScriptRoot/../Identity/OCI.PSModules.Identity.psd1
    Import-Module $PSScriptRoot/../Audit/OCI.PSModules.Audit.psd1
    $CompartmentId = GetRootCompartmentId
    $ConfigFileLocation = $env:ConfigFile
    $startTime = Get-Date (Get-Date).AddDays(-7) -UFormat "%Y-%m-%dT00:00:00Z"
    $startTimeAll = Get-Date (Get-Date).AddMinutes(-10) -UFormat "%Y-%m-%dT%R:00Z"
    $endTime = Get-Date -UFormat "%Y-%m-%dT%R:00Z"
}

Describe "TestPagination" {
    It "Verify Pagination params" {
        (Get-Command Get-OCIIdentityUsersList).Parameters.ContainsKey("Page") | Should -BeTrue
        (Get-Command Get-OCIIdentityUsersList).Parameters.ContainsKey("Limit") | Should -BeTrue
        (Get-Command Get-OCIIdentityUsersList).Parameters.ContainsKey("All") | Should -BeTrue
    }
  
    It "OpcNextPage is Null or Empty" {
        $resp = Get-OCIIdentityUsersList -CompartmentId $CompartmentId -All -ConfigFile $ConfigFileLocation -FullResponse
        $resp.OpcNextPage | Should -BeNullOrEmpty

        $script:TotalItemCount = $resp.Items.Count
    }
  
    Context "Pagination with Limit 1" {
        It "Should return OPCNextPage" {
            $script:resp = Get-OCIIdentityUsersList -CompartmentId $CompartmentId -Limit 1 -ConfigFile $ConfigFileLocation -FullResponse
            $script:resp.OpcNextPage | Should -Not -BeNullOrEmpty
        }
      
        It "Match results count" {
            $script:resp.Items.Count | Should -BeExactly 1
        }
    }

    It "Verify all pages are returned" {
        $NextPage = $script:resp.OpcNextPage
        $resp = Get-OCIIdentityUsersList -CompartmentId $CompartmentId -Page $NextPage -All -ConfigFile $ConfigFileLocation -FullResponse
        $resp.Items.Count + 1 | Should -BeExactly $script:TotalItemCount
    }

    Context "Suppression warning message" {
        It "Verify warning printing to warning stream" {
            $WarningMessage = "This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources."
            Get-OCIAuditEventsList -CompartmentId $CompartmentId -ConfigFile $ConfigFileLocation -StartTime $startTime -EndTime $endTime -WarningVariable CapturedWarning 3> $null
            $CapturedWarning | Should -Be $WarningMessage
        }

        It "Should not print warning with -All" {
            Get-OCIAuditEventsList  -All -CompartmentId $CompartmentId -ConfigFile $ConfigFileLocation -StartTime $startTimeAll -EndTime $endTime -WarningVariable CapturedWarning
            $CapturedWarning | Should -Be $null
        }

        It "Should not print warning with -Limit" {
            Get-OCIIdentityUsersList -Limit 1 -CompartmentId $CompartmentId -ConfigFile $ConfigFileLocation -WarningVariable CapturedWarning
            $CapturedWarning | Should -Be $null
        }
    }
}