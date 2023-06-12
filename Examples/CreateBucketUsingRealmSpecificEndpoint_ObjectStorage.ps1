<#
This example demonstrates listing Buckets in the Object Storage Service using the.
This example requires:
1) Module OCI.PSModules.Objectstorage. Install the module from Powershell Gallery.
2) Setting the $env:CompartmentId environment variable to a valid Compartment OCID.
3) Setting the $env:DisplayName environment variable.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId) -or [string]::IsNullOrEmpty($env:DisplayName)) {
    Throw 'Configure $env:CompartmentId and $env:DisplayName in the PS Session'
}

try {
    # Import the module
    Import-Module OCI.PSModules.Objectstorage

    # Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $BucketName = $env:DisplayName

    # Get the namespace of the account
    Write-Host "Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -UseRealmSpecificEndpoint -Debug"
    $NamespaceName = Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -UseRealmSpecificEndpoint -Debug

    $NamespaceName 

    #Create bucket details
    $BucketDetails = New-Object Oci.ObjectstorageService.Models.CreateBucketDetails
    $BucketDetails.CompartmentId = $CompartmentId 
    $BucketDetails.Name = $BucketName

    # Create a new Object Storage bucket
    Write-Host "New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -UseRealmSpecificEndpoint -Debug"
    $Bucket = New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -UseRealmSpecificEndpoint -Debug

    Write-Host "Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -UseRealmSpecificEndpoint -Debug"
    Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName  -UseRealmSpecificEndpoint -Debug | Out-Host
}
finally {
    Write-Host "Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse"
    Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse
    $ErrorActionPreference = $UserErrorActionPreference
}
