# Change Log
All notable changes to this project will be documented in this file.

The format is based on Keep a [Changelog](https://keepachangelog.com/en/1.0.0/).

## 74.2.0 - 2024-01-30
### Added
Support for OCI Control Center service
Support for giro value set for address rules in the Oracle Store Platform service
Support for giro in tax information for subscriptions in the Oracle Store Platform service
Support for REST connectivity with Oath2 in the Data Integration service
Support for resolver rules limit increase in the DNS service
Support for named credentials in the Database Management service

## 74.1.0 - 2024-01-23
### Added
- Support for the Generative AI service
- Support for additional currencies and countries for paid listings in the Marketplace service
- Support for process sets in the Stack Monitoring service

## 74.0.0 - 2024-01-16
### Added
- Support for resource id filter on the service work requests in the Container Instances service
- Support for polyglot vulnerability audit in the Application Dependency Management service
- Support for create, read, and update operations on peer databases in the Data Safe service
- Support for dimension specific alarm suppressions in the Monitoring service
- Support for calculating audit volume in the Data Safe service
- Support for viewing schema accesses in data safe user assessments in the Data Safe service
- Support for security feature usage in the Data Safe service
- Support for viewing the top security findings in data safe security assessments in the Data Safe service
- Support for additional filters in list findings operation in the Data Safe service
- Support for updating risk level of the specified finding in the Data Safe service
 
### Breaking Changes
- The property `OpcWorkRequestId` was removed from the response model `CreateVulnerabilityAuditResponse.cs` in the Application Dependency Management service in the .NET SDK

## 73.1.0 - 2024-01-09
### Added
- Support for calling Oracle Cloud Infrastructure services in the sa-valparaiso-1 region
- Support for creation of up to 60 containers per container instance in the Container Instances service
- Support for Oracle GoldenGate discovery and monitoring in the Stack Monitoring service
- Support for GoldenGate stream analytics in the GoldenGate service
- Support for backup work requests in MySQL Heatwave service
- Support for create, update, delete and list operations on premise vantage points in the Application Performance Monitoring service
- Support for create, update, delete and list operations on workers in the Application Performance Monitoring service
- Support for host capacity planning for compute instances and host unallocated metrics in the Operations Insights service

## 73.0.0 - 2023-12-12
### Added
- Support for changing compartments of configurations in the PostgreSQL service
- Support for granular policies including compartments, resource types, and recommendations in the Optimizer service
- Support for token exchanges in the Identity Domains service
- Support for Apache HTTP server discovery and monitoring in the Stack Monitoring service
- Support for resource locking in the Data Catalog service
- Support for concurrency throttling in the Data Integration service
- Support for reboot migrations for VMs on dedicated hosts in the Compute service
- Support for connection routing method settings and subnet update in the GoldenGate service
- Support for data discovery of commonly used sensitive types in the Data Safe service
- Support for incremental extraction and updates to the workflows in the Data Integration service
  
### Breaking Changes
- The properties `Etag` and `Configuration` were removed from the model `ChangeConfigurationCompartmentResponse` in the PostgreSQL service in the .NET SDK

## 72.0.0 - 2023-12-04
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-dcc-zurich-1 and the sa-bogota-1 region
- Support for managing certificates of target Servers in the Golden Gate service
- Support for AWR Hub Snapshot ingest endpoints in the Operations Insights service
- Support for reducing false positives in the Application Dependency Management service
- Support for ARM shapes in the Data Science service
- Support for new optional parameters in the upload discovery data API in the Usage service
- Support for multiple clusters in a Software-Defined Data Centers (SDDCs) in the VMWare Solution service
- Support for No/Zero days backup in Autonomous Container Database in the Database service
- Support for provisioning a VM Cluster with a choice of Exadata image version in the Database service
- Support for updating ocpu/ecpu count, local storage, ACD count and Exadata storage on Cloud Autonomous VM Cluster and Autonomous VM Cluster in the Database service
- Support for serial console history in the Database service
- Support for Oracle Linux 8 version database system in the Database service
 
### Breaking Changes
- The cmdlet Get-OCIOcvpSupportedSkusList has been removed in the VMWare Solution service
- The parameter SddcType has been removed from the Get-OCIOcvpSupportedHostShapesList cmdlet in the VMWare Solution service
- The properties `ComputeAvailabilityDomain`, `InstanceDisplayNamePrefix`, `EsxiHostsCount`, `InitialSku`, `VcenterInitialPassword`, `NsxManagerInitialPassword`, `WorkloadNetworkCidr`, `NsxOverlaySegmentName`, `ProvisioningSubnetId`, `VsphereVlanId`, `VmotionVlanId`, `VsanVlanId`, `NsxVTepVlanId`, `NsxEdgeVTepVlanId`, `NsxEdgeUplink1VlanId`, `NsxEdgeUplink2VlanId`, `ReplicationVlanId`, `ProvisioningVlanId`, `HcxInitialPassword`, `HcxVlanId`, `IsHcxEnabled`, `HcxOnPremKey`, `IsHcxEnterpriseEnabled`, `UpgradeLicenses`, `VsphereUpgradeGuide`, `VsphereUpgradeObjects`, `InitialHostShapeName`, `InitialHostOcpuCount`, `IsShieldedInstanceEnabled`, `CapacityReservationId`, `Datastores` were removed from the model `Sddc` in the VMWare Solution service in the .NET SDK
- The properties `ComputeAvailabilityDomain`, `EsxiHostsCount` and `IsHcxEnabled` were removed from the model `SddcSummary` in the VMWare Solution service in the .NET SDK
- The properties `SddcId`, `CurrentSku`, `NextSku`, `FailedEsxiHostId` and `NonUpgradedEsxiHostId` were removed from the model `CreateEsxiHostDetails` in the VMWare Solution service in the .NET SDK
- The properties `ComputeAvailabilityDomain`, `EsxiHostsCount`, `InitialSku`, `IsHcxEnabled`, `HcxVlanId`, `IsHcxEnterpriseEnabled`, `WorkloadNetworkCidr`, `ProvisioningSubnetId`, `VsphereVlanId`, `VmotionVlanId`, `VsanVlanId`, `NsxVTepVlanId`, `NsxEdgeVTepVlanId`, `NsxEdgeUplink1VlanId`, `NsxEdgeUplink2VlanId`, `ReplicationVlanId`, `ProvisioningVlanId`, `InitialHostShapeName`, `InitialHostOcpuCount`, `IsShieldedInstanceEnabled`, `CapacityReservationId`, `InstanceDisplayNamePrefix`, and `Datastores` were removed from the model `CreateSddcDetails` in the VMWare Solution service in the .NET SDK
- The properties `VsphereVlanId`, `VmotionVlanId`, `VsanVlanId`, `NsxVTepVlanId`, `NsxEdgeVTepVlanId`, `NsxEdgeUplink1VlanId`, `NsxEdgeUplink2VlanId`, `ReplicationVlanId`, `ProvisioningVlanId`, `and HcxVlanId` were removed from the model `UpdateSddcDetails` in the VMWare Solution service in the .NET SDK
- The properties `SupportedSddcTypes` and `IsSupportMonthlySku` were removed from the model `SupportedHostShapeSummary` in the VMWare Solution service in the .NET SDK
- The property `NextSku` was removed from the model `UpdateEsxiHostDetails` in the VMWare Solution service in the .NET SDK
- The properties `CurrentSku` and `NextSku` were removed from the models `EsxiHost` and `EsxiHostSummary` in the VMWare Solution service in the .NET SDK
- The models `SupportedSkuSummary`, `SupportedSkuSummaryCollection`, `SddcTypes`, `DatastoreSummary`, `ListSupportedSkusRequest`, and `ListSupportedSkusResponse` were removed from the VMWare Solution service in the .NET SDK

## 71.0.0 - 2023-11-14
### Added
- Support for the PostgreSQL service
- Support for new operations in the Identity Domains service
- Support for enabling, disabling, and renewing SSL/TLS in the Big Data service
- Support for diarization in the AI Speech service
- Support for Capacity Topology API in the Compute service
 
### Breaking Changes
- The type of property `Status` was changed from `string` to `StatusEnum` in the `MyRequest` model in the Identity Domains service in the .NET SDK

## 70.1.0 - 2023-11-07
### Added
- Support for Java Management Service Downloads
- Support for creating autonomous dataguard associations in the Database service
- Support for SaaS administrative user configurations for autonomous database in the Database service
- Support for macOS in the the Java Management service
- Support for distribution and management of deployment rule sets in the Java Management service
- Support for new download location of Oracle Java runtime binaries in the Java Management service
- Support for exporting data across regions in the Java Management service

## 70.0.0 - 2023-10-31
### Added
- Support for calling Oracle Cloud Infrastructure services in the us-saltlake-2 region
- Support for session token authentication
- Support for disaster recovery of load balancers, network load balancers and file systems in the Disaster Recovery service
- Support for performing disaster recovery drills in the Disaster Recovery service
- Support for enterprise SKUs and extensibility in the Stack Monitoring service
- Support for metric extensions in the Stack Monitoring service
- Support for baseline and anomaly detection in the Stack Monitoring service
- Support for integration with Database Management service in the MySQL HeatWave service
- Support for MySQL database management in the Database Management service
- Support for database firewalls in the Data Safe service
 
### Breaking Changes
- The properties `CompartmentId` and `UserAssessmentId` were removed from the `ProfileAggregation` model in the Data Safe service in the .NET SDK

## 69.0.0 - 2023-10-24
### Added
- Support for optional parameters for autonomous container database create and update operations in the Database service
- Support for maintenance runs for autonomous container database resources in the Database service
- Support for runtime unsupported connections for Oracle Database and MySQL database types in the Database Tools service
- Support for PostgreSQL, Generic JDBC connections with runtime unsupported in the Database Tools service
- Support for resource locking in the Database Tools service
- Support for proxy sessions for Oracle database connections in the Database Tools service
- Support for global active tables in the NoSQL Database service
- Support for application dependency management (ADM) remediation features in the Application Dependency Management service
- Support for additional connections types for Amazon Kinesis, Amazon Redshift, Elasticsearch, Generic, Google BigQuery, Google Cloud Storage and Redis Database resources in the Golden Gate service
- Support for optional parameters for the list alarms status operation in the Monitoring Service
 
### Breaking Changes
- The property `OpcRetryToken` was removed from `ChangeDatabaseToolsPrivateEndpointCompartmentRequest` and `ChangeDatabaseToolsConnectionCompartmentRequest` models in the Database Tools service in the .NET SDK

## 68.0.0 - 2023-10-17
### Added
- Support for the Caching Service
- Support for the Marketplace Publisher service
- Support for higher limits for network firewalls in the Network Firewall service
- Support for exporting access request reports in the Lockbox service
- Support for storage mounts for jobs and notebooks in the Data Science service
- Support for unified agent operational metrics for the service configurations in the Logging Management service

### Breaking Changes
- The parameter `ServiceStage` was removed from the Get-OCILoggingServicesList cmdlet in the Logging service
- The properties `DisplayName` and `RqsType` were removed in the `Parameter` model in the Logging Management service in the .NET SDK
- The enum members `EnumString` and `RqsFilter` were remoeved from the enum `TypeEnum` in the `Parameter` model in the Logging Management service in the .NET SDK
- The property `ServiceStage` was removed in the `ListServicesRequest` model in the Logging Management service in the .NET SDK
- The models `TcpApplication` and `UdpApplication` were removed in the Network Firewall service in the .NET SDK
- The enum `TypeEnum` was removed in the model `DecryptionProfile` in the Network Firewall service in the .NET SDK
- The properties `MappedSecrets`, `ApplicationLists`, `UrlLists`, `IpAddressLists`, `SecurityRules`, `DecryptionRules` and `DecryptionProfiles` were removed in the model `CreateNetworkFirewallPolicyDetails` in the Network Firewall service in the .NET SDK
- The enum `ActionEnum` was removed in the model `DecryptionRule` in the Network Firewall service in the .NET SDK
- The type of property `Action` was changed to `DecryptionActionType` in the model `DecryptionRule` in the Network Firewall service in the .NET SDK
- The property `Sources` has been replaced by `SourceAddress` in the models `SecurityRuleMatchCriteria` and `DecryptionRuleMatchCriteria` in the Network Firewall service in the .NET SDK
- The property `Destinations` has been replaced by `DestinationAddress` in the models `SecurityRuleMatchCriteria` and `DecryptionRuleMatchCriteria` in the Network Firewall service in the .NET SDK
- The enum `TypeEnum` was removed in the model `MappedSecret` in the Network Firewall service in the .NET SDK
- The type of property `Type` was changed to `InspectionType` in the model `MappedSecret` in the Network Firewall service in the .NET SDK
- The properties `ApplicationLists`, `UrlLists`, `IpAddressLists`, `SecurityRules`, `DecryptionRules`, `DecryptionProfiles`, `MappedSecrets` and `IsFirewallAttached` were removed in the model `NetworkFirewallPolicy` in the Network Firewall service in the .NET SDK
- The enums `ActionEnum` and `InspectionEnum` were removed in the model `SecurityRule` in the Network Firewall service in the .NET SDK
- The type of property `Action` was changed to `TrafficActionType` in the model `SecurityRule` in the Network Firewall service in the .NET SDK
- The type of property `Inspection` was changed to `TrafficInspectionType` in the model `SecurityRule` in the Network Firewall service in the .NET SDK
- The property `Applications` has been replaced by `Application` in the model `SecurityRuleMatchCriteria` in the Network Firewall service in the .NET SDK
- The property `Urls` has been replaced by `Url` in the model `SecurityRuleMatchCriteria` in the Network Firewall service in the .NET SDK
- The properties `MappedSecrets`, `ApplicationLists`, `UrlLists`, `IpAddressLists`, `SecurityRules`, `DecryptionRules` and `DecryptionProfiles` were removed in the model `UpdateNetworkFirewallPolicyDetails` in the Network Firewall service in the .NET SDK

## 67.4.0 - 2023-10-10
### Added
- Support for creating flow log type capture filters in the Virtual Cloud Network service
- Support for importing and exporting metadata in Data Integration service
- Support for displaying resource usage information on autonomous vm cluster get operations in the Database service
- Support for displaying resource usage information for the list of autonomous container databases on autonomous vm cluster get operations in the Database service
- Support for pluggable database with enhanced features in the Database service
- Support for exporting container and kubernetes app listings in the Marketplace service
- Support for work request statuses for export container and kubernetes app listings in the Marketplace service

## 67.3.0 - 2023-10-03
### Added
- Support for elastic resource pools in the Database service
- Support for private endpoints in the Data Science service
- Support for File System Service (FSS) as transfer medium for data export and import in the Database Migration service
- Support for new optional parameters on replica create, update and list operations in the MySQL Heatwave service

## 67.2.0 - 2023-09-26
### Added
- Support for listing compute performances and storage performances in Database service
- Support for private endpoints for external key managers in Key Management service
- Support for additional parameters in vaults and keys for external key managers in Key Management service
- Support for domains while creating integration instances in Oracle Integration Cloud service

## 67.1.0 - 2023-09-12
### Added
- Support for SQL tuning sets in Database Management service
- Support for announcement chaining in Announcements service
- Support for automatic promotion of hosts in Stack Monitoring service
- Support for face detection in AI Vision service
- Support for change parameters on list character sets operation in Database Management service
- Support for displaying software sources attached to a managed instance group in OS Management service

## 67.0.0 - 2023-09-05
### Added
- Support for queue channels in the Queue Service
- Support for entity lineage retrieval and asynchronous glossary export in the Data Catalog service
- Support for filtering and sorting while listing work requests in the Container Instances service
- Support for the ability to create support requests for various support ticket types (TECH, LIMIT, ACCOUNT) in the Customer Incident Management Service
- Endpoint changed from https://incidentmanagement.{region}.{domainAndTopLevelDomain} to https://incidentmanagement.{region}.oci.{domainAndTopLevelDomain} (e.g. https://incidentmanagement.us-phoenix-1.oraclecloud.com to https://incidentmanagement.us-phoenix-1.oci.oraclecloud.com) in the Customer Incident Management Service
 
### Breaking Changes
- The models `AvailabilityDomain`, `Region`, `CreateUserRequest`, and `UserClient` were removed from the Customer Incident Management Service in the OCI .NET SDK
- The type of property `ProblemType` was changed from `string` to `ProblemType` in the `ValidateUserRequest` model in the Customer Incident Management Service in the OCI .NET SDK
- The property `Source` was removed from the model `GetStatusRequest` in the Customer Incident Management Service in the OCI .NET SDK
- The property `ProblemType` was renamed to `Problemtype` in the model `GetIncidentRequest` in the Customer Incident Management Service in the OCI .NET SDK
- The property `AvailabilityDomain` was removed from the models `Resource` and `CreateResourceDetails` in the Customer Incident Management Service in the OCI .NET SDK
- The type of property `Region` was changed from `Region` to `string` in the models `Resource` and `CreateResourceDetails` in the Customer Incident Management Service in the OCI .NET SDK
- The property `Country` was removed from the model `CreateUserDetails` in the Customer Incident Management Service in the OCI .NET SDK

## 66.0.0 - 2023-08-29
### Added
- Support for creating and updating network monitors in the Application Performance Monitoring Synthetics service
- Support for integration of GoldenGate service for replication in the Database Migration Service
- Support for displaying resource usage information on autonomous container database and cloud autonomous vm cluster get operations in the Database service
- Support for FastConnect Media Access Control Security (MACSec) fail open option in the Network Monitoring service
- Support for generic bare metal types and configuration maps in compute instance platform configuration in the Compute service
- Support for encrypted FastConnect in the Network Monitoring service
- Support for new parameters on customer premises equipment and virtual circuit create operations in the Network Monitoring service
- Support for virtual circuit associated tunnels in the Network Monitoring service
- Support for additional parameters on dynamic routing gateway create and update operations in the Network Monitoring service
- Support for assigning an IPv6 address to a compute instance during instance launch or secondary VNIC attach in the Compute service   
 
### Breaking Changes
- The models `AnalyticsCluster`, `AnalyticsClusterMemoryEstimate`, `AnalyticsClusterMemoryEstimateStatus`, `AnalyticsClusterNode`, `AnalyticsClusterSchemaMemoryEstimate`, `AnalyticsClusterSummary`, `AnalyticsClusterTableMemoryEstimate`, `UpdateAnalyticsClusterDetails`, `AddAnalyticsClusterRequest`, `DeleteAnalyticsClusterRequest`, `GenerateAnalyticsClusterMemoryEstimateRequest`, `GetAnalyticsClusterRequest`, `RestartAnalyticsClusterRequest`, `StartAnalyticsClusterRequest`, `StopAnalyticsClusterRequest`, `UpdateAnalyticsClusterRequest`, `DeleteAnalyticsClusterResponse`, `GetAnalyticsClusterMemoryEstimateResponse`, `RestartAnalyticsClusterResponse`, `StartAnalyticsClusterResponse`, `StopAnalyticsClusterResponse`, `UpdateAnalyticsClusterResponse` were removed in the MySQL Database service in the OCI .NET SDK
- The properties `IsAnalyticsClusterAttached` and `AnalyticsCluster` were removed from `DbSystem` and `DbSystemSummary` models in the MySQL Database service in the OCI .NET SDK
- The enum member `ANALYTICSCLUSTER` was removed from the enum `IsSupportedForEnum` in the models `ShapeSummary` and `ListShapesRequest` in the MySQL Database service in the OCI .NET SDK
- The enum members `ADD_ANALYTICS_CLUSTER`, `UPDATE_ANALYTICS_CLUSTER`, `DELETE_ANALYTICS_CLUSTER`, `START_ANALYTICS_CLUSTER`, `STOP_ANALYTICS_CLUSTER`, `RESTART_ANALYTICS_CLUSTER`, `GENERATE_ANALYTICS_CLUSTER_MEMORY_ESTIMATE` were removed from the enum `WorkRequestOperationType` in the MySQL Database service in the OCI .NET SDK
- The property `IsAnalyticsClusterAttached` was removed from the model `ListDbSystemsRequest` in the MySQL Database service in the OCI .NET SDK
- The operations `AddAnalyticsCluster`, `DeleteAnalyticsCluster`, `GenerateAnalyticsClusterMemoryEstimate`, `GetAnalyticsCluster`, `GetAnalyticsClusterMemoryEstimate`, `RestartAnalyticsCluster`, `StartAnalyticsCluster`, `StopAnalyticsCluster`, `UpdateAnalyticsCluster` were removed from the `DbSystemClient` in the MySQL Database service in the OCI .NET SDK
- The waiters `ForAnalyticsCluster` were removed from `DbSystemWaiters` in the MySQL Database service in the OCI .NET SDK

## 65.2.0 - 2023-08-22
### Added
- Support for Compute Cloud at Customer service
- Support for warehouse data objects in the Operations Insights service
- Support for standard queries on operations Insights data objects in the Operations Insights service
- Support for database in memory on autonomous database create operations in the Database service

## 65.1.0 - 2023-08-15
### Added
- Support for credential stores, including Single Sign-On support, for deployments in the GoldenGate service
- Support for container security contexts in the Container Instances service
- Support for placement constraints and cluster configurations on cluster networks in the Compute service

## 65.0.0 - 2023-08-08
### Added
- Support for backup retention on autonomous database create operations in the Database service
- Support for exclude tables for replication in the Database Migration service
- Support for adding and updating auto failover maximum data loss limits for local autonomous data guards in the Database service
- Support for limiting networking diagram ingestion in the Networking Monitoring service
- Support for new operations for deployment upgrades in the GoldenGate service
- Support for getting model type information and base model versions while creating language custom models in the AI Language service
- Support for support field in class metric in the AI Language service
- Support for Compute Cloud at Customer resource type in the Operator Access Control service
- Support for managing account management info, account recovery settings, app roles, apps, app status changers, grants, identity propagation trusts and settings, request-able groups, requests, security questions, OAuth tokens, and user attribute settings in the Identity Domains service

### Breaking Changes
- The property `IsInternetAccessAllowed` has been removed from the `CreateIpv6Details`, `Ipv6` and `UpdateIpv6Details` models in the Networking Monitoring service in the .NET SDK
- The property `PublicIpAddress` has been removed from the `Ipv6` model in the Networking Monitoring service in the .NET SDK
- The property `Ipv6CidrBlock` has been removed from the `Vcn` and `CreateVcnDetails` models in the Networking Monitoring service in the .NET SDK
- The property `Ipv6PublicCidrBlock` has been removed from the `Vcn` and `Subnet` models in the Networking Monitoring service in the .NET SDK

## 64.0.0 - 2023-08-01
### Added
- Support for the Exadata Fleet Update service
- Support for REST-based log collection, multi-conditional labels, and collection properties in the Logging Analytics service
- Support for Kubernetes cluster credential rotation in the Container Engine for Kubernetes service
- Support for zero-downtime features in the Fusion Apps as a Service service
- Support for news reports in the Operations Insights service
  
### Breaking Changes
- The EnumMember `AccelerationMaintenance` was removed from the enum `TaskType` in the `TaskType` model in the Logging Analytics service in the .NET SDK

## 63.0.0 - 2023-07-25
### Added
- Support for composing multiple document service custom key value models into one single model in Document Understanding Service
- Support for custom hostname in the Compute service
- Support for cloud subscription in the Organizations service
- Support for automatic backup download in the GoldenGate service
- Support for creating single use (non-recurring) budgets in the Budgets service
  
### Breaking Changes
- The properties `ClassicSubscriptionId`, `IsClassicSubscription`, `RegionAssignment`, `LifecycleState`, `StartDate` and `EndDate` were removed from the models `AssignedSubscription`, `AssignedSubscriptionSummary`, `Subscription` and `SubscriptionSummary` in the Organizations service in the .NET SDK
- The property `PaymentModel` has been removed from `Subscription` and `SubscriptionSummary` models in the Organizations service in the .NET SDK
- The properties `SubscriptionTier`, `IsGovernmentSubscription`, `Promotion`, `PurchaseEntitlementId`, `Skus`, `CsiNumber`, `CloudAmountCurrency`, `CustomerCountryCode, and `ProgramType` have been removed from `AssignedSubscription` and `Subscription` models in the Organizations service in the .NET SDK
- The property `OrderIds` has been removed from `AssignedSubscription` model in the Organizations service in the .NET SDK
- The EnumMembers `UPDATING`, `DELETING` and `DELETED` were removed from the enum `SubscriptionLifecycleState` in the Organizations service in the .NET SDK
- The waiters `ForAssignedSubscription` and `ForSubscription` were removed from the `SubscriptionWaiters` in the Organizations service in the .NET SDK

## 62.0.0 - 2023-07-18
### Added
- Support for calling Oracle Cloud Infrastructure services in the mx-monterrey-1 region
- Support for Kerberos and LDAP with NFSv3 in the File Storage service
- Support for capacity reservation checks for movable compute instances in the Disaster Recovery service
- Support for Oracle MFT monitoring in the Stack Monitoring service
- Support for OS patching in the Big Data service
- Support for master and utility nodes in the Big Data service
- Support for connectivity testing in the GoldenGate service
 
### Breaking Changes
- The type of property `SizeInBytes` was changed from `decimal` to `long` for the ` Oci.GoldengateService.Models.DeploymentBackup`, ` Oci.GoldengateService.Models.DeploymentBackupSummary`, ` Oci.GoldengateService.Models.TrailFileSummary`, and ` Oci.GoldengateService.Models.TrailSequenceSummary` in the GoldenGate service
- The enum type `UnknownEnumValue` was removed from the enum `Oci.ContainerinstancesService.Models.ContainerCapability` in the Container Instances service
- The property `AdditionalCapabilities` was removed from the models `Oci.ContainerinstancesService.Models.Container` and `Oci.ContainerinstancesService.Models.CreateContainerDetails` in the Container Instances service
- The property `FunctionId` was made required in the model `Oci.DisasterrecoveryService.Models.UpdateInvokeFunctionUserDefinedStepDetails` in the Disaster Recovery service
- The properties `RunOnInstanceId` and `ScriptCommand` were made required in the model `Oci.DisasterrecoveryService.Models.UpdateRunLocalScriptUserDefinedStepDetails` in the Disaster Recovery service
- The properties `RunOnInstanceId` and `ObjectStorageScriptLocation` were made required in the model `Oci.DisasterrecoveryService.Models.UpdateRunObjectStoreScriptUserDefinedStepDetails` in the Disaster Recovery service
- The properties `FunctionId` and `FunctionRegion` were made required in the model `Oci.DisasterrecoveryService.Models.InvokeFunctionStep` in the Disaster Recovery service

## 61.0.0 - 2023-07-11
### Added
- Support for specifying default snapshot enablement, verified response codes, client certificate details, and request authentication schemes when creating or updating synthetic monitors in the Application Performance Monitoring service
- Support for address rules, address verification, and requesting addresses in the OSP Gateway service
- Support for synchronous operations in the Document Understanding service
- Support for migration without SSH to database hosts (DMS) in the Database Migration service
- Support for processing workload mappings in the Container Engine for Kubernetes service
- Support for Salesforce, MySQL HeatWave, and Oracle EBS, Sieble, and PeopleSoft connectors in the Data Integration service
- Support for updating the envelope key of a volume backup in the Block Volume service
 
### Breaking Changes
- The model `BillingAddress` was removed from the OSP Gateway service in the .NET SDK
- The type of property `BillingAddress` was changed from `BillingAddress` to `Address` in the `Subscription` and `SubscriptionSummary` models in the OSP Gateway service in the .NET SDK

## 60.2.0 - 2023-06-27
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-frankfurt-2 region
- Support for the OS Management Hub service
- Support for changing the key store type, and rotating keys, on Exadata Cloud at Customer in the Database service
- Support for launching VM database systems using Ampere A1 shapes in the Database service
- Support for additional currencies and countries on paid listings in the Marketplace service
- Support for ECPU integration in the License Manager service
- Support for freeform and defined tags on resources in the Generic Artifacts service
- Support for SQL endpoints in the Data Flow service
- Support for setting replication delays on channels in the MySQL Database service
- Support for setting how channels handle replicated tables with no primary key in the MySQL Database service
- Support for SQL Plan Management (SPM) in Database Management service

## 60.1.0 - 2023-06-20
### Added
- Support for serial console access in the Database service
- Support for an increased storage size limit of up to 384 TBs in the Database service
- Support for network security group (NSG) support for private database registrations / private endpoints in the Database Migration service
- Support for document classification on documents of more than one page in the Data Labeling service
- Support for importing datasets in the Data Labeling service
- Support for specifying a shape when creating applications in the Functions service
- Support for creating and managing pools in the Data Flow service
- Support for specifying certificate parameters when creating or updating a node in the Roving Edge Infrastructure service
- Support for certificate management in the Roving Edge Infrastructure service
- Support for upgrade bundle management in the Roving Edge Infrastructure service

## 60.0.0 - 2023-06-13
### Added
- Support for the OCI Control Center service
- Support for resource quotas and limits in the Usage service
- Support for allowing users to select the billing interval of deleted ESXi hosts while adding new ESXi hosts in the VMWare Solution service
- Support for custom key/value pairs and custom document classification in the AI Document service
- Support for namespace-prefixed domains in the Object Storage service
- Support for getting the full path to a pre-authenticated request in the Object Storage service
- Support for Java migration analysis, performance tuning recommendations, and JDK LCM customization in the Java Management service
- Support for the TCPS protocol for cloud databases in the Operations Insights service
- Support for AIX hosts that are monitored via Enterprise Manager in the Operations Insights service
- Support for Alloy configuration
 
### Breaking Changes
- The return type of property `Capacity` was changed from `decimal` to `Double` in `DatastoreSummary` model in the VMWare Solution service in the .NET SDK

## 59.1.0 - 2023-06-06
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-madrid-2 region
- Support for bulk include/exclude of migration objects in the Database Migration service
- Support for Kafka cluster profiles, including dedicated Kafka broker nodes, in the Big Data service
- Support for MySQL HeatWave Lakehouse in the MySQL Database service
- Support for capacity reports in the Compute service

## 59.0.0 - 2023-05-30
### Added
- Support for policy-based snapshots in the File Storage service
- Support for creating and updating a VM cluster network with disaster recovery network support in the Database service
- Support for setting a management dashboard or saved search to be shared across OCI Observability & Management services in the Management Dashboard service
 
### Breaking Changes
- The property `Port` was deprecated and made optional in the `Oci.DatabaseService.Models.ScanDetails` model in the Database service in the .NET SDK

## 58.0.0 - 2023-05-23
### Added
- Support for CRI-O parsing in the Logging service
- Support for retrieving the resource availability domain when getting Exadata infrastructure or VM clusters in the Database service
- Support for specifying database servers when creating dedicated autonomous databases in the Database service
- Support for secondary egress zones in the DNS service
  
### Breaking Changes
- The cmdlets `Get-OCILoggingLogIncludedSearch and `Get-OCILoggingLogIncludedSearchesList` were removed in the Logging service
- The models `LogIncludedSearch`, `LogIncludedSearchSummaryCollection`, `ListLogIncludedSearchesRequest` and `ListLogIncludedSearchesResponse` were removed in the Logging service in the .NET SDK
- The property `Keys` was made required in the `UnifiedAgentCsvParser` and `UnifiedAgentTsvParser` models in the Logging service in the .NET SDK
- The property `Patterns` was made required in the `UnifiedAgentGrokParser` and `UnifiedAgentMultilineGrokParser` models in the Logging service in the .NET SDK
- The properties `Sources` and `Destination` were made required in the `UnifiedAgentLoggingConfiguration` model in the Logging service in the .NET SDK
- The property `Format` was made required in the `UnifiedAgentMultilineParser` model in the Logging service in the .NET SDK
- The property `Expression` was made required in the `UnifiedAgentRegexParser` model in the Logging service in the .NET SDK
- The property `Paths` was made required in the `UnifiedAgentTailLogSource` model in the Logging service in the .NET SDK
- The property `Channels` was made required in the `UnifiedAgentWindowsEventSource` model in the Logging service in the .NET SDK
- The operations `GetLogIncludedSearch` and `ListLogIncludedSearches` were removed from the `LoggingManagementClient` in the Logging service in the .NET SDK
- The operations `ListLogIncludedSearchesResponseEnumerator` and `ListLogIncludedSearchesRecordEnumerator` were removed from the `LoggingManagementPaginators` in the Logging service in the .NET SDK
- A new required property `ExternalDownstreams` was added in the `Zone` model in the DNS service in the .NET SDK

## 57.0.0 - 2023-05-16
### Added
- Support for self-service integration in the Fusion Apps as a Service service
 
### Breaking Changes
- The models `Oci.FusionappsService.Models.AttachExistingInstanceDetails`, `Oci.FusionappsService.Models.CreateNewInstanceDetails`, `Oci.FusionappsService.Models.CreateOicServiceInstanceDetails`, `Oci.FusionappsService.Models.CreateServiceInstanceDetails`, `Oci.FusionappsService.Models.FawAdminInfoDetails` and `Oci.FusionappsService.Models.CreateOaxServiceInstanceDetails` were removed from the Fusion Apps as a Service service in the .NET SDK
- The enum `ActionEnum` was removed from the `Oci.FusionappsService.Models.CreateServiceAttachmentDetails` model in the Fusion Apps as a Service service in the .NET SDK
- The property `Action` was removed from the `Oci.FusionappsService.Models.ServiceAttachment` model in the Fusion Apps as a Service service in the .NET SDK

## 56.1.0 - 2023-05-09
### Added
- Support for the Access Governance service
- Support for creating, updating, listing and downloading one-off patches in the Database service
- Support for changing disaster recovery configurations of remote autonomous databases in the Database service
- Support for scheduling automatic backups in the Database service
- Support for provisioning Software-Defined Data Centers (SDDCs) using standard bare metal shapes, with Block Storage as the datastore, in the VMWare Solution service
- Support for parity with the configuration options of the Compute service in the Compute Autoscaling service

## 56.0.0 - 2023-05-02
### Added
- Support for calling Oracle Cloud Infrastructure services in the `eu-jovanovac-1` region
- Support for bring-your-own-license TLS and ORDS certificates in the Database service
- Support for tags in the Stack Monitoring service
- Support for GPU shapes for model deployments in the Data Science service
- Support for returning networking details of instances in the Visual Builder service
- Support for high-memory VMs in the Compute service
- Support for integrating with the Integration Cloud service in the Process Automation service
- Support for managing on-demand node upgrades in node pools in the Container Engine for Kubernetes service
 
### Breaking Changes
- The model `Oci.ContainerengineService.Models.UpdateVirtualNodeDetails` was removed from the Container Engine for Kubernetes service in the .NET SDK

## 55.1.0 - 2023-04-25
### Added
- Support for enabling mTLS authentication with Listener and for providing custom value for TLS port and Non-TLS Port during AVM Cluster Creation in Database service
- Support for usedDataStorageSizeInGbs property for autonomous database in the Database service
- Support for csiNumber organization in Tenant Manager Control Plane service
- Support for creating and updating an infrastructure with LACP support in Database service
- Support for changePrivateEndpointOutboundConnection operation in Integration Cloud service
- Support for Enable Process in Integration Cloud service
- Support for Disaster Recovery, DR enablement, switchover, and failover feature in Fusion Apps service
- Support for discovery and monitoring of External Exadata infrastructure in Database Management Service

## 55.0.0 - 2023-04-18
### Added
- Support for private endpoints in the Digital Assistant service
- Support for canceling backups in the Database service
- Support for improved labeling of key/value pairs in the Data Labeling service
  
### Breaking Changes
- The property `OpcRetryToken` was removed from the models `ConfigureDigitalAssistantParametersRequest`, `RotateChannelKeysRequest`, `StartChannelRequest`, `StopChannelRequest` in the Data Labeling service in the .NET SDK
- The property `LifetimeLogicalClock` was removed from the models `Record`, `Dataset` and `Annotation` in the Data Labeling service in the .NET SDK
- The property `DigitalAssistantId` was renamed to `Id` in the `ListDigitalAssistantsRequest` model in the Data Labeling service in the .NET SDK
- The property `IsLatestSkillOnly` was renamed to `IsLatestVersionOnly` in the `ListPackagesRequest` model in the Data Labeling service in the .NET SDK
- The property `SkillId` was renamed to `Id` in the `ListSkillsRequest` model in the Data Labeling service in the .NET SDK
- The properties `AuthorizationEndpointUrl` and `SubjectClaim` were made optional in the `AuthenticationProvider` model in the Data Labeling service in the .NET SDK
- The parameter `OpcRetryToken` was removed in the `Start-OCIOdaChannel`, `Stop-OCIOdaChannel`, `Invoke-OCIOdaConfigureDigitalAssistantParameters`, `Invoke-OCIOdaRotateChannelKeys` cmdlets
- The parameter `SkillId` was renamed to `Id` in `Get-OCIOdaSkillsList` cmdlet
- The parameter `IsLatestSkillOnly` was renamed to `IsLatestVersionOnly` in the `Get-OCIOdaPackagesList` cmdlet
- The parameter `DigitalAssistantId` was renamed to `Id` in the `Get-OCIOdaDigitalAssistantsList` cmdlet

## 54.0.0 - 2023-04-11
### Added
- Support for rotation of certificates on autonomous VM clusters on Exadata Cloud at Customer in the Database service
- Support for ACD and OKV wallet naming for autonomous databases and dedicated autonomous databases on Exadata Cloud at Customer in the Database service
- Support for Exadata cloud service application virtual IPs (VIPs) in the Database service
- Support for additional manageability features for large sensitive data models and masking policies in the Data Safe service
- Support for getting user profile details and assignments for databases and fleets in the Data Safe service
- Support for enabling ADDM spotlight for databases in the Operations Insights service
 
### Breaking Changes
- The property `AdditionalDatabaseStatus` was removed from the models `Oci.DatabaseService.Models.AutonomousDatabase`, `Oci.DatabaseService.Models.AutonomousDatabaseSummary`, `Oci.DatabaseService.Models.AutonomousDataWarehouse`and `Oci.DatabaseService.Models.AutonomousDataWarehouseSummary` in the Database service in the .NET SDK
 
### Fixed
- An issue with certificate rotation and concurrent request with the InstancePrincipalsAuthenticationDetailsProvider was fixed.

## 53.0.0 - 2023-04-04
### Added
- Support for pre-emptible worker nodes in the Container Engine for Kubernetes service
- Support for larger data storage (now up to 128TB) in the MySQL Database service
- Support for HTTP health checks for HTTPS backend sets in the Load Balancer service
 
### Breaking Changes
- The property `BackendSetName` was made required in the `ForwardToBackendSet` model in the Load Balancer service in the .NET SDK

## 52.1.0 - 2023-03-28
### Added
- Support for ACD and OKV wallet naming for autonomous databases and dedicated autonomous databases on Exadata Cloud at Customer in the Database service
- Support for validating the credentials of a connection in the DevOps service
- Support for GoldenGate Replicat performance profiles when creating a migration in the Database Migration service
- Support for connection diagnostics on registered databases in the Database Migration service
- Support for launching bare metal instances in an RDMA network in the Compute service

## 52.0.0 - 2023-03-21
### Added
- Support for backup automation integration with the Database Recovery service in the Database service
- Support for changing the disaster recovery configuration of an autonomous database in remote regions of its disaster recovery association in the Database service
- Support for creating a remote disaster recovery association clone of an autonomous database in the Database service
- Support for managed build stages to be configured to use custom shape build runners in the DevOps service
- Support for listing pre-built functions and creating functions from pre-built functions in the Functions service
- Support for connections types for database resources of type Amazon S3, HDFS, SQL Server, Java Messaging service, Mongo DB, Oracle NoSQL, and Snowflake in the GoldenGate service

### Breaking Changes
- The enum value `LAKE_HOUSE_CONNECTION` was renamed to `LAKE_CONNECTION` in the enum ModelTypeEnum in the Connection, ConnectionDetails, ConnectionSummary, CreateConnectionDetails and UpdateConnectionDetails models in the Data Integration Service in the .NET SDK
- The enum value `LAKE_HOUSE_DATA_ASSET` was renamed to `LAKE_DATA_ASSET` in the enum ModelTypeEnum in the DataAsset, CreateDataAssetDetails, DataAssetSummary, and UpdateDataAssetDetails models in the Data Integration Service in the .NET SDK

## 51.0.0 - 2023-03-14
### Added
- Support for the Identity Domains service
- Support for long-term backups for autonomous databases on Exadata Cloud at Customer in the Database service
- Support for database OS patching in the Database service
- Support for managing enhanced clusters, cluster add-ons, and serverless virtual node pools in the Container Engine for Kubernetes service
- Support for templates and copy object requests in the Data Integration service
- Support for maintenance features in the GoldenGate service
- Support for `AMD_MILAN_BM_GPU` configuration type on instances in the Compute service
- Support for host storage metrics and network metrics as part of host capacity planning in the Operations Insights service
 
### Breaking Changes
- Support for the Data Connectivity Management service was removed
- The `TemplateSummary` response model in the Data Integration service now contains `UnknownEnumValue` enum with value `null` for `LifecycleState` if the service returns a `LifecycleState` enum value that not present in the SDK version being used

## 50.0.0 - 2023-03-07
### Added
- Support for creating and updating autonomous database long-term backup schedules in the Database service
- Support for creating, updating, and deleting autonomous database long-term backups in the Database service
- Support for model deployment resources to use customized container images containing runtime dependencies of ML models and custom web servers to handle inference requests in the Data Science service
- Support for using the compartmentIdInSubtree parameter when summarizing management agent counts in the Management Agent Cloud service
- Support for getting agent property details in the Management Agent Cloud service
- Support for filtering by gateway ID when listing agents in the Management Agent Cloud service
- Support for the Hebrew and Greek languages during AI language text translation in the AI Language service
- Support for auto-detection when analyzing text with pre-trained models in the AI Language service
- Support for specifying update operation constraints when updating an instance in the Compute Service
- Support for disaster recovery in the Content Management service
- Support for advanced autonomous databases insights in the Operations Insights service
 
### Breaking Changes
- The OCI PowerShell Modules now return a successful response for the `304 NotModified` HTTP status code instead of raising an OCIException
- The enum member `ACTIVE` was removed from the enum `LifecycleDetails` in the `LifecycleDetails` model in the Content Management service in the .NET SDK

## 49.1.0 - 2023-02-28
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-dcc-rating-1, eu-dcc-rating-2, eu-dcc-dublin-1, eu-dcc-dublin-2, and eu-dcc-milan-2 regions
- Support for on-demand bootstrap script execution in the Big Data Service

## 49.0.0 - 2023-02-21
### Added
- Support for async jobs in the AI Anomaly Detection service
- Support for specifying algorithm hints and windows sizes during model training in the AI Anomaly Detection service
- Support for specifying a sensitivity value during model detection in the AI Anomaly Detection service
- Support for discovery and monitoring of external Oracle database infrastructure components in the Database Management service
 
### Breaking Changes
- The type for property `SystemTags` was changed from a dictionary of string to another dictionary to a dictionary of a string to object for `ProjectSummary`, `Project`, `ModelSummary`, `Model`, `DataAssetSummary`, `DataAsset`, `AiPrivateEndpointSummary`, `AiPrivateEndpoint` models in the AI Anomaly Detection service

## 48.1.0 - 2023-02-14
### Added
- Support for the Visual Builder Studio service
- Support for the Autonomous Recovery service
- Support for retries by default on operations of the Compute service
- Support for selecting specific database servers when creating autonomous VM clusters in the Database service
- Support for creating autonomous VMs during the creation of autonomous VM clusters in the Database service

## 48.0.0 - 2023-02-07
### Added
- Support for changing Data Guard role of a database instance within the Database service
- Support for listing autonomous container database versions in the Database service
- Support for specifying a database version when creating or updating an autonomous container database in the Database service
- Support for specifying an eCPU count when creating or updating autonomous shared databases in the Database service
- Support for Helm attestation and Helm arguments on deploy operations in the DevOps service
- Support for uploading master key wallets for deployments in the GoldenGate service
- Support for custom configurations in the Operations Insights service
- Support for refreshing the session token in SessionTokenAuthenticationDetailsProvider
 
### Breaking Changes
- The property `CpuCoreCount` was made optional in `AutonomousDatabase` and `AutonomousDatabaseSummary` model in the Database service in the .NET SDK

## 47.3.0 - 2023-01-31
### Added
- Support for ECPU billing for autonomous databases and dedicated autonomous databases on Exadata Cloud at Customer in the Database service
- Support for providing a vault secret ID when creating or updating autonomous shared databases in the Database service
- Support for including ORDS and database transform URLs as autonomous database connections in the Database service
- Support for role-based access control on OpenSearch clusters in the Search service
- Support for managed shell stages on deployments in the DevOps service
- Support for memory encryption on confidential VMs in the Compute service
- Support for configuration items, and reporting ownership of configuration items, in the Application Performance Monitoring service

## 47.2.0 - 2023-01-24
### Added
- Support for the Cloud Migrations service
- Support for setting up custom private IPs while creating private endpoints in the Database service
- Support for machine learning pipelines in the Data Science service
- Support for personally identifiable information detection in the AI Language service

## 47.1.0 - 2023-01-17
### Added
- Support for calling Oracle Cloud Infrastructure services in the us-chicago-1 region
- Support for cross-region replication in the File Storage service
- Support for setting up private DNS on ExaCS systems during provisioning in the Database service
- Support for elastic storage expansion on infrastructure resources for Exadata Cloud at Customer in the Database service
- Support for target versions during infrastructure patching on Cloud Exadata infrastructure in the Database service
- Support for creating model version sets in the model catalog in the Data Science service
- Support for associating a model with a model version set in the Data Science service
- Support for custom key/value annotations on documents in the Data Labeling service
- Support for configurable timeouts in the Service Mesh service

## 47.0.0 - 2022-12-13
### Added
- Support for the Queue service
- Support for Intel X9 shapes when launching VM database systems in the Database service
- Support for enabling, disabling, and editing Database Management service connections on pluggable databases in the Database service
- Support for availability configurations and maintenance window schedules on synthetic monitors in the Application Performance Monitoring service
- Support for scheduling cascading deletes on a project in the DevOps service
- Support for cancelling a scheduled cascading delete on a project in the DevOps service
- Support for issue and action fields on job phases of validation and migration processes in the Database Migration service
- Support for cluster profiles in the Big Data service
- Support for egress-only services in the Service Mesh service
- Support for optional listeners and service discovery metadata on virtual deployments in the Service Mesh service
- Support for canceling work requests in the accepted state in the Service Mesh service
- Support for filtering work requests on associated resource id and operation status in the Service Mesh service
- Support for sorting while listing work requests, listing work request logs, and listing work request errors in the Service Mesh service
- Support for Oracle Managed Access integration in the Fusion Apps as a Service service
- Support for refresh scheduling in the Fusion Apps as a Service service
- Support for additional connections types on database resources in the GoldenGate service
 
### Breaking Changes
- The `LifecycleState` parameter has changed type from `string` to `Oci.ServicemeshService.Models.AccessPolicy.LifecycleStateEnum` in the `Get-OCIServicemeshAccessPoliciesList`, `Get-OCIServicemeshIngressGatewayRouteTablesList` `Get-OCIServicemeshIngressGatewaysList`, `Get-OCIServicemeshMeshesList`, `Get-OCIServicemeshVirtualDeploymentsList`, `Get-OCIServicemeshVirtualServiceRouteTablesList`, and `Get-OCIServicemeshVirtualServicesList` cmdlets in the Service Mesh service
- The type for property `RouteRules` was changed from a List of `Oci.ServicemeshService.Models.VirtualServiceTrafficRouteRule` to a List of `Oci.ServicemeshService.Models.VirtualServiceTrafficRouteRuleDetails` in the `Oci.ServicemeshService.Models.UpdateVirtualServiceRouteTableDetails` and `Oci.ServicemeshService.Models.CreateVirtualServiceRouteTableDetails` models in the Service Mesh service
- The type for property `Mtls` was changed from `Oci.ServicemeshService.Models.CreateMutualTransportLayerSecurityDetails` to `Oci.ServicemeshService.Models.VirtualServiceMutualTransportLayerSecurityDetails` in the `Oci.ServicemeshService.Models.UpdateVirtualServiceDetails` and `Oci.ServicemeshService.Models.CreateVirtualServiceDetails` models in the Service Mesh service
- The type for property `RouteRules` was changed from a List of `Oci.ServicemeshService.Models.IngressGatewayTrafficRouteRule` to a List of `Oci.ServicemeshService.Models.IngressGatewayTrafficRouteRuleDetails` in the `Oci.ServicemeshService.Models.UpdateIngressGatewayRouteTableDetails` and `Oci.ServicemeshService.Models.CreateIngressGatewayRouteTableDetails` models in the Service Mesh service
- The type for property `Mtls` was changed from `Oci.ServicemeshService.Models.CreateIngressGatewayMutualTransportLayerSecurityDetails` to `Oci.ServicemeshService.Models.IngressGatewayMutualTransportLayerSecurityDetails` in the `Oci.ServicemeshService.Models.UpdateIngressGatewayDetails` and `Oci.ServicemeshService.Models.CreateIngressGatewayDetails` models in the Service Mesh service
- The type for property `Rules` was changed from a List of `Oci.ServicemeshService.Models.AccessPolicyRule` to a List of `Oci.ServicemeshService.Models.AccessPolicyRuleDetails` in the `Oci.ServicemeshService.Models.UpdateAccessPolicyDetails` and `Oci.ServicemeshService.Models.CreateAccessPolicyDetails` models in the Service Mesh service

## 46.0.0 - 2022-12-06
### Added
- Support for the Container Instances service
- Support for the Document Understanding service
- Support for creating stacks from OCI DevOps service and Bitbucket Cloud/Server as source control management in the Resource Manager service
- Support for deployment stage level parameters in the DevOps service
- Support for PeopleSoft discovery in the Stack Monitoring service
- Support for Apache Tomcat discovery in the Stack Monitoring service
- Support for SQL Server discovery in the Stack Monitoring service
- Support for OpenId Connect in the API Gateway service
- Support for returning compartment ids when listing backups in the MySQL Database service
- Support for adding a load balancer endpoint to a DB system in the MySQL Database service
- Support for managed read replicas in the MySQL Database service
- Support for setting replication filters on channels in the MySQL Database service
- Support for replicating from a source configured without global transaction identifiers into a channel in the MySQL Database service
- Support for time zone and language preferences in the Announcements service
- Support for adding report schedules for activity auditing and alerts reports in the Data Safe service
- Support for bulk operations on alerts in the Data Safe service
- Support for Java server usage reporting in the Java Management service
- Support for Java library usage reporting in the Java Management service
- Support for cryptographic roadmap impact analysis in the Java Management service
- Support for Java Flight Recorder recordings in the Java Management service
- Support for post-installation steps in the Java Management service
- Support for restricting management of advanced functionality in the Java Management service
- Support for plugin improvements in the Java Management service
- Support for collecting diagnostics on deployments in the GoldenGate service
- Support for onboarding Exadata Public Cloud (ExaCS) targets to the Operations Insights service
 
### Breaking Changes
- A required property `WaitForLifecycleState` was added to `Get-OCIDatasafeMaskingReport` cmdlet in the Data Safe service
- A required property `CompartmentId` was added to `Oci.DatasafeService.Models.PatchAlertsDetails` model in the Data Safe service
- The properties `ListenerPort` and `ServiceName` were made required in `Oci.DatasafeService.Models.InstalledDatabaseDetails` model in the Data Safe service
- The property `AutonomousDatabaseId` was made required in `Oci.DatasafeService.Models.AutonomousDatabaseDetails` model in the Data Safe service

## 45.1.0 - 2022-11-15
### Added
- Support for mTLS authentication with listeners during Autonomous VM Cluster creation on Exadata Cloud at Customer in the Database service
- Support for providing custom values for TLS and non-TLS ports during Autonomous VM Cluster creation on Exadata Cloud at Customer in the Database service
- Support for creating multiple Autonomous VM Clusters in the same Exadata infrastructure in the Database service
- Support for listing resources associated with a job in the Resource Manager service
- Support for listing resources associated with a stack in the Resource Manager service
- Support for listing outputs associated with a job in the Resource Manager service
- Support for the Oracle distribution of Apache Hadoop 2.0 in the Big Data service

## 45.0.0 - 2022-11-08
### Added
- Support for listing local and cross-region refreshable clones in the Database service
- Support for adding multiple cloud VM clusters in the Database service
- Support for creating rollback jobs in the Resource Manager service
- Support for edge nodes in the Big Data service
- Support for Single Client Access Name (SCAN) in the Data Flow service
- Support for additional filters when listing application dependencies in the Application Dependency Management service
- Support for additional properties when reading Vulnerability Audit resources in the Application Dependency Management service
- Support for optionally passing compartment IDs when creating Vulnerability Audit resources in the Application Dependency Management service

### Breaking Changes
- The property `CertificateId` was made required in the `Oci.ResourcemanagerService.Models.PrivateServerConfigDetails` model in the Resource Manager service

## 44.0.0 - 2022-11-01
### Added
- Support for cloning from a backup from the last available timestamp in the Database service
- Support for third-party scanning using Qualys in the Vulnerability Scanning service
- Support for customer-provided encryption keys in the Logging Analytics service
- Support for connections for database resources in the GoldenGate service
  
### Breaking Changes
- The enum `VendorEnum` was removed from the `Oci.VulnerabilityscanningService.Models.HostScanAgentConfiguration` model in the Vulnerability Scanning service in the .NET SDK

## 43.0.0 - 2022-10-24
### Added
- Support for the Disaster Recovery service
- Support for running code interactively with session applications using statements in the Data Flow service
- Support for language custom models and language translation in the AI Language service
 
### Breaking Changes
- The type of property `Documents` was changed from a List of `TextClassificationDocument` to a List of `TextDocument` in the `Oci.AilanguageService.Models.BatchDetectLanguageTextClassificationDetails` model in the AI Language service in the .NET SDK
- The type of property `Documents` was changed from a List of `SentimentsDocument` to a List of `TextDocument` in the `Oci.AilanguageService.Models.BatchDetectLanguageSentimentsDetails` model in the AI Language service in the .NET SDK
- The type of property `Documents` was changed from a List of `KeyPhraseDocument` to a List of `TextDocument` in the `Oci.AilanguageService.Models.BatchDetectLanguageKeyPhrasesDetails` model in the AI Language service in the .NET SDK
- The type of property `Documents` was changed from a List of `EntityDocument` to a List of `TextDocument` in the `Oci.AilanguageService.Models.BatchDetectLanguageEntitiesDetails` model in the AI Language service in the .NET SDK

## 42.0.0 - 2022-10-04
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-dcc-milan-1 region
- Support for target host identification and SOCKS support on dynamic port forwarding sessions in the Bastion service
- Support for viewing top processes running at a particular point of time in the Operations Insights service
- Support for filtering top processes by a single process to view that process's trend over time in the Operations Insights service
- Support for creating Enterprise Manager-based Windows host targets in the Operations Insights service
- Support for creating Management Agent Cloud-based Windows and Solaris host targets in the Operations Insights service
  
### Breaking Changes
- The property `TargetResourcePort` was removed from the models `Oci.BastionService.Models.TargetResourceDetails` and `Oci.BastionService.Models.CreateSessionTargetResourceDetails` in oci-dotnet-sdk in the Bastion service

## 41.1.0 - 2022-09-27
### Added
- Support for search capabilities for monitored resources in the Stack Monitoring service
- Support for deleting monitored resources with their members in the Stack Monitoring service
- Support for creating host-type monitored resources in the Stack Monitoring service
- Support for associating external resources during creation of monitored resources in the Stack Monitoring service
- Support for uploading bulk data in the NoSQL Database Cloud service
- Support for examining query execution plans in the NoSQL Database Cloud service
- Support for starting and stopping clusters in the Big Data service
- Support for additional compute shapes in the Big Data service
- Support for backwards pagination in the Search service
- Support for elastic compute for Exadata Cloud at Customer in the Database service

## 41.0.0 - 2022-09-20
### Added
- Support for the Cloud Bridge service
- Support for the Cloud Migrations service
- Support for display banners, trails, and sizes in the GoldenGate service
- Support for generic REST data assets, flattening of data in Data Flow, and runtime information on pipelines in the Data Integration service
- Support for expanded search functionality in the Threat Intelligence service
- Support for ingest-time rules and specifying logsets and query strings during recalls in the Logging Analytics service
- Support for repository mirroring from Visual Builder Studio in the DevOps service
- Support for running a managed build stage with the source code hosted in a Visual Builder Studio repository in the DevOps service
- Support for triggering a build run based on an event in a Visual Builder Studio repository in the DevOps service
- Support for additional parameters during cost management scheduling in the Usage service
  
### Breaking Changes
- The properties `FlattenProjectionPreferences`, `FlattenAttributeRoot`, `FlattenAttributePath`, `FlattenColumns` were made optional in `FlattenDetails` model in oci-dotnet-sdk in the Data Integration service
- Required properties `Attributes`, `TimeLastSeen` and `Geodata` were added to IndicatorSummary model in oci-dotnet-sdk in the Threat Intelligence service
- The property `QueryProperties` was made optional in `CreateScheduleDetails` and `Schedule` models in oci-dotnet-sdk in the Usage service
- The property `PreviousDeploymentId` was made a required parameter in the `CreateDeployPipelineRedeploymentDetails` model in oci-dotnet-sdk in the DevOps service
- The property `DeployStageId` was made a required parameter in `CreateSingleDeployStageDeploymentDetails` and `CreateSingleDeployStageRedeploymentDetails` model in oci-dotnet-sdk in the DevOps service

## 40.1.0 - 2022-09-13
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-madrid-1 region
- Support for exporting and importing larger model artifacts in the model catalog in the Data Science service
- Support for Request Based Authorization in the API Gateway service
- Support for Dynamic Authentication in the API Gateway service
- Support for Dynamic Routing Backend in the API Gateway service

## 40.0.0 - 2022-09-06
### Added
- Support for generic REST, OCI Streaming service, and Lake House connectors in the Data Connectivity Management service
- Support for connecting to the Data Catalog service in the Data Connectivity Management service
- Support for Kerberos and SSL for HDFS operations in the Data Connectivity Management service
- Support for excel-formatted data and default columns in the Data Connectivity Management service
- Support for reporting connector usage in the Data Connectivity Management service
- Support for preferred credentials for performing privileged operations in the Database Management service
- Support for passing a content encoding when posting metrics in the Monitoring service
- Support for Session Token authentication
 
### Breaking Changes
- The cmdlets `Get-OCIDataconnectivityConnectionValidationsList` and `Remove-OCIDataconnectivityConnectionValidation` were removed from the Data Connectivity Management service
- The models `Oci.DataconnectivityService.Models.ListConnectionValidationsResponse`, `Oci.DataconnectivityService.Models.ListConnectionValidationsRequest` and `Oci.DataconnectivityService.Models.DeleteConnectionValidationRequest` were removed in the Data Connectivity Management service
- The return type of property `LifecycleState` was changed to `LifecycleStateEnum` from `Registry.LifecycleStateEnum` in `Oci.DataconnectivityService.Requests.ListRegistriesRequest` model in the Data Connectivity Management service

## 39.1.0 - 2022-08-30
### Added
- Support for opting out of guest VM event collection, health metrics, diagnostics logs, and traces in the Database service
- Support for in-place upgrades for software-defined data centers in the VMWare Solution service
- Support for single-client access name protocol as a data source for private access channels in the Analytics Cloud service
- Support for network security groups, egress control on public datasources, and GitHub access in the Analytics Cloud service
- Support for performance-based autotuning of block and boot volumes in the Block Storage service

## 39.0.0 - 2022-08-23
### Added
- Support for the Enterprise Manager Warehouse service
- Support for additional configuration variables in the MySQL Database service
- Support for file filters in the DevOps service
- Support for support rewards redemption summaries in the Usage service
- Support for the parent tenancy of an organization to view child tenancy categories, recommendations, and resource actions in the Optimizer service
- Support for choosing prior versions during infrastructure maintenance on Exadata Cloud at Customer in the Database service

### Breaking Changes
- `EmDataLakeClient` was renamed to `EmWarehouseClient` in the Enterprise Manager Warehouse service

## 38.1.0 - 2022-08-16
### Added
- Support for Logging Analytics as a streaming source target in the Service Connector Hub service
- Support for data sources for logging query registration in the Cloud Guard service
- Support for custom detector rules on insight detector recipes in the Cloud Guard service
- Support for fetching data source events and problem entities in the Cloud Guard service
- Support for E3, E4, Standard3, and Optimized3 flexible compute shapes on notebooks, model deployment, and jobs in the Data Science service
- Support for streaming application logs to the Logging service in the Data Flow service

## 38.0.0 - 2022-08-09
### Added
- Support for single-host software-defined data centers in the VMWare Solution service
- Support for Java download and installation in the Java Management service
- Support for lifecycle management for Windows in the Java Management service
- Support for installation scripts in the Java Management service
- Support for unlimited-installation keys in the Java Management service
- Support for configuring automatic usage tracking in the Java Management service
- Support for STANDARDX and ENTERPRISEX instance types in Integration service
- Support for additional languages and multimedia formats in transcription jobs in the AI Speech service
- Support for maintenance run history for Exadata Cloud at Customer in the Database service
- Support for Optimizer statistics monitoring and management on various database administration operations in the Database Management service
- Support for OCI Compute instances in the Operations Insights service
- Support for moving resources in the Console Dashboard service
- Support for round-robin alerting in the Application Performance Monitoring service
- Support for aggregated network data of synthetic monitors in the Application Performance Monitoring service
- Support for etags on operations in the Load Balancing service
  
### Breaking Changes
- The enum `Oci.OpsiService.Models.UsageUnit` was replaced by `Oci.OpsiService.Models.UsageUnitEnum` in the Operations Insights service
- The `HostType` parameter has changed type from a list of `HostTypeEnum` to a list of `string` in the `Get-OCIOpsiHostInsightsList` cmdlet in the Operations Insights service

## 37.1.0 - 2022-08-02
### Added
- Support for OpenSearch in the Search service
- Support for child tables in the NoSQL Database Cloud service
- Support for private repositories in the DevOps service

## 37.0.0 - 2022-07-26
### Added
- Support for the Fusion Apps as a Service service
- Support for the Digital Media service
- Support for accessing all Terraform providers from Hashicorp Registry, as well as bringing your own providers, in the Resource Manager service
- Support for runtime configurations in notebook sessions in the Data Science service
- Support for compartmentIdInSubtree and accessLevel filters when listing management agents in the Management Agent Cloud service
- Support for filtering by type when listing work requests in the Management Agent Cloud service
- Support for filtering by agent id when listing management agent plugins in the Management Agent Cloud service
- Support for specifying size preference when requesting a data transfer appliance in the Data Transfer service
- Support for encryption of boot and block volumes associated with a cluster using customer-specified KMS keys in the Big Data service
- Support for the VM.Standard.E4.Flex shape for Cloud SQL (CSQL) nodes in the Big Data service
- Support for listing block and boot volumes, as well as block and boot volume replicas, within a volume group in the Block Volume service
- Support for dedicated autonomous databases in the Operator Access Control service
- Support for viewing automatic workload repository (AWR) data for databases added to AWRHub in the Operations Insights service
- Support for ports, protocols, roles, and SSL secrets when enabling or modifying database management in the Database service
- Support for monthly security maintenance runs in the Database service
- Support for monthly infrastructure patching for Exadata Cloud at Customer resources in the Database service
 
### Breaking Changes
- `DataMaskingActivityClient`,`FusionEnvironmentClient`, `FusionEnvironmentFamilyClient`, `RefreshActivityClient`,`ScheduledActivityClient`, and `ServiceAttachmentClient` clients were merged into a single client `FusionApplicationsClient` for the Fusion Apps as a Service service
- `OCIDataMaskingActivityCmdlet`, `OCIRefreshActivityCmdlet`, `OCIFusionEnvironmentCmdlet`, `OCIFusionEnvironmentFamilyCmdlet`, `OCIScheduledActivityCmdlet`, and `OCIServiceAttachmentCmdlet` classes have merged into one class `OCIFusionApplicationsCmdlet` for the Fusion Apps as a Service service

## 36.1.0 - 2022-07-19
### Added
- Support for calling Oracle Cloud Infrastructure services in the `mx-queretaro-1` region
- Support for the Process Automation service
- Support for the Managed Access service
- Support for extending maintenance reboot due dates on virtual machines in the Compute service
- Support for ingress routing tables on NAT gateways and internet gateways in the Networking service
- Support for container database and pluggable database discovery in the Stack Monitoring service
- Support for displaying rack serial numbers for Exadata infrastructure resources in the Database service
- Support for grace periods for wallet rotation on autonomous databases in the Database service
- Support for hosting models on flexible compute shapes with customizable OCPUs and memory in the Data Science service

## 36.0.0 - 2022-07-12
### Added
- Support for DBCS databases in the Operations Insights service
- Support for point-in-time recovery for non-highly-available database systems in the MySQL Database service
- Support for triggering reboot migration on instances with pending maintenance in the Compute service
- Support for native pod networking in the Container Engine for Kubernetes service
- Support for creating Data Guard associations with new database systems in the Database service
  
### Breaking Changes
- The data type of the property `HostType` was changed from a List of `string` to a List of `Oci.OpsiService.Requests.ListHostInsightsRequest.HostTypeEnum` in the `Get-OCIOpsiHostInsightsList` cmdlet in the Operations Insights service
- The parameter `PreserveDataVolumes` was removed from the `Invoke-OCIComputeTerminateInstance` cmdlet in the Compute service

## 35.3.0 - 2022-07-05
### Added
- Support for backup policies returned as part of the database system list operation in the MySQL Database service
 
### Changed
- The OCI PowerShell Modules will now return `UKNOWN_ENUM_VALUE` (null) instead of failing on unknown enums values to support forward enum compatibility

## 35.2.0 - 2022-06-27
### Added
- Support for the Network Monitoring service
- Support for specifying application scan settings when creating or updating host scan recipes in the Vulnerability Scanning service
- Support for moving data into an autonomous data warehouse in the Operations Insights service
- Support for shared infrastructure autonomous database character sets in the Database service
- Support for data collection logging events on Exadata instances in the Database service
- Support for specifying boot volume VPUs when launching instances from images in the Compute service
- Support for safe-deleting nodes in the Container Engine for Kubernetes service

## 35.1.0 - 2022-06-21
### Added
- Support for the Network Firewall service
- Support for smaller and larger HeatWave cluster nodes in the MySQL Database service
- Support for CSV file type datasets for text labeling and JSONL in the Data Labeling service
- Support for diagnostics in the Database Management service

## 35.0.0 - 2022-06-14
### Added
- Support for the Web Application Acceleration (WAA) service
- Support for the Governance Rules service
- Support for the OneSubscription service
- Support for resource locking in the Identity service
- Support for quota resource locking in the Limits service
- Support for returning the backup with the requested changes in the MySQL Database service
- Support for time zone in Cloud Autonomous VM (CAVM) clusters in the Database service
- Support for configuration options in the Application Performance Monitoring service
- Support for MySQL connections in the Database Tools service
  
### Breaking Changes
- The models `Oci.DatabasetoolsService.Models.DatabaseToolsAllowedNetworkSources`, `Oci.DatabasetoolsService.Models.DatabaseToolsVirtualSource`, and `Oci.DatabasetoolsService.Models.ServiceCapability` were removed from the Database Tools service

## 34.4.0 - 2022-06-07
### Added
- Support for calling Oracle Cloud Infrastructure services in the eu-paris-1 region
- Support for private endpoints in Resource Manager service
- Support downloading generated Terraform plan output in JSON or binary format in Resource Manager service
- Support for querying OPSI Data Objects in the Operations Insights service

### Changed
- Network security groups (NSGs) are now optional for autonomous databases on private endpoints in the Database service

## 34.3.0 - 2022-05-31
### Added
- Support for in-depth monitoring, diagnostics capabilities, and advanced management functionality for on-premise Oracle databases in the Database Management service
- Support for using Oracle Cloud Agent to perform iSCSI login and logout for non-multipath-enabled iSCSI attachments in the Container Engine for Kubernetes service
- Support for Fault Domain placement in the Container Engine for Kubernetes service
- Support for worker node images in the Container Engine for Kubernetes service
- Support for flexible shapes using the driverShapeConfig and executorShapeConfig properties in the Data Flow service

### Changed
- Service error messages have become more verbose to help diagnose issues

## 34.2.0 - 2022-05-24
### Added
- Support for the License Manager service
- Support for usage plans in the API Gateway service
- Support for packaged skill and instance metadata management, role-based access options on instance creation, and assigned ownership in the Digital Assistant service
- Support for compute capacity reservations in the VMWare Solution service
- Support for Oracle Linux 8 application streams in the OS Management service
  
### Fixed
- Service Error message in -Debug was fixed to log the correct Service name

## 34.1.0 - 2022-05-017
### Added
- Support for information requests in the Operator Access Control service
- Support for Helm charts and repositories on deployments in the DevOps service
- Support for Application Dependency Management service scan results on builds in the DevOps service
- Support for build resources to use Bitbucket Cloud repositories for source code in the DevOps service
- Support for character set selection on autonomous dedicated databases in the Database service
- Support for listing autonomous dedicated database supported character sets in the Database service
- Support for AMD E4 flex shapes on virtual machine database systems in the Database service
- Support for terraform and improvements for cross-region ADGs in the Database service
  
### Changed
- Improved `Debug` error messages

## 34.0.0 - 2022-05-10
### Added
- Support for getting usage information for autonomous databases and Cloud at Customer autonomous databases in the Database service
- Support for the "standby" lifecycle state on autonomous databases in the Database service
- Support for BIP connections and dataflow operators in the Data Integration service
  
### Breaking Changes
- The data type of property `DefaultConnection` was changed from `ConnectionSummaryFromBICC` to `ConnectionSummary` in the `Oci.DataintegrationService.Models.DataAssetSummaryFromFusionApp` model in the Data Integration service in the .NET SDK
- The data type of property `DefaultConnection` was changed from `ConnectionFromBICCDetails` to `ConnectionDetails` in the `Oci.DataintegrationService.Models.DataAssetFromFusionApp` model in the Data Integration service in the .NET SDK
- The data type of property `DefaultConnection` was changed from `CreateConnectionFromBICC` to `CreateConnectionDetails` in the `Oci.DataintegrationService.Models.CreateDataAssetFromFusionApp` model in the Data Integration service in the .NET SDK

## 33.0.0 - 2022-05-03
### Added
- Support for the Application Dependency Management service
- Support for E4 dense VMs on launch and update instance operations in the Compute service
- Support for reboot migration on DenseIO shapes in the Compute service
- Support for an increased database name maximum length, from 14 to 30 characters, in the Database service
- Support for provisioned concurrency in the Functions service
  
### Breaking Changes
- The cmdlet `Remove-OCIObjectstorageMultipartUpload` was renamed to `Stop-OCIObjectstorageMultipartUpload` in the Object Storage service

## 32.0.0 - 2022-04-26
### Added
- Support for the Service Mesh service
- Support for security zones in the Cloud Guard service
- Support for virtual test access points (VTAPs) in the Networking service
- Support for monitoring as a source in the Service Connector Hub service
- Support for creating budgets that target subscriptions and child tenancies in the Budgets service
- Support for listing shapes and specifying a shape during creation of a node in the Roving Edge Infrastructure service
- Support for bringing your own key in the Roving Edge Infrastructure service
- Support for enabling inspection of HTTP request bodies in the Web Application Acceleration and Security
- Support for cost management schedules in the Usage service
- Support for TCPS on external containers as well as non-container and pluggable databases in the Database service
- Support for autoscaling on Open Data Hub (ODH) clusters in the Big Data service
- Support for creating Open Data Hub (ODH) 0.9 clusters in the Big Data service
- Support for Open Data Hub (ODH) patch management in the Big Data service
- Support for customizable Kerberos realm names in the Big Data service
- Support for dedicated vantage points in the Application Performance Monitoring service
- Support for reactivating child tenancies in the Organizations service
- Support for punctuation and the SRT transcription format in the AI Speech service

### Breaking Changes
- The deprecated property `RiskScore` was removed from the `Oci.CloudguardService.Models.Sighting` model in the Cloud Guard service.
- The `SubscriptionId` parameter is now required in the `Get-OCITenantmanagercontrolplaneSubscriptionMappingsList` cmdlet in the Tenant Manager Control Plane service

## 31.0.0 - 2022-04-19
### Added
- Support for the Stack Monitoring service
- Support for stack monitoring on external databases in the Database service
- Support for upgrading VM database systems in place in the Database service
- Support for viewing supported VMWare software versions when listing host shapes in the VMWare Solution service
- Support for choosing compute shapes when creating SDDCs and ESXi hosts in the VMWare Solution service
- Support for work requests on delete operations in the Vulnerability Scanning service
- Support for additional scan metadata in reports, including CVE descriptions, in the Vulnerability Scanning service
- Support for redemption codes in the Usage service
- Support for Resource Principals Authentication Provider v2.2
  
### Breaking Changes
- The `Etag` property was removed from the Oci.UsageService.Responses.ListRedeemableUsersResponse response in the Usage service

## 30.1.0 - 2022-04-12
### Added
- Support for bringing your own IPv6 addresses in the Networking service
- Support for specifying database edition and maximum CPU core count when creating or updating an autonomous database in the Database service
- Support for enabling and disabling data collection options when creating or updating Exadata Cloud at Customer VM clusters in the Database service

## 30.0.0 - 2022-04-05
### Added
- Support for content length and content type response headers when downloading PDFs in the Account Management service
- Support for creating Enterprise Manager-based zLinux host targets, creating alarms, and viewing top process analytics in the Operations Insights service
- Support for diagnostic reboots on VM instances in the Compute service

### Breaking Changes
- The parameter `WaitForLifecycleState` was changed from type `Oci.DatasafeService.Models.LifecycleState` to `Oci.DatasafeService.Models.TargetDatabaseLifecycleState` in the cmdlet `Get-OCIDatasafeTargetDatabase` in the Data Safe service
- The parameter `LifecycleState` was changed from type `Oci.DatasafeService.Models.LifecycleState` to `Oci.DatasafeService.Models.TargetDatabaseLifecycleState` in the cmdlet `Get-OCIDatasafeTargetDatabasesList` in the Data Safe service

## 29.2.0 - 2022-03-29
### Added
- Support for returning the number of network ports as part of listing shapes in the Compute service
- Support for Java runtime removal and custom logs in the Java Management service
- Support for new parameters for BGP admin state and enabling/disabling BFD in the Networking service
- Support for private OKE clusters and blue-green deployments in the DevOps service
- Support for international customers to consume and launch third-party paid listings in the Marketplace service
- Support for additional fields on entities, attributes, and folders in the Data Catalog service
 
### Fixed
- New cmdlets are no longer omitted in the module manifest files.

## 29.1.0 - 2022-03-22
### Added
- Support for getting the storage utilization of a deployment on deployment list and get operations in the GoldenGate service
- Support for virtual machines, bare metal machines, and Exadata databases with private endpoints in the Operations Insights service
- Support for setting deletion policies on database systems in the MySQL Database service

## 29.0.0 - 2022-03-15
### Added
- Support for Ubuntu platforms and unlimited installation keys in the Management Agent Cloud service
- Support for shielded instances in the VMWare Solution service
- Support for application resources in the Data Integration service
- Support for multi-AVM on Exadata Cloud at Customer infrastructure in the Database service
- Support for heterogeneous (VM and AVM) clusters on Exadata Cloud at Customer infrastructure in the Database service
- Support for custom maintenance schedules for AVM clusters on Exadata Cloud at Customer infrastructure in the Database service
- Support for listing vulnerabilities, vulnerability-impacted containers, and vulnerability-impacted hosts in the Vulnerability Scanning service
- Support for specifying an image count when creating or updating container scan recipes in the Vulnerability Scanning service

### Changed
- Portable.BouncyCastle version was upgraded to `1.9.0`

### Breaking Changes
- The type of property `LifecycleState` was changed from `Oci.DataintegrationService.Models.Workspace.LifecycleStateEnum` to `Oci.DataintegrationService.Models.LifecycleStateEnum` for the WorkspaceSummary model in the Data Integration service in the .NET SDK

## 28.0.0 - 2022-03-08
### Added
- Support for the Sales Accelerator license option in the Content Management service
- Support for VCN hostname cluster endpoints in the Container Engine for Kubernetes service
- Support for optionally specifying an admin username and password when creating a database system during a restore operation in the MySQL Database service
- Support for automatic tablespace creation on non-autonomous and autonomous database dedicated targets in the Database Migration service
- Support for reporting excluded objects based on static exclusion rules and dynamic exclusion settings in the Database Migration service
- Support for removing, listing, and adding database objects reported by the Cloud Premigration Advisor Tool (CPAT) in the Database Migration service
- Support for migrating Oracle databases from the AWS RDS service to OCI as autonomous databases, using the AWS S3 service and DBLINK for data transfer, in the Database Migration service
- Support for querying additional fields of a resource using return clauses in the Search service
- Support for clusters and station clusters in the Roving Edge Infrastructure service
- Support for creating database systems and database homes using customer-managed keys in the Database service
 
### Breaking Changes
- The type of property `LifecycleState` was changed from `Oci.OceService.Requests.ListOceInstancesRequest.LifecycleStateEnum` to `Oci.OceService.Models.LifecycleState` in the Get-OCIOceInstancesList cmdlet in Content Management service
- The type of property `WaitForLifecycleState` was changed from `Oci.OceService.Models.OceInstance.LifecycleStateEnum` to `Oci.OceService.Models.LifecycleState` in the Get-OCIOceInstance cmdlet in Content Management service

## 27.2.0 - 2022-03-01
### Added
- Support for DRG route distribution statements to be specified with a new match type 'MATCH_ALL' for matching criteria in the Networking service
- Support for VCN route types on DRG attachments for deciding whether to import VCN CIDRs or subnet CIDRs into route rules in the Networking service
- Support for CPS offline reports in the Database service
- Support for infrastructure patching v2 features in the Database service
- Support for auto-scaling the storage of an autonomous database, as well as shrinking an autonomous database, in the Database service
- Support for managed egress via a default networking option on jobs and notebooks in the Data Science service
- Support for more types of saved search enums in the Management Dashboard service

## 27.1.0 - 2022-02-22
### Added
- Support for the Data Connectivity Management service
- Support for the AI Speech service
- Support for disabling crash recovery in the MySQL Database service
- Support for detector recipes of type `threat`, new detector rule of type `rogue user`, and sightings operations in the Cloud Guard service
- Support for more VM shape configurations when listing shapes in the Compute service
- Support for customer-managed encryption keys in the Analytics Cloud service
- Support for FastConnect device information in the Networking service

## 27.0.0 - 2022-02-15
### Added
- Support for the AI Vision service
- Support for the Threat Intelligence service
- Support for creation of NoSQL database tables with on-demand throughput capacity in the NoSQL Database Cloud service
- Support for tagging features in the Oracle Container Engine for Kubernetes (OKE) service
- Support for trace snapshots in the Application Performance Monitoring service
- Support for auditing and alerts in the Data Safe service
- Support for data discovery and data masking in the Data Safe service
- Support for customized subscriptions and delivery of announcements by email and SMS in the Announcements service
  
### Breaking Changes
- The deprecated API `QueryOld` from `QueryClient` and its request model `QueryOldRequest` were removed in the Application Performance Monitoring service in the .NET SDK

## 26.0.0 - 2022-02-08
### Added
- Support for managing tablespaces in the Database Management service
- Support for upgrading and managing payment for subscriptions in the Account Management service
- Support for listing fast launch job configurations in the Data Science service

### Breaking Changes
- The data type of the property BillToAddress was changed from `Address` to `BillToAddress` for the Invoice model of the Account Management service in the .Net SDK

## 25.3.0 - 2022-02-01
### Added
- Support for calling Oracle Cloud Infrastructure services in the `ap-dcc-canberra-1` region
- Support for the Console Dashboard service
- Support for capacity reservation in the Container Engine for Kubernetes service
- Support for tagging in the Container Engine for Kubernetes service
- Support for fetching listings by image OCID in the Marketplace service
- Support for underscores and hyphens in project resource names in the DevOps service
- Support for cross-region cloning in the Database service

## 25.2.0 - 2022-01-25
### Added
- Support for OneSubscription services
- Support for specifying if a run or application is streaming or batch in the Data Flow service
- Support for updating the Instance Configuration of an Instance Pool within a Cluster Network in the Compute Management service
- Updated documentation for Cross Region ADG feature for Autonomous Database in the Database service

## 25.1.0 - 2022-01-18
### Added
- Support for calling Oracle Cloud Infrastructure services in the `me-dcc-muscat-1` region
- Support for the Visual Builder service
- Support for cross-region replication of volume groups in the Block Storage service
- Support for boot volume encryption in the Container Engine for Kubernetes service
- Support for adding metadata to records when creating and updating records in the Data Labeling service
- Support for global export formats in snapshot datasets in the Data Labeling service
- Support for adding labeling instructions to datasets in the Data Labeling service
- Support for updating autonomous dataguard associations for autonomous container databases in the Database service
- Support for setting up automatic failover when creating autonomous container databases in the Database service
- Support for setting the RECO storage size when updating a database system in the Database service
- Support for reconnecting refreshable clones to source for autonomous databases on shared infrastructure in the Database service
- Support for checking if an autonomous database on shared infrastructure can be reconnected to source, in the Database service

## 25.0.0 - 2022-01-11
### Added
- Support for calling Oracle Cloud Infrastructure services in the `af-johannesburg-1` and `eu-stockholm-1` regions
- Support for multiple protocols on the same listener in the Network Load Balancing service
- IPv6 support in the Network Load Balancing service
- Support for creating Enterprise Manager-based Solaris and SunOS host targets in the Operations Insights service
- Support for choosing Data Guard type (Active Data Guard or regular) on databases in the Database service
- Support for Optional `HttpCompletionOption` parameter that can be provided for Head requests in all service clients for API requests
 
### Breaking Changes
- The data type of property `Action` was changed from `System.Nullable<Oci.CoreService.Requests.InstanceActionRequest.ActionEnum>` to `string` in `Invoke-OCIComputeInstanceAction` in Compute service
- The data type of property `Action` was changed from `System.Nullable<Oci.DatabaseService.Requests.DbNodeActionRequest.ActionEnum>` to `string` in `Invoke-OCIDatabaseDbNodeAction` in Database service
- The data type of property `Protocol` was changed from `System.Nullable<Oci.IdentityService.Requests.ListIdentityProvidersRequest.ProtocolEnum>` to `string` in `Get-OCIIdentityProvidersList` in Identity service
- The data type of property `Fields` was changed from `System.Nullable<Oci.ObjectstorageService.Requests.ListObjectsRequest.FieldsEnum>` to `string` in `Get-OCIObjectstorageObjectsList` in Object Storage service
- The data type of property `Fields` was changed from `System.Nullable<Oci.ObjectstorageService.Requests.ListObjectVersionsRequest.FieldsEnum>` to `string` in `Get-OCIObjectstorageObjectVersionsList` in Object Storage service

## 24.4.0 - 2021-12-14
### Added
- Support for node replacement in the VMWare Solution service
- Support for ingestion of SQL stats metrics in the Operations Insights service
- Support for AWR hub integration in the Operations Insights service
- Support for automatically generating logical entities from filename patterns and relationships between business terms across glossaries in the Data Catalog service
- Support for automatic start/stop at scheduled times in the Database service
- Support for cloud VM cluster resources on autonomous dedicated databases in the Database service
- Support for external Hive metastores in the Big Data service
- Support for batch detection/inference in the AI Language service
- Support for dimensions on monitoring targets in the Service Connector Hub service
- Support for invoice operations in the Account Management service
- Support for custom CA trust stores in the API Gateway service
- Support for generating scoped database tokens in the Identity service
- Support for database passwords for users, for logging into database accounts, in the Identity service

## 24.3.0 - 2021-12-07
### Added
 - Support for the Application Management service
 - Support for getting the inventory of JMS resources and listing Java runtime usage in a specified host in the Java Management service
 - Support for categories, entity topology, and verifying scheduled tasks in the Logging Analytics service
 - Support for RAC databases in the GoldenGate service
 - Support for querying additional fields of a resource using return clauses in the Search service
 - Support for key versions and key version OCIDs in the Key Management service

## 24.2.0 - 2021-11-30
### Added
 - Support for SQL Tuning Advisor in the Database Management service
 - Support for listing users and getting user details in the Database Management service
 - Support for autonomous databases in the Database Management service
 - Support for enabling and disabling Database Management features on autonomous databases in the Database service
 - Support for the Solaris platform in the Management Agent Cloud service
 - Support for cross-compartment operations in the Operations Insights service
 - Support for listing deployment backups in the GoldenGate service
 - Support for standard tags in the Identity service
 - Support for viewing problems for deleted targets in the Cloud Guard service
 - Support for choosing a platform version while creating a platform instance in the Blockchain Platform service
 - Support for custom IPSec connection tunnel internet key exchange phase 1 and phase 2 encryption algorithms in the Networking service
 - Support for pagination when listing work requests corresponding to an APM domain in the Application Performance Monitoring service
 - Support for the "deleted" lifecycle state on APM domains in the Application Performance Monitoring service
 - Support for calling Oracle Cloud Infrastructure services in the eu-milan-1 and me-abudhabi-1 regions

## 24.1.0 - 2021-11-17
### Added
 - Support for getting subnet topology in the Networking service
 - Support for encrypted FastConnect resources in the Networking service
 - Support for performance and high availability, as well as recommendation metrics, in the Optimizer service
 - Support for optional TDE wallet passwords in the Database service
 - Support for Object Storage service integration in the Big Data service

## 24.0.0 - 2021-11-09
### Added
 - Support for drill down metadata in the Management Dashboard service
 - Support for operator access control on dedicated autonomous databases in the Operator Access Control service

### Breaking Changes
 - The output type of `New-OCIOperatoraccesscontrolOperatorControlAssignment` changed from `Oci.PSModules.Common.Cmdlets.WorkRequest` to `Oci.OperatoraccesscontrolService.Models.OperatorControlAssignment` in the Operatoraccesscontrol service.

### Fixed
 - Refreshing Instance Principals tokens after they expire

## 23.1.0 - 2021-11-02
### Added
- Support for the Database Tools service
- Support for scan listener port TCP and TCP SSL on cloud VM clusters in the Database service
- Support for domains in the Identity service
- Support for redeemable users and support rewards in the Usage service
- Support for calling Oracle Cloud Infrastructure services in the ap-singapore-1 and eu-marseille-1 regions
 
### Changed
- Endpoint for Identity service changed to include `.oci` subdomain

## 23.0.0 - 2021-10-26
### Added
- Support for the Source Code Management service
- Support for the Build service
- Support for the Certificates service
- Support to create child tenancies in an organization and manage subscriptions in the Organizations service
- Support for Certificates service integration in the Load Balancing service
- Support for creating hosts in specific availability domains in the VMWare Solution service
- Support for user-defined functions and libraries, as well as scheduling and orchestration, in the Data Integration service
- Support for EM-managed Exadatas and EM-managed hosts in the Operations Insights service
- Support for custom Second Level Domain via OCI_DEFAULT_REALM environment variable for unknown regions

### Breaking Changes
- The cases `COMPUTE_INSTANCE_GROUP_BLUE_GREEN_TRAFFIC_SHIFT`, `COMPUTE_INSTANCE_GROUP_CANARY_DEPLOYMENT`, `COMPUTE_INSTANCE_GROUP_ROLLING_DEPLOYMENT`, `LOAD_BALANCER_TRAFFIC_SHIFT`, `WAIT`, `COMPUTE_INSTANCE_GROUP_CANARY_TRAFFIC_SHIFT`, `RUN_VALIDATION_TEST_ON_COMPUTE_INSTANCE`, `RUN_DEPLOYMENT_PIPELINE`, and `COMPUTE_INSTANCE_GROUP_BLUE_GREEN_DEPLOYMENT` were removed in the DeployStageExecutionProgress model's ReadJson method in the DevOps service from the OCI .NET SDK.

## 22.2.0 - 2021-10-19
### Added
- Support for creating database systems from backups with database software images in the Database service
- Support for optionally providing a SID prefix during Exadata database creation in the Database service
- Support for node subsetting on VM clusters in the Database service
- Support for non-CDB to PDB conversion in the Database service
- Support for default homepages, unprocessed data buckets, and parsing geostats in the Logging Analytics service

## 22.1.0 - 2021-10-12
### Added
- Support for the Data Labeling Service
- Support for querying and setting Application Performance Monitoring configurations in the Application Performance Monitoring service
- Support for the run-once monitor feature and network data collection in the Application Performance Monitoring service
- Support for Oracle Enterprise Manager bridges, source auto-association, source event types mapping, and partitioning and searching data by LogSet in the Logging Analytics service
- Support for Log events APIs used by plugins like fluentd, fluentbit, etc. to upload data in the Logging Analytics service
- Support for a new ActionType: `FAILED` in work requests in the VMware Provisioning service
- Support for calling Oracle Cloud Infrastructure services in the il-jerusalem-1 region

## 22.0.0 - 2021-10-05
### Added
- Support for configuring Binlog variables in the MySQL Database service
- Support new response value "OPERATOR" for backup creationType in list and get MDS backup API in the MySQL Database service
- Support for SetAutoUpgradableConfig and GetAutoUpgradableConfig operations in Management Agent Cloud service
- Support for additional installType filter for List Management Agents, Images and Count API operations in Management Agent Cloud service
- Support for list and read DeploymentUpgrade, cancel and restore DeploymentBackup in the Golden Gate service
- Support for non-autonomous databases targets, executing Pre-Migration advisor, uploading Datapump logs into Object Storage bucket, and filtering Database Objects in the Database Migration service
- Support for calling Oracle Cloud Infrastructure services in the ap-ibaraki-1 region

### Breaking Changes
- The `IsAgentAutoUpgradable` property was removed from the `Oci.ManagementagentService.Models.UpdateManagementAgentDetails` model in Management Agent Cloud service
- The `DisplayName` property was removed from `Oci.DatabasemigrationService.Requests.ListWorkRequestsRequest`, `Oci.DatabasemigrationService.Requests.ListWorkRequestLogsRequest` & `Oci.DatabasemigrationService.Requests.ListWorkRequestErrorsRequest` in the Database Migration service
- The `SortByEnum` enum member `DisplayName` was removed and enum member `TimeCreated` was replaced by `TimeAccepted` in `Oci.DatabasemigrationService.Requests.ListWorkRequestsRequest`, `Oci.DatabasemigrationService.Requests.ListWorkRequestLogsRequest`, and `Oci.DatabasemigrationService.Requests.ListWorkRequestErrorsRequest`  in the Database Migration service
- The type for the `LifecycleState` property was changed from `LifecycleStates` to `MigrationLifecycleStates` in `Oci.DatabasemigrationService.Requests.ListMigrationsRequest` in the Database Migration service
- The `CompartmentId` property was removed from `Oci.DatabasemigrationService.Models.UpdateAgentDetails` in the Database Migration service

### Fixed
- Fixed `ContentType` and `ContentLength` properties not being used in the `PutObject` API for the Object Storage Service

## 21.0.0 - 2021-09-28
### Added
- Support for autonomous databases and clones on shared infrastructure not requiring mTLS in the Database service
- Support for server-side encryption using object-specific KMS keys in the Object Storage service
- Support for Windows in the Java Management service
- Support for using network security groups in the API Gateway service
- Support for network security groups in the Functions service
- Support for signed container images in the Functions service
- Support for setting message format when creating and updating alarms in the Monitoring service
- Support for user and security assessment features in the Data Safe service
 
### Breaking Changes
- The following cmdlets were removed from the Java Management service: `Invoke-OCIJmsRequestSummarizedApplicationUsage`, `Invoke-OCIJmsRequestSummarizedInstallationUsage`, `Invoke-OCIJmsRequestSummarizedJreUsage`, and `Invoke-OCIJmsRequestSummarizedManagedInstanceUsage`
- The following models were removed from the Java Management service: `RequestSummarizedApplicationUsageDetails`, `RequestSummarizedInstallationUsageDetails`, `RequestSummarizedJreUsageDetails` and `RequestSummarizedManagedInstanceUsageDetails`
- The following requests were removed from the Java Management service: `RequestSummarizedInstallationUsageRequest` and `RequestSummarizedManagedInstanceUsageRequest`

## 20.1.0 - 2021-09-14
### Added
- Support for `ServiceHostKeyFingerprint` property for InstanceConsoleConnection in Core service
- Support for Shielded Instances in Core service
- Support for ML Jobs in the Data Science service

## 20.0.0 - 2021-09-07
### Added
- Support for terraform advanced options (detailed log level, refresh, and parallelism) on jobs in the Resource Manager service
- Support for forced cancellation when cancelling jobs in the Resource Manager service
- Support for getting the detailed log content of a job in the Resource Manager service
- Support for provider information in the responses of list operations in the Management Dashboard service
- Support for scheduled jobs in Database Management service
- Support for monitoring and management of OCI virtual machine, bare metal, and ExaCS databases in the Database Management service
- Support for a unified way of managing both external and cloud databases in the Database Management service
- Support for metrics and Performance Hub on virtual machine, bare metal, and ExaCS databases in the Database Management service
 
### Breaking Changes
- The property `OciSplatGeneratedOcids` was removed from `Oci.ResourcemanagerService.Requests.CreateTemplateRequest` in the Resource Manager service

## 19.2.0 - 2021-08-31
### Added
- Support for Oracle Analytics Cloud and OCI Vault integration on connections in the Data Catalog service
- Support for critical event monitoring in the OS Management service

## 19.1.0 - 2021-08-24
### Added
- Support for generating recommended VM cluster networks in the Database service
- Support for creating VM cluster networks with a specified listener port in the Database service

## 19.0.0 - 2021-08-17
### Added
Support for getting management agent hosts which are eligible to create Operations Insights host resources on, in the Operations Insights service
Support for getting summarized agent counts and summarized plugin counts in the Management Agent Cloud service

### Breaking
The type for parameters `PluginName` and `Version` have changed from `string` to `System.Collections.Generic.List<string>` in the `Get-OCIManagementagentsList` cmdlet in the Management Agent service.
The type for parameter `PlatformType` has changed from `System.Nullable<Oci.ManagementagentService.Models.PlatformTypes>` to `System.Collections.Generic.List<Oci.ManagementagentService.Models.PlatformTypes>` in the `Get-OCIManagementagentsList` cmdlet in the  Management Agent service.

## 18.2.0 - 2021-08-03
### Added
- Support for manually copying volume group backups across regions in the Block Volume service.
- Support for work requests for the copy volume backup and copy boot volume backup operations in the Block Volume service.
- Support for specifying external Hive metastores during application creation in the Data Flow service.
- Support for changing the compartment of a backup in the MySQL Database service.
- Support for model catalog features including provenance, metadata, schemas, and artifact introspection in the Data Science service.
- Support for Exadata system network bonding in the Database service.
- Support for creating autonomous databases with early patching enabled in the Database service.

## 18.1.0 - 2021-07-27
### Added
- Support for filtering by tag on capacity planning and SQL warehouse list operations in the Operations Insights service.
- Support for creating cross-region autonomous data guards in the Database service.
- Support for the customer contacts feature on cloud exadata infrastructure in the Database service.
- Support for cost analysis custom tables in the Usage service.

## 18.0.0 - 2021-07-20
### Added
- Support for schedules, schedule tasks, REST tasks, operators, S3, and Fusion Apps in the Data Integration service.
- Support for getting available updates and update histories for VM clusters in the Database service.
- Support for downloading network validation reports for Exadata network resources in the Database service.
- Support for patch and upgrade of Grid Infrastructure (GI), and update of DomU OS software for VM clusters in the Database service.
- Support for updating data guard associations in the Database service.
- Limit Expect 100-continue to be enabled for only for Object Storage anf Log Analytics service.
 
### Breaking Changes
- The property `BucketName` was replaced by `BucketSchema` in the `Oci.DataintegrationService.Models.OracleAdwcWriteAttributes` and `Oci.DataintegrationService.Models.OracleAtpWriteAttributes` models in the Data Integration service.
- The type for property `Type` was changed from `BaseType` to `System.Object` for the `Oci.DataintegrationService.Models.Parameter` model in the Data Integration service.
- The type for property `Type` was changed from `string` to `System.Object` for the `Oci.DataintegrationService.Models.ShapeField` and `Oci.DataintegrationService.Models.NativeShapeField` models in the Data Integration service.

## 17.0.0 - 2021-07-13
### Added
- Support for the AI Anomaly Detection service.
- Support for retrieving a DNS zone as a zone file in the DNS service.
- Support for querying manual adjustments in the Usage service.
- Support for searching Marketplace listings in the Marketplace service.
- Support for new cluster type 'ODH' in the Big Data service.
- Support for availability domain as an optional parameter when creating VLANs in the Networking service.
- Support for search domain type on DHCP options, to support multi-level domain search in the Networking service.
 
### Breaking Changes
- The property `TSIG` was removed from `Oci.DnsService.Models.ExternalMaster` model in the DNS service.
- The models `Oci.UsageapiService.Models.SavedScheduleReport`, `Oci.UsageapiService.Models.ScheduleReport`, `Oci.UsageapiService.Models.ScheduleReportSummary`, `Oci.UsageapiService.Models.UpdateCustomTableDetail` and `Oci.UsageapiService.Models.UpdateScheduleReportDetails` were removed from the Usage Service.

## 16.1.0 - 2021-07-06
### Added
- Support for order activation in the Organizations service.
- Support for resource principal authorization on Enterprise Manager bridge resources in the Operations Insights service.
- Support for the starter edition license type in the Content and Experience service.
- Support for the Generic Artifacts service's new domain name.

## 16.0.0 - 2021-06-29
### Added
- Support for the DevOps service.
- Support for configuring network security groups for node pools in the Container Engine for Kubernetes service.
- Support for optionally specifying CPU core count and data storage size when creating autonomous databases in the Database service.
- Support for metastore and initial data asset import/export in the Data Catalog service.
- Support for associating domain names to emails and managing email domain names / DKIM in the Email Delivery service.
- Support for email domain names on senders and suppressions in the Email Delivery service.
 
### Breaking Changes
- `DISPLAYNAME` enum was removed from the `SortBy` property in `Oci.DatacatalogService.Requests.ListJobExecutionsRequest` in the Data Catalog service.
- The property `CpuCoreCount` was made optional in `Oci.DatabaseService.Models.CreateAutonomousDatabaseBase` in the Database service.
- `SortOrder` type was changed from `Oci.EmailService.Requests.ListSendersRequest.SortOrderEnum` to `Oci.EmailService.Models.SortOrder` in the `Get-OCIEmailSendersList` cmdlet in the Email service.
- `SortOrder` type was changed from `Oci.EmailService.Requests.ListSendersRequest.SortOrderEnum` to `Oci.EmailService.Models.SortOrder` in the `Get-OCIEmailSuppressionsList` cmdlet in the Email service.

## 15.1.0 - 2021-06-22
### Added
- Support for virtual machine and bare metal pluggable databases in the Database service

## 15.0.0 - 2021-06-15
### Added
- Support for elastic storage on Exadata Infrastructure resources for Cloud at Customer in the Database service.
- Support for registration and management of target databases in the Data Safe service.
- Support for config on metadata in the Management Dashboard service.
- Support for a new work request operation type for node pool reconciliation events in the Container Engine for Kubernetes service.
- Support for migrating clusters with a public Kubernetes API endpoint which are not integrated with a customer's VCN to a VCN-native cluster in the Container Engine for Kubernetes service.
- Support for getting the spark version of applications, and filtering applications by spark version, in the Data Flow service.

### Breaking Changes
- The properties `FreeformTags` and `DefinedTags` were removed from the `Oci.ManagementdashboardService.Models.ManagementDashboardExportDetails` model in the Management Dashboard service.

## 14.2.0 - 2021-06-08
### Added
- Support for Java Management service.
- Support for resource principals for the Enterprise Manager bridge resource in Operations Insights service.
- Support for encryptionInTransitType in BootVolumeAttachment and IScsiVolumeAttachment in Core service.
- Support for updating iscsiLoginState for VolumeAttachment in Core service.
- Support for a new type of Source called Import for use with the Export tool in Application Migration service.

## 14.1.0 - 2021-06-01
### Added
- Support for configuration of autonomous database KMS keys in the Database service.
- Support for creating database software images with any supported RUs in the Database service.
- Support for creating database software images from an existing database home in the Database service.
- Support for listing all NSGs associated with a given VLAN in the Networking service.
- Support for a duration windows, task failure reasons, and next execution times on scheduled tasks in the Logging Analytics service.
- Support for calling Oracle Cloud Infrastructure services in the sa-vinhedo-1 region.

## 14.0.0 - 2021-05-25
### Added
- Support for the Generic Artifacts service.
- Support for the Bastion service.
- Support for reading secrets by name in the Vault service.
- Support for the isDynamic field when listing definitions in the Limits service.
- Support for getting billable image sizes in the Compute service.
- Support for getting Automatic Workload Repository (AWR) data on external databases in the Database Management service.
- Support for the VM.Standard.E3.Flex flexible compute shape with customizable OCPUs and memory on notebooks in the Data Science service.
- Support for container images and generic artifacts billing in the Registry service.
- Support for the HCX Enterprise add-on in the VMware Solution service.
 
### Breaking Changes
- The type for `Name` property in `Oci.OcvpService.Models.SupportedSkuSummary` model was changed from `NameEnum` to `Sku` in the VMware Solution service.
- The property `InitialSku` in `Oci.OcvpService.Models.Sddc` and `Oci.OcvpService.Models.CreateSddcDetails` models was made optional in the VMware Solution service.
- The property `CurrentSku` in `Oci.OcvpService.Models.CreateEsxiHostDetails` model was made optional in the VMware Solution service.
- A required property `BillableSizeInGBs` was added to model `Oci.ArtifactsService.Models.ContainerRepository` and `Oci.ArtifactsService.Models.ContainerRepositorySummary` in the Artifacts service.

## 13.5.0 - 2021-05-18
### Added
- Support for spark-submit compatible options in the Data Flow service.
- Support for Object Storage as a configuration source in the Resource Manager service.

## 13.4.0 - 2021-05-11
### Added
- Support for creating notebook sessions with larger block volumes in the Data Science service.
- Support for database maintenance run patch modes in the Database service.

## 13.3.0 - 2021-05-04
### Added
- Support for the Operator Access Control service.
- Support for the Service Catalog service.
- Support for the AI Language service.
- Support for autonomous database on Exadata Cloud at Customer infrastructure patching in the Database service.

## 13.2.0 - 2021-04-27
### Added
- VCN id parameters were moved from being required to being optional on all list operations in the Networking service.
- Support for RACs (real application clusters) for external container, non-container, and pluggable databases in the Database service.
- Support for data masking in the Cloud Guard service.
- Support for opting out of DNS records during instance launch, as well as attaching secondary VNICs, in the Compute service.
- Support for mutable sizes on cluster networks in the Autoscaling service.
- Support for auto-tiering on buckets in the Object Storage service.

## 13.1.0 - 2021-04-20
### Added
- Support for opting in/out of live migration on instances in the Compute service.
- Support for enabling/disabling Operations Insights on external non-container and external pluggable databases in the Database service.
- Support for a GraphStudio URL as a connection URL on databases in the Database service.
- Support for adding customer contacts on autonomous databases in the Database service.
- Support for name annotations on harvested objects in the Data Catalog service.

## 13.0.0 - 2021-04-13
### Added
- Support for the Database Migration service.
- Support for the Networking Topology service.
- Support for getting the id of peered VCNs on local peering gateways in the Networking service.
- Support for burstable instances in the Compute service.
- Support for preemptible instances in the Compute service.
- Support for fractional resource usage and availability in the Limits service.
- Support for streaming analytics in the Service Connector Hub service.
- Support for flexible routing inside DRGs to enable packet flow between any two attachments in the Networking service.
- Support for routing policy to customize dynamic import/export of routes in the Networking service.
- Support for IPv6, including on FastConnect and IPsec resources, in the Networking service.
- Support for request validation policies in the API Gateway service.
- Support for RESP-compliant (e.g. REDIS) response caches, and for configuring response caching per-route in the API Gateway service.
- Support for flexible billing in the VMWare Solution service.
- Support for new DNS format for the Web Application Acceleration and Security service.
- Support for configuring APM tracing on applications and functions in the Functions service.
- Support for Enterprise Manager external databases and Management Agent Service managed external databases and hosts in the Operations Insights service.
- Support for getting cluster cache metrics for RAC CDB managed databases in the Database Management service.
 
### Breaking Changes
- Required property `PeerId` was added to the `Oci.CoreService.Models.LocalPeeringGateway` model in the Core service.
- The `IsInternetAccessAllowed` property was removed from the `Oci.CoreService.Models.CreateIpv6Details` model in the Core service.
- The `Ipv6CidrBlock` property was removed from the `Oci.CoreService.Models.CreateVcnDetails` model in the Core service.
- The `Ipv6PublicCidrBlock` property was removed from the `Oci.CoreService.Models.Subnet` model in the Core service.
- The `Ipv6PublicCidrBlock` property was replaced by `Ipv6CidrBlocks` in the `Oci.CoreService.Models.Vcn` model in the Core service.
- The properties `PublicIpAddress` and `IsInternetAccessAllowed` were removed from the `Oci.CoreService.Models.Ipv6` model in the Core service.
- `VcnId` was made optional in the `Oci.CoreService.Models.CreateDrgAttachmentDetails` model in the Core service.
- Required property `CurrentSku` was added to the `Oci.OcvpService.Models.CreateEsxiHostDetails` model in the Ocvp service.
- Required property `InitialSku` was added to the `Oci.OcvpService.Models.CreateSddcDetails` model in the Ocvp service.
- Required properties `BillingContractEndDate`, `NextSku` & `CurrentSku` were added to the `Oci.OcvpService.Models.EsxiHost` model in the Ocvp service.
- Required properties `BillingContractEndDate`, `NextSku` & `CurrentSku` were added to the `Oci.OcvpService.Models.EsxiHostSummary` model in the Ocvp service.
- Required property `InitialSku` was added to the `Oci.OcvpService.Models.Sddc` model in the Ocvp service.
- Required property `Id` was added to the `Oci.OpsiService.Models.DatabaseDetails` model in the Opsi service.
- The `CompartmentId` property was made optional in the `Oci.OpsiService.Requests.ListDatabaseInsightsRequest` request in the Opsi service.
- The properties `CompartmentId` and `DatabaseId` were made optional in the `Oci.OpsiService.Requests.IngestSqlTextRequest` request in the Opsi service.
- The properties `CompartmentId` and `DatabaseId` were made optional in the `Oci.OpsiService.Requests.IngestSqlPlanLinesRequest` request in the Opsi service.

## 12.1.0 - 2021-04-06
### Added
- Support for scheduling the suspension and resumption of compute instance pools based on predefined schedules in the Autoscaling service.
- Support for database software images for Cloud@Customer in the Database service.
- Support for OCIC IDCS authorization details in the Application Migration service.
- Support for cross-region asynchronous volume replication in the Block Storage service.
- Support for SDK generation in the API Gateway service.
- Support for container image signing in the Registry service.
- Support for cluster features as a part of the Container Engine for Kubernetes service.
- Support for filtering dedicated virtual machine hosts by remaining memory and OCPUs in the Compute service.
- Support for read/write-any object from buckets using pre-authenticated requests in the Object Storage service.
- Support for restricting pre-authenticated requests by prefix in the Object Storage service.
- Support for route filtering on public virtual circuits in the Virtual Networking service.

## 12.0.0 - 2021-03-30
### Added
- Support for the Vulnerability Scanning service.
- Support for vSphere 7.0 in the VMware Solution service.
- Support for forecasting in the Usage service.
- Support for viewing, searching, and modifying parameters for on-premise Oracle databases in the Database Management service.
- Support for listing tablespaces of managed databases in the Database Management service.
- Support for cross-regional replication of keys in the Key Management service.
- Support for highly-available database systems in the MySQL Database service.
- Support for Oracle Enterprise Manager bridges, source auto-association, source event type mappings, and plugins to upload data in the Logging Analytics service.
 
### Breaking Changes
- EnumMember `SUCCESFUL` was renamed to `SUCCESSFUL` in `Oci.LoganalyticsService.Requests.ListLookupsRequest.StatusEnum` in the Loganalytics service.
- Property `ForcastType` was renamed to `ForecastType` in the `Oci.UsageapiService.Models.Forecast` model in the Usageapi service.
- Property `TimeForecastStarted` is now optional in the `Oci.UsageapiService.Models.Forecast` model in the Usageapi service.

## 11.0.0 - 2021-03-23
### Added
- Support for the Network Load Balancing service.
- Support for maintenance runs on autonomous databases in the Database service.
- Support for announcement preferences in the Announcements service.
- Support for domain claiming in the Organizations service.
- Support for saved reports in the Usage service.
- Support for the HeatWave in-memory analytics accelerator in the MySQL Database service.
- Support for community applications in the Marketplace service.
- Support for capacity reservations in the Compute service.
 
### Breaking Changes
- `VnicId` is now a required property for `Oci.CoreService.Models.Ipv6` in the `Core` service.
- `VnicId` is now a required property for `Oci.CoreService.Models.CreateIpv6Details` in the `Core` service.
- `CompartmentId` was removed as a property from `Oci.TenantmanagercontrolplaneService.Requests.ListWorkRequestLogsRequest` in the `Tenantmanagercontrolplane` service.

## 10.2.0 - 2021-03-16
### Added
- Support for routing policies and HTTP2 listener protocols in the Load Balancing service.
- Support for model deployments in the Data Science service.
- Support for private clusters in the Container Engine for Kubernetes service.
- Support for updating an instance's usage type in the Content and Experience service.

## 10.1.0 - 2021-03-09
### Added
- Support for the Application Performance Monitoring service.
- Support for the Golden Gate service.
- Support for SMS subscriptions in the Notifications service.
- Support for friendly-formatted messages in the Service Connector Hub service.
- Support for attaching and detaching instances to instance pools in the Autoscaling service.

## 10.0.0 - 2021-03-02
### Added
- Support for pipelines, pipeline tasks, and favorites in the Data Integration service.
- Support for publishing tasks to OCI Data Flow in the Data Integration service.
- Support for clones in the File Storage service.
- Support for bundled modules.
 
### Breaking changes
- Changed `Oci.DataintegrationService.Models.UniqueKey` model in the Dataintegration service to not inherit from `Key`.
- Changed `Oci.DataintegrationService.Models.PrimaryKey` model in the Dataintegration service to inherit from `UniqueKey`.
- Removed `PRIMARY_KEY` and `UNIQUE_KEY` values from `KeyModelTypeEnum` in `Oci.DataintegrationService.Models.Key` model in the Dataintegration service.

## 9.2.0 - 2021-02-23
### Added
- Support for the OCI Registry service.
- Support for exporting an existing running VM, or a copy of VM, into a VMDK, QCOW2, VDI, VHD, or OCI formatted image in the Compute service.
- Support for platform configurations on instances in the Compute service.
- Support for providing target tags and target compartments on profiles in the Optimizer service.
- Support for the 'Fix it' feature in the Optimizer service.

## 9.1.0 - 2021-02-16
### Added
- Support for scan DNS names and zone ids on database system, cloud VM cluster, and autonomous Exadata infrastructure responses in the Database service.
- Support for specifying ACL rules to limit ingress into public load balancers in the Integration service.
- Support for Cloud at Customer as a source type in the Application Migration service.
- Support for selective migration of specific resources in the Application Migration service.

## 9.0.0 - 2021-02-09
### Added
- Support for the Database Management service.
- Support for setting an offset for budget processing in the Budgets service.
- Support for enabling and disabling Oracle Cloud Agent plugins in the Compute service.
- Support for listing available plugins and for getting the status of plugins in the Oracle Cloud Agent service.
- Support for one-off patching in autonomous transaction processing - dedicated databases in the Database service.
- Support for additional database upgrade options in the Database service.
- Support for glossary term recommendations in the Data Catalog service.
- Support for listing errata in the OS Management service.
 
### Breaking changes
- `InstallationRequirements` was replaced by `InstallationRequirementsEnum` in the WindowsUpdate object returned in `Get-OCIOsmanagementWindowsUpdate` cmdlet of the Osmanagement service.

## 8.0.0 - 2021-02-02
### Added
- Support for checking if a contact for Exadata infrastructure is valid in My Oracle Support in the Database service.
- Support for checking if Exadata infrastructure is in a degraded state in the Database service.
- Support for updating the operating system on a VM cluster in the Database service.
- Support for external databases in the Database service.
- Support for uploading objects to the infrequent access storage tier in the Object Storage service.
- Support for changing the storage tier of existing objects in the Object Storage service.
- Support for private templates in the Resource Manager service.
- Support for multiple encryption domains on IPSec tunnels in the Networking service.

### Breaking Changes
- `ListAppCatalogListingResourceVersionsResponse` in `Get-OCIComputeAppCatalogListingResourceVersionsList` no longer supports the `etag` parameter.
- Property `vnicId` in model `Oci.CoreService.Models.Ipv6` was removed as a parameter from the Core service.
- `ArchivalStateEnum` enum was replaced by `ArchivalState` in response `GetObjectResponse` in cmdlet `Get-OCIObjectStorageObject` in the Object Storage Service.

## 7.0.0 - 2021-01-26
### Added
- Support for creating, managing, and using asymmetric keys in the Key Management service.
- Support for peer ACD unique names in Exadata Cloud at Customer in the Database service.
- Support for ACLs on autonomous databases in Exadata Cloud at Customer Data Guard in the Database service.
- Support for drift detection on individual resources of a stack in the Resource Manager service.
- Support for private access channels and vanity URLs in the Analytics Cloud service.
- Support for updating load balancer shapes in the Blockchain Platform service.
- Support for assigning volume backup policies to volume groups in the Block Volume service.

### Breaking Changes
- CreateBlockchainPlatformDetails now has IdcsAccessToken as required property in the BlockChain service.

## 6.0.0 - 2021-01-19
### Added
- Support for Logging Analytics as a target in the Service Connector Hub service
- Support for lookups, agent collection warnings, task commands, and data archive/recall in the Logging Analytics service

### Fixed
- Fixed a bug in the endpoint used for the Management Dashboard service

### Breaking Changes
- Parameter `SortBy` in cmdlets `Get-OCILoganalyticsMetaSourceTypesList`, `Get-OCILoganalyticsParserFunctionsList`, `Get-OCILoganalyticsParserMetaPluginsList`, `Get-OCILoganalyticsSourceLabelOperatorsList`, `Get-OCILoganalyticsSourceMetaFunctionsList` has changed its datatype from `String` to `Oci.LoganalyticsService.Requests.ListSourceMetaFunctionsRequest.SortByEnum` in the Logging Analytics service
- Parameter `WaitForLifecycleState` in cmdlet `Get-OCILoganalyticsObjectCollectionRule` has changed its datatype from `LogAnalyticsObjectCollectionRule.LifecycleStateEnum` to `ObjectCollectionRuleLifecycleStates` in the Logging Analytics Service

## 5.0.0 - 2021-01-12
### Added
- Support for auto-scaling in the Big Data service
- Documentation fixes for the Logging Search service

### Breaking Changes
- Removed `STARTING` and `STOPPING` values from enum `Oci.BdsService.Models.Node.LifecycleStateEnum` in the Bds service
- Removed `UPDATING_INFRA` value from enum `Oci.BdsService.Models.BdsInstance.LifecycleStateEnum` in Get-OCIBdsInstancesList Cmdlet of Oci.PSModules.Bds

## 4.0.0 - 2020-12-15
### Added
- Support for filtering listKeys based on KeyShape in KeyManagement service
- Support for the Oracle Roving Edge Infrastructure service
- Support for flexible ShapeDetails in Load Balancer service
- Support for listing of harvested Rules, additional filtering for Logical Entity list calls in Data Catalog service
- Support second level domain for audit SDK
- Support for listing flex components in Database service
- Support for APEX service for ADBS on OCI console for Database service
- Support for Customer-Managed Key features as a part of the Database service
- Support for Github configuration source provider as part of the Resource Manager service
  
### Breaking Changes
- Removing deprecated Get-OCIDatabaseAutonomousDataWarehouse cmdlet from OCI.PSModules.Database module
- Removing deprecated New-OCIDatabaseAutonomousDataWarehouse cmdlet from OCI.PSModules.Database module
- Removing deprecated Remove-OCIDatabaseAutonomousDataWarehouse cmdlet from OCI.PSModules.Database module
- Removing deprecated New-OCIDatabaseAutonomousDataWarehouseWallet cmdlet from OCI.PSModules.Database module
- Removing deprecated New-OCIDatabaseAutonomousDataWarehouseBackup cmdlet from OCI.PSModules.Database module
- Removing deprecated Get-OCIDatabaseAutonomousDataWarehouseBackup cmdlet from OCI.PSModules.Database module
- Removing deprecated Get-OCIDatabaseAutonomousDataWarehouseBackupsList cmdlet from OCI.PSModules.Database module
- Removing deprecated Get-OCIDatabaseAutonomousDataWarehousesList cmdlet from OCI.PSModules.Database module
- Removing deprecated Restore-OCIDatabaseAutonomousDataWarehouse cmdlet from OCI.PSModules.Database module
- Removing deprecated Start-OCIDatabaseAutonomousDataWarehouse cmdlet from OCI.PSModules.Database module
- Removing deprecated Stop-OCIDatabaseAutonomousDataWarehouse API from OCI.PSModules.Database module

## 3.1.0 - 2020-12-08
### Added

- Support for Integration Service custom endpoint feature
- Support for metadata field in IdentityProvider Get and List response
- Support for fine-grained data analysis and improved SQL insights
- Support for ADB Dedicated - ORDS and SSL cert rotation at AEI
- Support for Maintenance Schedule feature for Exadata Infrastructure resources for ExaCC

## 3.0.0 - 2020-12-01
### Added
- Support for calling Oracle Cloud Infrastructure services in the sa-santiago-1 region
- Support for peer and OSN resources, as well as retry tokens, in the Blockchain Platform service
- Support for getting the availability status of management agents in the Management Agent service
- Support for the on-prem-connector resource type in the Data Safe service
- Support for service channels in the MySQL Database service
- Support for getting the creation type of backups, and for filtering backups by creation type in the MySQL Database service
  
### Breaking Changes
- DefinedTags and FreeformTags properties are removed from EnableDataSafeConfigurationDetails model in the Datasafe service
- CompartmentId parameter is changed from optional to required in ListDataSafePrivateEndpointsRequest in the Datasafe service
- IsEnabled property is changed from optional to required in EnableDataSafeConfigurationDetails model in the Datasafe service

## 2.0.0 - 2020-11-17
### Added

- Support for specifying memory for AMD E3 shapes during node pool creation and update in the Container Engine for Kubernetes service
- Support for upgrading a database on a VM database system in the Database service
- Support for listing autonomous database clones in the Database service
- Support for Data Guard with autonomous container databases on Exadata Cloud at Customer in the Database service
- Support for getting the last login time of a user in the Identity service
- Support to bulk editing tags on resources in the Identity service
- Property Id in CreateManagementSavedSearchDetails model is changed from required to optional in the Management Dashboard service
- Support for registering new regions and realms not supported by current version of OCI PowerShell Modules

### Breaking Changes

- The base type of parameter `Status` in `Get-OCIContainerengineWorkRequestsList` is changed from `Oci.ContainerengineService.Models.WorkRequestStatus` enum to `String` in the Container Engine for Kubernetes service
- The property `ErrorDetails` is removed from `Oci.LoganalyticsService.Responses.DeleteAssociationsResponse` in the `Remove-OCILoganalyticsAssociations` Cmdlet of Log Analytics module
- The enum `name` removed value `CuslterSplit` and added `ClusterSplit` in the Log Analytics service
- The type of property `Id` in `LogAnalyticsParserFilter` model is changed from `Object` to `String` in the Log Analytics service

## 1.12.0 - 2020-11-10
### Added
- Support for the 21C autonomous database version in the Database service
- Support for creating a Data Guard association with a standby database from a database software image in the Database service
- Support for specifying a TDE wallet password when creating a database or database system in the Database service
- Support for enabling access control lists for autonomous databases on Exadata Cloud At Customer in the Database service
- Support for private DNS resolvers, resolver endpoints, and views in the DNS service
- Support for getting a VCN and resolver association in the Networking service
- Support for additional parameters when updating subnets and VLANs in the Networking service
- Support for analytics clusters (database accelerators) in the MySQL Database service
- Support for migrations to Java Cloud Service and Oracle Weblogic Server instances that use existing databases in the Application Migration service
- Support for specifying reserved IPs when creating load balancers in the Load Balancing service

## 1.11.0 - 2020-11-03
### Added

- Support for calling Oracle Cloud Infrastructure services in the uk-cardiff-1 region
- Support for the Organizations service
- Support for the Optimizer service
- Support for tenancy ID and name on responses in the Usage service
- Support for object versioning in object lifecycle management in the Object Storage service
- Support for specifying a syslog URL for applications in the Functions service
- Support for creation of always-free NoSQL database tables in the NoSQL Database service

## 1.10.0 - 2020-10-27
### Added
- Support for the Compute Instance Agent service
- Support for key store resources and operations in the Database service
- Support for specifying a key store when creating autonomous container databases in the Database service

## 1.9.0 - 2020-10-20
### Added

- Support for the Operations Insights service
- Support for updating autonomous databases to enable/disable Operations Insights service integration, in the Database service
- Support for the NEEDS_ATTENTION lifecycle state on database systems in the Database service
- Support for HCX in the VMware Solutions service

## 1.8.0 - 2020-10-13
### Added

- Support for API definitions in the API Gateway service
- Support for pattern-based logical entities, namespace-bound custom properties, and faceted search in the Data Catalog service
- Support for autonomous Data Guard on autonomous infrastructure in the Database service
- Support for creating a Data Guard association on an existing standby database home in the Database service
- Support for upgrading cloud VM cluster grid infrastructure in the Database service

## 1.7.0 - 2020-10-06
### Added
    
- Support for calling Oracle Cloud Infrastructure services in the me-dubai-1 region
- Support for rotating keys on autonomous container databases and autonomous databases in the Database service
- Support for cloud Exadata infrastructure and cloud VM clusters in the Database service
- Support for controlling the display of tax banners in the Marketplace service
- Support for application references, patch changes, generic JDBC and MySQL data asset types, and publishing tasks to OCI Dataflow in the Data Integration service
- Support for disabling the legacy Instance Metadata endpoints v1 in the Compute service
- Support for instance configurations specifying instance options in the Compute Management service
- Support for Instance Principal Authentication

## 1.6.0 - 2020-09-29
### Added

- Support for specifying custom content dispositions when downloading objects in the Object Storage service
- Support for the “bring your own IP address” feature in the Virtual Networking service
- Support for updating the tags of instance console connections in the Compute service
- Support for custom SSL certificates on gateways in the API Gateway service

## 1.5.0 - 2020-09-22
### Added

- Support for software keys in the Key Management service
- Support for customer contacts on Exadata Cloud at Customer in the Database service
- Support for updating open modes and permission levels of autonomous databases in the Database service
- Support for flexible memory on VM instances in the Compute and Compute Management services

## 1.4.0 - 2020-09-15
### Added

- Support for the Cloud Guard service
- Support for specifying desired consumption models when creating instances in the Integration service
- Support for dynamic shapes in the Load Balancing service

## 1.3.0 - 2020-09-08
### Added
 
- Support for Logging Service
- Support for Logging Analytics Service
- Support for Logging Search Service
- Support for Logging Ingestion Service
- Support for Management Agent Cloud Service
- Support for Management Dashboard Service
- Support for Service Connector Hub service
- Support for Policy based Request/Response transformation in the API Gateway Service
- Support for sending diagnostic interrupt to a VM instance in the Compute Service
- Support for custom Database Software Images in the Database Service
- Support for getting and listing container database patches for Autonomous Container Database resources in the Database Service
- Support for updating patch id on maintenance run for Autonomous Container Database resources in the Database Service
- Support for searching Oracle Cloud resources across tenancies in the Search Service
- Documentation update for Logging Policies in the API Gateway service

## 1.2.0 - 2020-09-01
### Added

- Support for calling Oracle Cloud Infrastructure services in the ap-chiyoda-1 region
- Support for VM database cloning in the Database service
- Support for the MAINTENANCE_IN_PROGRESS lifecycle state on database systems, VM clusters, and Cloud Exadata in the Database service
- Support for provisioning refreshable clones in the Database service
- Support for new options on listeners and backend sets for specifying SSL protocols, SSL cipher suites, and server ordering preferences in the Load Balancing service
- Support for AMD flexible shapes with configurable CPU in the Container Engine for Kubernetes service
- Support for network sources in authentication policies in the Identity service

## 1.1.0 - 2020-08-18
### Added

- Support for the Dataintegration service

## 1.0.0 - 2020-08-18
### Added

- Initial Release
- Config-Based Authentication
- Supports Waiters
- Supports Paginators
- Supports History Store
- Supports Non-Regional clients via `-EndPoint` parameter
- Support for Debug and Verbose level logging using `-Debug` and `-Verbose` parameters
