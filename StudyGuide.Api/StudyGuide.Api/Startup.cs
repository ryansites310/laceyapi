using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudyGuide.Api
{
    using System.Diagnostics.Contracts;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Swashbuckle.AspNetCore.Swagger;

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
            RegisterMappings();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSingleton<IResponseFactory>(ctx => new ResponseFactory());

            services
                .AddDbContext<studyguideContext>(opt => opt.UseSqlServer(@"Server=tcp:datamine.database.windows.net,1433;Initial Catalog=studyguide;Persist Security Info=False;User ID=rsites;Password=Mythr33boy$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                .AddUnitOfWork<studyguideContext>();

            // Add swagger generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "StudyGuide API", Version = "1.0" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder =>
                builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseMvc();

            // Use swagger and swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //if (env.IsProduction() || env.IsEnvironment("stage"))
                //{
                //    c.SupportedSubmitMethods(new string[] { });
                //}

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contract Audit API v1");
            });
        }

        private void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Test, TestViewModel>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .ReverseMap();

                cfg.CreateMap<Card, CardViewModel>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .ReverseMap();
              
            });
            try
            {
                Mapper.AssertConfigurationIsValid();
            }
            catch (Exception e)
            {
                throw new Exception("Automapping failed", e);
            }
        }
    }
}
