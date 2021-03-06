using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProvaMG.Application;
using ProvaMG.Domain;
using ProvaMG.Domain.Repositories;
using ProvaMG.Infrasctructure;
using ProvaMG.Infrasctructure.Data;

namespace ProvaMG.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Explicitly register the settings object by delegating to the IOptions object
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ProvaMGContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            services.AddScoped<IAutenticacaoAppService, AutenticacaoAppService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "ProvaMG API v1",
                        Version = "v1",
                        Contact = new OpenApiContact()
                        {
                            Name = "Leandro Ribeiro",
                            Email = string.Empty,
                            Url = new Uri("https://github.com/leandroribeiro")
                        }
                    });
            
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();                

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProvaMG API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}