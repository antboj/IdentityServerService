using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.IdentityServer4;
using Castle.Facilities.Logging;
using IdentityServer4.Services;
using IdentityServerService.Client;
using IdentityServerService.Resource;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TestProject.Authorization.Users;
using TestProject.EntityFrameworkCore;
using TestProject.Identity;

namespace IdentityServerService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            IdentityRegistrar.Register(services);
            
            services.AddMvc();

            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources()) //iz koda, ne u bazu
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddDeveloperSigningCredential()
                .AddAbpPersistedGrants<TestProjectDbContext>()
                .AddAbpIdentityServer<User>();
                //.AddProfileService<MyProfileService>();
                //.AddProfileService<MyProfileService>();

            return services.AddAbp<IdentityServerServiceModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseAbp();

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();

            app.Run(async context =>
            {
                //await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}