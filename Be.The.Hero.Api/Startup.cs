using Be.The.Hero.Api.Config;
using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Repositories;
using Be.The.Hero.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Be.The.Hero.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddCors(services);
            AddSwagger(services);
            AddMVC(services);
            AddOptions(services);
            AddContextSQLite(services);
            AddDependencyInjection(services);           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Be The Hero - API");
            });            

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

        }
        private void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Be The Hero - API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });
        }
        private void AddMVC(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
        private void AddOptions(IServiceCollection services)
        {
            services.AddOptions();
        }
        private void AddContextSQLite(IServiceCollection services)
        {
            var connection = Configuration["SqliteConnectionString"];
            services.AddDbContext<BeTheHeroSQLiteContext>(options =>
                options.UseSqlite(connection)
            );
        }
        private void AddDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IOngService, OngService>();
            services.AddScoped<IOngRepository, OngRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
        }
    }
}
