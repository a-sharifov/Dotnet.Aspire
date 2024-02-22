using Catalog.Api.Extensions;
using Catalog.Infrastructure.DbContexts.Products;
using Catalog.Presentation.Endpoints.Products;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace Catalog.Api;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(_configuration.GetConnectionString("ProductsDb"));
        }

        services.AddNpgsql<ProductDbContext>("ProductsDb");

        services.AddStackExchangeRedisCache(setup =>
        setup.Configuration = _configuration.GetConnectionString("cache"));

        services.Scan(selector => 
        selector.FromAssemblies(Infrastructure.AssemblyReference.Assembly)
        //Add classes in entry point is required method in scrutor.
        .AddClasses()
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        services.AddMediatR(configuration =>
        configuration.RegisterServicesFromAssembly(
            UseCases.ProjectReference.Assembly));

        // if you need swagger in minimal api
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MigrateDbContext<ProductDbContext>();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultEndpoints();
            endpoints.MapProductsEndpoints();
            // if you have controllers 
            //endpoints.MapControllers();
        });  
    }
}
