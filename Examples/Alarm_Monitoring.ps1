<#
This example demonstrates working with Alarm Resource in Monitoring Service
This example requires:
1) Modules OCI.PSModules.Monitoring. Install the modules from Powershell Gallery.
2) Modules OCI.PSModules.Ons. Install the modules from Powershell Gallery.
3) Setting up the environment variable CompartmentId to a Compartment OCID.
#>
$UserErrorActionPreference = $ErrorActionPreference
$ErrorActionPreference = "Stop" 
if ([string]::IsNullOrEmpty($env:CompartmentId)) {
    Throw 'Configure $env:CompartmentId in the PS Session'
}

try {
    #Import the modules
    Import-Module OCI.PSModules.Monitoring
    Import-Module OCI.PSModules.Ons

    #Read CompartmentId environment variable 
    $CompartmentId = $env:CompartmentId

    #Setup
    $RandomSufix = Get-Random -Minimum 1 -Maximum 1000
    $DisplayName = "PSExample" + $RandomSufix
    $SourceService = "oci_compartment"
    $Query = "CpuUtilization[1m].max() > 75"
    $Severity = [Oci.MonitoringService.Models.Alarm+SeverityEnum]::Error
    $CurrentDT = Get-Date

    $CreateTopicDetails = New-Object Oci.OnsService.Models.CreateTopicDetails
    $CreateTopicDetails.CompartmentId = $CompartmentId
    $CreateTopicDetails.Description = "Topic created for Powershell examples. Delete at sight! :P"
    $CreateTopicDetails.Name = $DisplayName

    #Create Topic
    Write-Host "New-OCIOnsTopic -CreateTopicDetails $CreateTopicDetails"
    $Topic = New-OCIOnsTopic -CreateTopicDetails $CreateTopicDetails 

    $Topic

    $Destinations = New-Object 'Collections.Generic.List[string]'
    $Destinations.Add($Topic.TopicId)

    $CreateAlarmDetails = New-Object Oci.MonitoringService.Models.CreateAlarmDetails
    $CreateAlarmDetails.CompartmentId = $CompartmentId
    $CreateAlarmDetails.Destinations = $Destinations
    $CreateAlarmDetails.DisplayName = $DisplayName
    $CreateAlarmDetails.IsEnabled = $true
    $CreateAlarmDetails.MetricCompartmentId = $CompartmentId
    $CreateAlarmDetails.Namespace = $SourceService
    $CreateAlarmDetails.Query = $Query
    $CreateAlarmDetails.Severity = $Severity

    #Create Alarm
    Write-Host "New-OCIMonitoringAlarm -CreateAlarmDetails $CreateAlarmDetails"
    $Alarm = New-OCIMonitoringAlarm -CreateAlarmDetails $CreateAlarmDetails

    $Alarm

    $UpdateAlarmDetails = New-Object Oci.MonitoringService.Models.UpdateAlarmDetails
    $UpdateAlarmDetails.Suppression = New-Object Oci.MonitoringService.Models.Suppression
    $UpdateAlarmDetails.Suppression.TimeSuppressFrom = $CurrentDT
    $UpdateAlarmDetails.Suppression.TimeSuppressUntil = $CurrentDT.AddDays(1)

    #Suppress Alarm
    Write-Host "Update-OCIMonitoringAlarm -AlarmId $Alarm.Id -UpdateAlarmDetails $UpdateAlarmDetails"
    Update-OCIMonitoringAlarm -AlarmId $Alarm.Id -UpdateAlarmDetails $UpdateAlarmDetails

    #Remove Alarm Suppression
    Write-Host "Remove-OCIMonitoringAlarmSuppression -AlarmId $Alarm.Id"
    Remove-OCIMonitoringAlarmSuppression -AlarmId $Alarm.Id

    Write-Host "Get-OCIMonitoringAlarm -AlarmId $Alarm.Id"
    Get-OCIMonitoringAlarm -AlarmId $Alarm.Id

    Write-Host "Get-OCIMonitoringAlarmHistory -AlarmId $Alarm.Id"
    Get-OCIMonitoringAlarmHistory -AlarmId $Alarm.Id

    Write-Host "Get-OCIMonitoringAlarmsList -All -CompartmentId $CompartmentId"
    Get-OCIMonitoringAlarmsList -All -CompartmentId $CompartmentId

    Write-Host "Get-OCIMonitoringAlarmsStatusList -CompartmentId $CompartmentId -All"
    Get-OCIMonitoringAlarmsStatusList -CompartmentId $CompartmentId -All

}
finally {
    #To Maximize possible clean ups continue on error 
    $ErrorActionPreference = "Continue"
    
    if ($null -ne $Alarm.Id) {
        Write-Host "Remove-OCIMonitoringAlarm -AlarmId $Alarm.Id"
        Remove-OCIMonitoringAlarm -AlarmId $Alarm.Id
    }

    if ($null -ne $Topic.TopicId) {
        Write-Host "Remove-OCIOnsTopic -TopicId $Topic.TopicId"
        Remove-OCIOnsTopic -TopicId $Topic.TopicId
    
    }
    $ErrorActionPreference = $UserErrorActionPreference
}