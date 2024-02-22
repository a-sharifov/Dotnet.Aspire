﻿using Microsoft.EntityFrameworkCore;
using Polly;

namespace Catalog.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void MigrateDbContext<TDbContext>(this IApplicationBuilder app)
        where TDbContext : DbContext 
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        dbContext.Database.Migrate();
    }
}
