using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    using Data;
    using Docker.Implementations;
    using Docker.Interfaces;
    public static class DIConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddEntityFramework().AddSqlite();
            services.AddEntityFramework().AddDbContext<DataContext>();

            services.AddTransient<IHost, Host>();
            services.AddTransient<IImage, Image>();
            services.AddTransient<IContainer, Container>();    
        }
    }
}
