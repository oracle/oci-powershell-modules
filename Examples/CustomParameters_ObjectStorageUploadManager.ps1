<#
This example demonstrates how to use custom upload configurations in an Objectstorage upload.
This example requires:
1) Module OCI.PSModules.Objectstorage. Install the module from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}

function ConfirmDelete {
    $Title = 'Clean up'
    $Question = 'Would you like to remove the reesources created by this example?'
    $Choices = '&Yes', '&No'
    $Decision = $Host.UI.PromptForChoice($Title, $Question, $Choices, 1)
    if (0 -eq $Decision) {
        return $true
    }
    return $false
}

function ConfirmBucketCreation {
    $Title = 'Creating Bucket'
    $Question = "Would you like to create bucket '$bucketName' in the '$namespaceName' namespace? (Select `"N`" if it already exists)"
    $Choices = '&Yes', '&No'
    $Decision = $Host.UI.PromptForChoice($Title, $Question, $Choices, 1)
    if (0 -eq $Decision) {
        return $true
    }
    return $false
}

try {
    # Import the module
    Import-Module OCI.PSModules.Objectstorage

    # Try values other than the defaults
    $LengthPerUploadPartInMiB = 256 # Default is 128
    $ParallelUploadCount = 32 # Default is 3

    # Specify a single file to upload by stream.
    $uploadFile = "$PSScriptRoot/../README.md"
    $ObjectName = "README.md"
    $stream = New-Object IO.FileStream $uploadFile ,'Open','ReadWrite','Read'

    # Create a bucket to upload files.
    $bucketName = "Powershell-UploadManager-Example"
    $namespaceName = Get-OCIObjectstorageNamespace
    $bucketDetails = New-Object Oci.ObjectstorageService.Models.CreateBucketDetails
    $bucketDetails.Name = $bucketName
    $bucketDetails.CompartmentId = $env:CompartmentId

    if(ConfirmBucketCreation){
        New-OCIObjectstorageBucket -NamespaceName $namespaceName -CreateBucketDetails $bucketDetails
    }

    # Upload a single file without AutoAbort.
    Write-Host "Uploading $ObjectName"
    Write-OCIObjectstorageuploadmanagerObject -NamespaceName $namespaceName  -BucketName $bucketName -ObjectName $ObjectName -PutObjectBody $stream -DisableAutoAbort

    # Using file names, upload a few files with the custom upload parameters defined above.
    Get-ChildItem -File -Path $PSScriptRoot | ForEach-Object {
        Write-Host "Uploading $($_.Name)"
        Write-OCIObjectstorageuploadmanagerObject -NamespaceName $namespaceName -BucketName $bucketName -ObjectName $_.Name -PutObjectBodyFromFile $_ -LengthPerUploadPartInMiB $LengthPerUploadPartInMiB -ParallelUploadCount $ParallelUploadCount
    }

    # Remove the files in bucket and delete the bucket.
    if(ConfirmDelete){
        Remove-OCIObjectstorageObject -NamespaceName $namespaceName -BucketName $bucketName -ObjectName $ObjectName -Force

        Get-ChildItem -File -Path $PSScriptRoot | ForEach-Object {
            Remove-OCIObjectstorageObject -NamespaceName $namespaceName -BucketName $bucketName -ObjectName $_.Name -Force
        }

        Remove-OCIObjectstorageBucket -NamespaceName $namespaceName -BucketName $bucketName -Force   
    }

}
finally {
    $ErrorActionPreference = $UserErrorActionPreference
}
