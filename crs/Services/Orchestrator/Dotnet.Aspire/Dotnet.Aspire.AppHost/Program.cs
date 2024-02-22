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
