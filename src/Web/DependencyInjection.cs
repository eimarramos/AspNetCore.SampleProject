﻿using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();

        // Customise default API behaviour
        builder.Services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "Pokemon API";
        });
    }
}
