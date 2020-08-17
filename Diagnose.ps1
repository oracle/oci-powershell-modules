<#
Copyright (c) 2020, Oracle and/or its affiliates.
This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
#>
param (
    [System.IO.DirectoryInfo]$OutputDirectory,
    [bool] $CollectCmdHistory = $false
)

#Decide output file path
if ($null -eq $OutputDirectory) {
    $OutputFile = $pwd
}
else {
    $OutputFile = $OutputDirectory.ToString() | Resolve-Path  
}

$CurrentDate = Get-Date -Format "HH_mm_MM_dd_yyyy"
$OutputFile = Join-Path -Path $OutputFile -ChildPath $CurrentDate.Insert($CurrentDate.Length, "_PSSession.txt") 

Write-Host "Gathering current session info..."

Get-Date | Out-File -FilePath $OutputFile

#Get the Powershell version
"$PSVersiontable : `n" | Out-File -FilePath $OutputFile -Append 
$PSVersiontable | Out-File -FilePath $OutputFile -Append 

#Get all versions of installed OCI modules
"Get-InstalledOCIModules : " | Out-File -FilePath $OutputFile -Append 
Get-InstalledModule -Name "OCI.PSModules.*" | ForEach-Object {
    Get-InstalledModule -Name $_.Name -AllVersions | Out-File -FilePath $OutputFile -Append 
}

#Get all OCI modules loaded into current session
"Loaded OCI Modules  : " | Out-File -FilePath $OutputFile -Append 
Get-Module -All -Name "OCI.*" | Out-File -FilePath $OutputFile -Append 

#Get all loaded OCI assemblies
"Loaded OCI Assemblies : " | Out-File -FilePath $OutputFile -Append 
[System.AppDomain]::CurrentDomain.GetAssemblies() | Where-Object FullName -Match "^(OCI|oci)" | Sort-Object -Property FullName | Select-Object -Property FullName, Location | Out-File -FilePath $OutputFile -Append 

if ($CollectCmdHistory) {
    #Get the command history to see the sequence of last 20 commands that user has executed
    $Count = 20
    Write-Host "`nLast $Count Commands executed :"
    Get-History -Count $Count
    Write-Host ""

    $Title = 'Command History'
    $Question = 'Do you agree to store the last 20 commands in the diagnostic file ?'
    $Choices = '&Yes', '&No'
    $Decision = $Host.UI.PromptForChoice($Title, $Question, $Choices, 1)
    $StoreHistory = $false

    if (0 -eq $Decision) {
        Write-Host ""
        Write-Warning "Please make sure the above command history doesn't have any sensitive info like OCID, passwords, path to SSH Keys etc"
        $Question = "Are you sure you want to proceed?"
        $Decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)
        if (0 -eq $Decision) {
            $StoreHistory = $true
        }
    }

    if ($true -eq $StoreHistory) {
        "Last $Count Commands executed :" | Out-File -FilePath $OutputFile -Append 
        Get-History -Count $Count | Out-File -FilePath $OutputFile -Append 
    }
    else {
        Write-Host "`nNo worries! Not adding command history to diagnostic file. :)"
    }
}
Write-Host "`nSession info saved to $OutputFile"