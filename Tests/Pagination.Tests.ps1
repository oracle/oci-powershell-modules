BeforeAll {
    GenerateModuleAssemblies "Common"
    GenerateModuleAssemblies "Identity"
    Import-Module $PSScriptRoot/../Common/OCI.PSModules.Common.psd1
    Import-Module $PSScriptRoot/../Identity/OCI.PSModules.Identity.psd1
    $CompartmentId = GetRootCompartmentId
    $ConfigFileLocation = $env:ConfigFile
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
}