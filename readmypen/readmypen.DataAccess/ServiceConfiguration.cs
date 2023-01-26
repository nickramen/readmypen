using readmypen.BusinessLogic;
using readmypen.DataAccess;
using readmypen.DataAccess.Entities;
using readmypen.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace readmypen.DataAccess
{
    public static class ServiceConfiguration
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<RolesRepository>();


            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped<IUrlHelper>(x => x
                .GetRequiredService<IUrlHelperFactory>()
                .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

            readmypenDbContext.BuildConnectionString(connectionString);
        }
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            //services.AddScoped<>();

        }
    }
    

}


