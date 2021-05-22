# Code-Clinic-Portal

[![Twitter Follow](https://img.shields.io/twitter/follow/hnicolus.svg?style=social&label=Follow)](https://twitter.com/hnicolus)

<br/>
This project is just for  learning purposes to help one understand more about Clean architecture and Command Query Responsibility Reperation (CRQS).
It is a simple Coding forum built with Angular and ASP.NET Core following the principles of Clean Architecture.

## Technologies

* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* Angular 10
* MediatR
* AutoMapper
* FluentValidation
* NUnit, FluentAssertions, Moq & Respawn

## Getting Started

1. Fork Repository
2. Navigate to solution folder 
3. Open Terminal 
4. run `dotnet restore`
6. Navigate to `src/WebUI/ClientApp` and run `npm start` to launch the front end (Angular)
7. Navigate to `src/WebUI` and run `dotnet run` to launch the back end (ASP.NET Core Web API)

### Database Configuration

The Program is configured to use an in-memory database or SQL Depending on developers preference and environment. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you using SQL Server , Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 
If you would like to use in-memory database, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": true,
```

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `-p src/Infrastructure` (optional if in this folder)
* `-s src/WebUI`
* `-o Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "MIGRATION_NAME" -p src\Infrastructure -s src\WebUI -o Persistence\Migrations`

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is a single page application based on Angular 9 and ASP.NET Core 3.1. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

### Roadmap 

- [x] esearch
- [x] Setup
- [x] Base Entities

## License
