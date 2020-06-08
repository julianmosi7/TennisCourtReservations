using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TennisCourtReservations.Controllers;
using TennisCourtReservations.Services;
using TennisCourtReservationsDb;

namespace TennisCourtReservations
{
    public class Startup
    {
        private readonly string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private const string swaggerVersion = "v1";
        private const string swaggerTitle = "WebApiBestPractice";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<PersonService>();
            services.AddScoped<BookingService>();
            services.AddScoped<TennisContext>();
            services.AddCors(options =>
            {
                options.AddPolicy(myAllowSpecificOrigins, x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });            
            string dataDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string connectionString = Configuration.GetConnectionString("TennisMdf");
            if (connectionString.Contains("|DataDirectory|"))
                connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);
            Console.WriteLine($"Using database {connectionString}");
            services.AddDbContext<TennisContext>(options => options.UseSqlServer(connectionString, o => o.EnableRetryOnFailure())
            );
            
            services.AddControllers();
           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerVersion, new OpenApiInfo
                {
                    Title = swaggerTitle,
                    Version = swaggerVersion
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        await context.Response.WriteAsync(
                            $"Exception: {error.Error.Message} {error.Error?.InnerException.Message}");
                    }
                });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Console.WriteLine("UseSwagger");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", swaggerTitle);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
