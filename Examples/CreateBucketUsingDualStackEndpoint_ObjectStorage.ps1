<#
This example demonstrates listing Buckets in the Object Storage Service using IPv6 endpoints.
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

    # Read CompartmentId and DisplayName environment variables 
    $CompartmentId = $env:CompartmentId
    $BucketName = $env:DisplayName

    #Create bucket details
    $BucketDetails = New-Object Oci.ObjectstorageService.Models.CreateBucketDetails
    $BucketDetails.CompartmentId = $CompartmentId 
    $BucketDetails.Name = $BucketName


    ###
    ### This portion of the example will create a bucket using dual-stack endpoints, assuming that the service supports it.
    ###

    # Get the namespace of the account
    Write-Host "Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -EnableDualStackEndpoints"
    $NamespaceName = Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -EnableDualStackEndpoints

    # Print the result
    $NamespaceName

    # Create a new Object Storage bucket
    Write-Host "New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -EnableDualStackEndpoints -Debug"
    $Bucket = New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -EnableDualStackEndpoints -Debug

    Write-Host "Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -EnableDualStackEndpoints -Debug"
    Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName  -EnableDualStackEndpoints -Debug | Out-Host

    ###
    ### This portion of the example will create a bucket without dual-stack endpoints, assuming that the service supports it and has enabled it by default.
    ### This part of the example is for demonstration purposes only and will not work unless Object Storage enables dual stack endpoints by default.
    ###

    # # Get the namespace of the account
    # Write-Host "Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -DisableDualStackEndpoints"
    # $NamespaceName = Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId -DisableDualStackEndpoints

    # # Print the result
    # $NamespaceName

    # # Create a new Object Storage bucket
    # Write-Host "New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -DisableDualStackEndpoints -Debug"
    # $Bucket = New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails -DisableDualStackEndpoints -Debug

    # Write-Host "Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -DisableDualStackEndpoints -Debug"
    # Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName  -DisableDualStackEndpoints -Debug | Out-Host

}
finally {
    Write-Host "Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse"
    Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse
    $ErrorActionPreference = $UserErrorActionPreference
}
