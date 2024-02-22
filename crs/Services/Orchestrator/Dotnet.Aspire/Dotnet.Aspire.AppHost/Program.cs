using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var database = builder.AddPostgresContainer(
    name: "database",
    password: builder.Configuration["Passwords:PostgresSql"]
    );

builder.AddProject<Catalog_Api>("catalog")
    .WithReference(cache)
    .WithReference(database)
    .WithEnvironment("Passwords:PostgresSql", 
    builder.Configuration["Passwords:PostgresSql"]);

builder.Build().Run();
