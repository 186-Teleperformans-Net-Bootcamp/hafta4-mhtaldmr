﻿using Microsoft.EntityFrameworkCore;
using MuhammetAliDemir.TP.Net.Hw4.Application.Interfaces;
using MuhammetAliDemir.TP.Net.Hw4.Infrastructure.Context;

namespace MuhammetAliDemir.TP.Net.Hw4.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfractructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Adding the dbcontext for entityframework
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ISocialNetworkDbContext, SocialNetworkDbContext>();

            return services;
        }
    }
}
