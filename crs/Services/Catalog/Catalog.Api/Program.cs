using Catalog.Api.Extensions;
using Catalog.Infrastructure.DbContexts.Products;
using Catalog.Presentation.Endpoints.Products;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.AddNpgsqlDbContext<ProductDbContext>("ProductsDB");

var services = builder.Services;

services.AddStackExchangeRedisCache(setup =>
      setup.Configuration = builder.Configuration.GetConnectionString("cache"));

services.Scan(selector =>
       selector.FromAssemblies(
           Catalog.Infrastructure.AssemblyReference.Assembly)
       //Add classes in entry point is required method in scrutor.
       .AddClasses()
       .UsingRegistrationStrategy(RegistrationStrategy.Skip)
       .AsImplementedInterfaces()
       .WithScopedLifetime());

services.AddMediatR(configuration =>
configuration.RegisterServicesFromAssembly(
    Catalog.UseCases.ProjectReference.Assembly));

// if you need swagger in minimal api
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDbContext<ProductDbContext>();

app.MapDefaultEndpoints();
app.MapProductsEndpoints();

app.Run();