﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DMS.Services.Services;
using DMS.Services;
using DMS.Core.ServiceInterfaces;

namespace DMS.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices();
            services.AddAuthorization();
            services.AddMvc();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHostService, HostService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IActionService, ActionService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Verbose);
            
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "Cookie";
                options.LoginPath = new PathString("/Account/Login/");
                options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                options.LogoutPath = new PathString("/Account/Logout");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Dashboard}/{id?}");
            });
            
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
