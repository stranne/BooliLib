using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Stranne.BooliLib.Examples.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Aquire caller id and key through app settings or environment, if present.
            var callerId = Configuration.GetValue<string>("BooliCallerId");
            var key = Configuration.GetValue<string>("BooliKey");

            if (string.IsNullOrWhiteSpace(callerId) || string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("BooliCallerId and BooliKey must be set in appsettings or environment.");
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Example API", Version = "v1"});
                c.DescribeAllEnumsAsStrings();
            });

            // Add IBooliService to .NET Core built in dependency injection service.
            // Configured as singleton so that the same instance will be reused on injection.
            services.AddSingleton<IBooliService>(provider => new BooliService(callerId, key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example API V1");
            });
        }
    }
}
