<#
This examples demonstrates how to work with Stream inputs/ouputs using some features introduced by OCI PS Modules.
This example requires:
1) Module OCI.PSModules.Objectstorage. Install the module from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}
try {
    #Import the module
    Import-Module OCI.PSModules.Objectstorage

    #Setup
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $BucketName = $DisplayName -join "Bucket"
    $ObjectName = $DisplayName -Join "Object"
    $FileName = $DisplayName + ".txt"
    $OutputFileName = "Out" + $FileName

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    #Get the namespace of the account
    Write-Host "Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId"
    $NamespaceName = Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId

    $NamespaceName 

    #Create bucket details
    $BucketDetails = New-Object System.Management.Automation.PSObject
    $BucketDetails | Add-Member -Name “CompartmentId” -Value $CompartmentId -MemberType NoteProperty
    $BucketDetails | Add-Member -Name “Name” -Value $BucketName -MemberType NoteProperty

    #Create a new object store bucket
    Write-Host "New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails"
    $Bucket = New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails

    #Read the last response from history
    $OCICmdletHistory.LastResponse.Bucket

    #Create a text file 
    "Great to see you here! We are here to help you get started on your cloud(-nine) journey." > $FileName

    #Put an object into the created bucket
    Write-Host "Write-OCIObjectStorageObject -NamespaceName $NamespaceName -BucketName $Bucket.Name -ObjectName $ObjectName -PutObjectBodyFromFile $FileName -FullResponse"
    Write-OCIObjectStorageObject -NamespaceName $NamespaceName -BucketName $Bucket.Name -ObjectName $ObjectName -PutObjectBodyFromFile $FileName -FullResponse | Out-Host

    #Read the object back from storage as a Stream
    Write-Host  "Get-OCIObjectStorageObject -NamespaceName $NamespaceName -ObjectName $ObjectName -BucketName $BucketName"
    $Stream = Get-OCIObjectStorageObject -NamespaceName $NamespaceName -ObjectName $ObjectName -BucketName $BucketName 

    $Stream

    #Read the object back from storage and write it to a file
    Write-Host "Get-OCIObjectStorageObject -NamespaceName $NamespaceName -ObjectName $ObjectName -BucketName $BucketName -OutputFile $OutputFileName"
    Get-OCIObjectStorageObject -NamespaceName $NamespaceName -ObjectName $ObjectName -BucketName $BucketName -OutputFile $OutputFileName

    Write-Host "File read from Object Store:"
    Cat $OutputFileName
}
finally {
    #To Maximize possible clean ups continue on error 
    $ErrorActionPreference = "Continue"
        
    if ($null -ne $Stream) {
        #Remove the created object asking explicit user confirmation
        Write-Host "Remove-OCIObjectStorageObject -NamespaceName $NamespaceName -BucketName $BucketName -ObjectName $ObjectName"
        Remove-OCIObjectStorageObject -NamespaceName $NamespaceName -BucketName $BucketName -ObjectName $ObjectName
    }

    if ($null -ne $Bucket) {
        #Remove the created bucket asking explicit user confirmation
        Write-Host "Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse"
        Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse
    }

    #CleanUp
    if (Test-Path -Path $FileName) {
        rm $FileName
    }
    if (Test-Path -Path $OutputFileName) {
        rm $OutputFileName
    }
    $ErrorActionPreference = $UserErrorActionPreference
}
