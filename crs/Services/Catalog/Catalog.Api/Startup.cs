using Catalog.Api.Extensions;
using Catalog.Infrastructure.DbContexts.Products;
using Catalog.Presentation.Endpoints.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api;

internal sealed class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ProductDbContext>(builder => builder.UseNpgsql("""
            Server=postgres;
            Port=5432;
            Database={POSTGRES_DB};
            Username={POSTGRES_USER};
            Password={POSTGRES_PASSWORD};
            TimeZone=UTC;
            """));

        services.AddStackExchangeRedisCache(setup => 
        setup.Configuration = _configuration.GetConnectionString("Redis"));

        // if you need swagger in minimal api
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDistributedMemoryCache();
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
