# Change Log
All notable changes to this project will be documented in this file.

The format is based on Keep a [Changelog](https://keepachangelog.com/en/1.0.0/).

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
