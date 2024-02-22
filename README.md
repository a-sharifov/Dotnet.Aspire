# [Dotnet.Aspire](https://github.com/a-sharifov/Dotnet.Aspire) [![GitHub license](https://img.shields.io/badge/license-Apache-blue.svg)](https://github.com/a-sharifov/Dotnet.Aspire/blob/master/LICENSE.txt)


This repository serves to demonstrate the current capabilities of .NET Aspire.
.NET Aspire is designed to improve the experience of building .NET cloud-native apps.

- Orchestration: .NET Aspire provides features for running and connecting multi-project applications and their dependencies.
- Components: .NET Aspire components are NuGet packages for commonly used services, such as Redis or Postgres, with standardized interfaces ensuring they connect consistently and seamlessly with your app.
- Tooling: .NET Aspire comes with project templates and tooling experiences for Visual Studio and the dotnet CLI help you create and interact with .NET Aspire apps.

## Purpose and Overview
This repository aims to showcase the functionalities and potentials of .NET Aspire as of the current moment. 

## Features
- **Cloud-native Architecture**: .NET Aspire boasts a cloud-native architecture, making it easy to deploy and manage in Azure environments.
- **Seamless Azure Deployment**: With .NET Aspire, deploying applications to Azure is a straightforward process, thanks to its integration with Azure services.
- **Intuitive Dashboard**: The platform offers an intuitive and visually appealing dashboard, simplifying monitoring and management tasks.
- **Built-in Telemetry**: OpenTelemetry integration provides built-in telemetry support, offering insights into application performance and behavior.
- **Orchestration**: Orchestration in the language used to write other components of the program

## Usage
To run the project, ensure you have the required version of .NET and Docker installed. The project can be launched like any other C# project.

### Current Requirements :

- net8.0 or up
- docker  25.0.2 or up 

## Current Status
While .NET Aspire shows promise, it is still in its early stages. Some key points to note:
- Limited toolset available currently
- Potential as a web service orchestrator, akin to Azure or AWS, but still in a raw state
- Encounters issues with startup and telemetry, typical of preview software

## Future Prospects
Despite its current limitations, .NET Aspire holds promise as a Docker-compose alternative for .NET projects. It offers easy integration for additional Docker containers in future releases.

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

builder.AddProject<Catalog_Api>("catalog")
    .WithReference(cache)
    .WithReference(productsDB);

builder.Build().Run();
```

---

## 🌟 Enjoyed my project?

- Please consider starring the repository.
- You can donate on [Patreon](https://www.patreon.com/a_sharifov).

## 📫 Contact

If you have any questions or suggestions, feel free to reach out to me.

This project is licensed under the [Apache 2.0 License](LICENSE).
