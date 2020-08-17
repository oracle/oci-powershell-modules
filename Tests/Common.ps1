function GenerateModuleAssemblies {
    param (
        [Parameter(Mandatory = $true)]
        [string]$ModuleName
    )
    Push-Location
    Set-Location $PSScriptRoot/../$ModuleName
    dotnet publish -o assemblies
    Pop-Location
}

function GetRootCompartmentId {
    if ([string]::IsNullOrEmpty($env:ConfigFile)) {
        Throw "Config file cannot be null. Plese set env:ConfigFile variable before running the tests"
    }
    # Fetch compartment id from the config file.
    $ConfigFile = [Oci.Common.ConfigFileReader]::Parse($env:ConfigFile, "DEFAULT")
    $CompartmentId = $ConfigFile.GetValue("tenancy")
    Write-Output $CompartmentId
}