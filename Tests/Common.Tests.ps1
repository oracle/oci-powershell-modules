BeforeAll {
    GenerateModuleAssemblies "Common"
    GenerateModuleAssemblies "Objectstorage"
    Import-Module $PSScriptRoot/../Common/OCI.PSModules.Common.psd1
    Import-Module $PSScriptRoot/../Objectstorage/OCI.PSModules.Objectstorage.psd1
}

function SampleOciCmdlet {
    try {
        Get-OCIObjectStorageBucketsList -Namespace "DummyCompartment" -Compartment "DummyCompartment" -ConfigFile $env:ConfigFile
    }
    catch {

    }
}

Describe "ReduceHistorySize" {

    It "Verify reduced size" {
        $CurrentSize = Get-OCICmdletHistory -Size
        $ReducedSize = 3
        Set-OCICmdletHistory -Size $ReducedSize
        Get-OCICmdletHistory -Size | Should -BeExactly $ReducedSize

        # Reset the size
        Set-OCICmdletHistory -Size $CurrentSize
    }
}

Describe "ClearHistory" {
    for ($i = 1 ; $i -le $CurrentSize; $i++) {
        SampleOciCmdlet
    }
    
    It "Verify clear history empty response" {
        $resp = Clear-OCICmdletHistory
        $resp | Should -BeNullOrEmpty
    }
   
    It "History count should be zero" {
        $history = Get-OCICmdletHistory
        $history.Count | Should -Be 0
    }
}
