<#
This example demonstrates working with Authetication Policy Resource in Identity Service.
This example requires:
1) Modules OCI.PSModules.Identity. Install the modules from Powershell Gallery.
2) Setting up the environment variable TenancyId to a Tenancy OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId) -or [string]::IsNullOrEmpty($env:TenancyId)) {
    Throw 'Configure $env:CompartmentId and $env:TenancyId in the PS Session'
}
try {
    #Import the modules
    Import-Module OCI.PSModules.Identity

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId
    $TenancyId = $env:TenancyId

    Write-Host "Get-OCIIdentityAuthenticationPolicy -CompartmentId $TenancyId"
    $ExistingPolicy = (Get-OCIIdentityAuthenticationPolicy -CompartmentId $TenancyId).PasswordPolicy

    $ExistingPolicy

    #create new password policy based on existing policy
    $NewPolicy = New-Object -TypeName Oci.IdentityService.Models.PasswordPolicy -Property @{ MinimumPasswordLength = $ExistingPolicy.MinimumPasswordLength + 1 ; IsLowercaseCharactersRequired = $ExistingPolicy.IsLowercaseCharactersRequired ; IsNumericCharactersRequired = $ExistingPolicy.IsNumericCharactersRequired ; IsSpecialCharactersRequired = $ExistingPolicy.IsSpecialCharactersRequired; IsUppercaseCharactersRequired = $ExistingPolicy.IsUppercaseCharactersRequired; IsUsernameContainmentAllowed = $ExistingPolicy.IsUsernameContainmentAllowed }

    #Create new authentication policy 
    $AuthPolicyDetails = New-Object -TypeName Oci.IdentityService.Models.UpdateAuthenticationPolicyDetails
    $AuthPolicyDetails.PasswordPolicy = $NewPolicy

    Write-Host "Newly created Password Policy :"
    $AuthPolicyDetails.PasswordPolicy

    Write-Host "Update-OCIIdentityAuthenticationPolicy -UpdateAuthenticationPolicyDetails $AuthPolicyDetails -CompartmentId $TenancyId"
    Update-OCIIdentityAuthenticationPolicy -UpdateAuthenticationPolicyDetails $AuthPolicyDetails -CompartmentId $TenancyId

    $OCICmdletHistory.LastResponse.AuthenticationPolicy.PasswordPolicy


}
finally {
    #clean-up
    #To Maximize possible clean ups, continue on error 
    $ErrorActionPreference = "Continue"
    
    if ($null -ne $ExistingPolicy) {
        $AuthPolicyDetails.PasswordPolicy = $ExistingPolicy

        Write-Host "Reverting old policy.."
        $AuthPolicyDetails.PasswordPolicy
    
        Write-Host "Update-OCIIdentityAuthenticationPolicy -UpdateAuthenticationPolicyDetails $AuthPolicyDetails -CompartmentId $TenancyId"
        Update-OCIIdentityAuthenticationPolicy -UpdateAuthenticationPolicyDetails $AuthPolicyDetails -CompartmentId $TenancyId
    }  
    $ErrorActionPreference = $UserErrorActionPreference
}