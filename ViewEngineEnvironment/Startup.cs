﻿using BibaViewEngine;
using BibaViewEngine.Router;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ViewEngineEnvironment.Client.Components;

namespace ViewEngineEnvironment
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var routes = new Routes
            {
                new BibaRoute { Path= "", Component = typeof(MainComponent) },
                new BibaRoute { Path= "list", Component = typeof(ListComponent) }
            };

            services.AddBibaViewEngine(routes: routes);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseBibaViewEngine();
        }
    }
}
