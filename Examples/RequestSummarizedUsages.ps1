<#
This example demonstrates working with the OCI Usage API.
This example requires:
1) Modules OCI.PSModules.Usageapi. Install the modules from Powershell Gallery.
2) Setting up the environment variable TenancyId to your Tenancy OCID.
  [Environment]::SetEnvironmentVariable("TenancyId", "value")
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:TenancyId)) {
  Throw 'Configure $env:TenancyId in the PS Session'
}
try {
  #Import the modules
  Import-Module OCI.PSModules.Usageapi
  
  #Read CompartmentId environment variable 
  $TenancyId = $env:TenancyId
  
  #Create parameters to be used in the call below
  #  The following is a basic example (minimalistic parameters)
  #  See the .NET SDK for details around the parameters for the RequestSummarizedUsageDetails model (type): https://docs.oracle.com/en-us/iaas/tools/dotnet/51.0.0/api/Oci.UsageapiService.Models.RequestSummarizedUsagesDetails.html
  $rqd = [Oci.UsageapiService.Models.RequestSummarizedUsagesDetails]@{
    TenantId = $TenancyId
    # change to granularity needed
    Granularity = "DAILY"
    # change this to whatever start/end date as needed
    TimeUsageStarted = "2022-12-10T00:00:00.000Z"
    TimeUsageEnded = "2022-12-12T00:00:00.000Z"
  }
  #Make the call to get the summarized usage data
  #   See https://docs.oracle.com/en-us/iaas/tools/powershell/47.0.0/articles/Invoke-OCIUsageapiRequestSummarizedUsages.html for more info on available parameters
  $usg = Invoke-OCIUsageapiRequestSummarizedUsages -RequestSummarizedUsagesDetails $rqd
  
  #Inspect the summarized usage data received
  $usg
}
finally {
  $ErrorActionPreference = $UserErrorActionPreference
}
