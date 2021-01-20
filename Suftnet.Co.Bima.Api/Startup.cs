namespace Suftnet.Co.Bima.Api
{
    using AutoMapper;

    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Middleware.Security;
   
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
  
    using System;
    using Suftnet.Co.Bima.Api.Mappers;
    using Suftnet.Co.Bima.Common;
    using Microsoft.AspNetCore.Hosting;   
    using Microsoft.AspNetCore.Http;
    using Microsoft.Net.Http.Headers;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Cors();          
            services.JsonOptions();
            services.HttpContextAccessor();
            services.IdentityContext(Configuration);
            services.JwtContext(Configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireClaim(JwtClaimIdentifiers.USER_NAME));
                options.AddPolicy("restricted", policy => policy.RequireClaim(JwtClaimIdentifiers.USER_ID));
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "frontend/build";
            });

            return services.IoC();
        }
      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Cors();
            app.UseSecurityHeadersMiddleware(
                new SecurityHeadersBuilder()
                    .AddDefaultSecurePolicy());
            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(60)
                    };
                }
            }); 
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "frontend";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
