using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Paymentsense.Coding.Challenge.Api.Middleware;
using Paymentsense.Coding.Challenge.Api.ServiceClients;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Net.Http;

namespace Paymentsense.Coding.Challenge.Api
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
            services.AddResponseCaching();

            // client
            services.AddScoped<IRestCountriesClient, RestCountriesClient>();

            // services
            services.AddScoped<IRestCountriesService, RestCountriesService>();

            services.AddControllers();
            services.AddHealthChecks();
            services.AddCors(options =>
            {
                options.AddPolicy("PaymentsenseCodingChallengeOriginPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddSwaggerGen();

            services.AddTransient<HttpClient>();
            //services.AddHttpClient();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("PaymentsenseCodingChallengeOriginPolicy");

            //app.UseResponseCaching();
            /*
            app.Use(async (context, next) =>
            {
                if (context.Request.Method.Equals(HttpMethod.Get))
                {
                    context.Response.GetTypedHeaders().CacheControl =
                    new CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                    context.Response.Headers[HeaderNames.Vary] =
                        new string[] { "Accept-Encoding" };
                }

                await next();
            });
            */
            app.UseMiddleware<CacheMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
