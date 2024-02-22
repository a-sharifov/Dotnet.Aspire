using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var database = builder.AddPostgres("pg")
    .AddDatabase("ProductsDb");

builder.AddProject<Catalog_Api>("catalog")
    .WithReference(cache)
    .WithReference(database);

builder.Build().Run();
