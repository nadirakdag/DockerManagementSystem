using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    using Docker;
    using Data;
    using Core.ContainerInterfaces;
    
    public static class DIConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddEntityFramework().AddSqlite();
            services.AddEntityFramework().AddDbContext<DataContext>();
            
            services.AddTransient<IContainer,Container>();
            services.AddTransient<IContainerImage,Image>();  
        }
    }
}
