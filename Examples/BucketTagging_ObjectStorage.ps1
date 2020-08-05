<#
This example demonstrates tagging Buckets Resource in Object Storage Service.
This example requires:
1) Module OCI.PSModules.Objectstorage. Install the module from Powershell Gallery.
2) Setting up the environment variable CompartmentId to a Compartment OCID.
3) Setting up the environment variables TagNS,TagKey to an existing tag namespace and key in your tenancy as explained in https://docs.cloud.oracle.com/Content/General/Concepts/resourcetags.htm
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId) -or [string]::IsNullOrEmpty($env:TagNS) -or [string]::IsNullOrEmpty($env:TagKey)) {
    Throw 'Configure $env:CompartmentId,$env:TagNS and $env:TagKey in the PS Session'
}

try {
    #Import the module
    Import-Module OCI.PSModules.Objectstorage

    #Setup
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $BucketName = $DisplayName -join "Bucket"

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $TagNS = $env:TagNS
    $TagKey = $env:TagKey

    #Get the namespace of the account
    Write-Host "Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId"
    $NamespaceName = Get-OCIObjectStorageNamespace -CompartmentId $CompartmentId

    $NamespaceName 

    $FreeformTags = New-Object 'System.Collections.Generic.Dictionary[String,String]'
    $FreeformTags.Add("FFTagKey", "FFTagValue")
    $Tags = New-Object 'System.Collections.Generic.Dictionary[String,Object]'
    $Tags.Add($TagKey, "DefinedValue")
    $DefinedTags = New-Object 'System.Collections.Generic.Dictionary[String,System.Collections.Generic.Dictionary[String,Object]]'
    $DefinedTags.Add($TagNS, $Tags)

    #Create bucket details
    $BucketDetails = New-Object Oci.ObjectstorageService.Models.CreateBucketDetails
    $BucketDetails.CompartmentId = $CompartmentId 
    $BucketDetails.Name = $BucketName
    $BucketDetails.FreeformTags = $FreeformTags
    $BucketDetails.DefinedTags = $DefinedTags

    #Create a new object store bucket
    Write-Host "New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails"
    $Bucket = New-OCIObjectStorageBucket -NamespaceName $NamespaceName -CreateBucketDetails $BucketDetails

    #Read the last response from history
    $OCICmdletHistory.LastResponse.Bucket

    Write-Host "Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $Bucket.Name"
    Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $Bucket.Name | Out-Host

    Write-Host "List Buckets without tags: Get-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $Bucket.Name"
    Get-OCIObjectStorageBucketsList -NamespaceName $NamespaceName -CompartmentId $CompartmentId -All | Out-Host

    $TagsList = New-Object Collections.Generic.List[Oci.ObjectstorageService.Requests.ListBucketsRequest+FieldsEnum]
    $TagsList.Add([Oci.ObjectstorageService.Requests.ListBucketsRequest+FieldsEnum]::Tags)
    Write-Host "List Buckets with tags:Get-OCIObjectStorageBucketsList -NamespaceName $NamespaceName -CompartmentId $CompartmentId -Fields $TagsList"
    Get-OCIObjectStorageBucketsList -NamespaceName $NamespaceName -CompartmentId $CompartmentId -Fields $TagsList | Out-Host
}
finally {
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
        
    #Remove the created bucket asking explicit user confirmation
    if ($null -ne $Bucket) {
        Write-Host "Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse"
        Remove-OCIObjectStorageBucket -NamespaceName $NamespaceName -BucketName $BucketName -FullResponse
    }

    $ErrorActionPreference = $UserErrorActionPreference
}
