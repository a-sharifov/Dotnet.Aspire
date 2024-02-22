# [Dotnet.Aspire](https://github.com/a-sharifov/Dotnet.Aspire) [![GitHub license](https://img.shields.io/badge/license-Apache-blue.svg)](https://github.com/a-sharifov/Dotnet.Aspire/blob/master/LICENSE.txt)


This repository serves to demonstrate the current capabilities of .NET Aspire.

## Usage
To run the project, ensure you have the required version of .NET and Docker installed. The project can be launched like any other C# project.

### Current Requirements :
- .NET8.0 or up
- Docker 25.0.2 or up 

## That is .NET Aspire

.NET Aspire is an opinionated, cloud ready stack for building observable, production ready, distributed applications. .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns.

## Features
- **Cloud-native Architecture**: .NET Aspire boasts a cloud-native architecture, making it easy to deploy and manage in Azure environments.
- **Seamless Azure Deployment**: With .NET Aspire, deploying applications to Azure is a straightforward process, thanks to its integration with Azure services.
- **Intuitive Dashboard**: The platform offers an intuitive and visually appealing dashboard, simplifying monitoring and management tasks.
- **Built-in Telemetry**: OpenTelemetry integration provides built-in telemetry support, offering insights into application performance and behavior.
- **Orchestration**: Orchestration in the language used to write other components of the program.
- **Simple Add**: If you need add .NET Aspire in your project its so easy.

## Example Dashboard .NET Aspire
 

## Current Status
While .NET Aspire shows promise, it is still in its early stages. Some key points to note:
- Limited toolset available currently
- Potential as a web service orchestrator, akin to Azure or AWS, but still in a raw state
- Encounters issues with startup and telemetry, typical of preview software

## Additional Notes
During the development process, several observations were made:
- It may not always start correctly.
- Telemetry issues are frequent.
- Future versions are expected to address these issues as it progresses from the preview stage.

## Example Configuration
```csharp
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin();

var productsDB = postgres.AddDatabase("ProductsDB");

builder.AddProject<Catalog_Api>("catalog-api")
    .WithReference(cache)
    .WithReference(productsDB);

builder.Build().Run();
```
This configuration sets up a distributed application using .NET Aspire, where the "catalog-api" project interacts with Redis for caching and Postgres for managing product data. The builder pattern facilitates the creation and configuration of the application components, offering a unified and straightforward approach to application orchestration.

### DistributedApplication

DistributedApplication - is main class in Aspire library. if you need impelment Aspire orchestration you need execute 
DistributedApplication.CreateBuilder() this static methos return IDistributedApplicationBuilder this interface is pattern builder.
```csharp
var builder = DistributedApplication.CreateBuilder(args);
```

Next step you add image or project.
```csharp
builder.AddRedis("cache");
```
And run this project.
```csharp
builder.Build().Run();
```

### IDistributedApplicationBuilder Add Methods

- AddProject() - A .NET project, for example ASP.NET Core web apps.
- AddContainer() - A container image, such as a Docker image.
- AddExecutable() - ExecutableResource an executable file.

### IDistributedApplicationBuilder Container Methods

- WithReplicas() - Add one or more replicas current image.
- WithReference() - Wait start another image . If you current image dependency another image.
- WithEnvironment() - Add environment in current docker image.
---

## Future Prospects
Despite its current limitations, .NET Aspire holds promise as a Docker-compose alternative for .NET projects. It offers easy integration for additional Docker containers in future releases.

---

## 🌟 Enjoyed my project?

- Please consider starring the repository.
- You can donate on [Patreon](https://www.patreon.com/a_sharifov).

## 📫 Contact

If you have any questions or suggestions, feel free to reach out to me.

This project is licensed under the [Apache 2.0 License](LICENSE).
