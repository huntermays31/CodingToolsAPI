using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Services;

namespace CodingTools
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            HostingEnvironment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment HostingEnvironment { get; set; }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opts =>
            {
                var origins = Configuration["AllowedOrigin"].Split(",").Select(x => x.Trim()).ToArray();

                opts.AddPolicy("AllowAll",
                    p => p
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(origins));
            });

            services.AddSignalR();
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddAuthentication(IISDefaults.AuthenticationScheme); // Comment out if not running on IIS
            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //    .AddNegotiate(); // Uncomment if not running on IIS

            services.AddSingleton(ctx => Configuration);

            services.AddOptions();

            services.AddCodingTools(typeof(Startup).Assembly, Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiniProfiler();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Coding Tools API");
            });


            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
