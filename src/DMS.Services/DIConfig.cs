using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    using DMS.Docker;
    using Data;
    using Core.ContainerInterfaces;
    
    public static class DIConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddEntityFramework().AddSqlite();
            services.AddEntityFramework().AddDbContext<DataContext>();
            
            services.AddTransient<Core.ContainerInterfaces.IContainer,Container>();
            services.AddTransient<Core.ContainerInterfaces.IContainerImage,Image>();  
        }

    }
}
