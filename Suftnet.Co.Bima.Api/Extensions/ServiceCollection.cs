﻿namespace Suftnet.Co.Bima.Api.Extensions
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using StructureMap;

    using Suftnet.Co.Bima.Api.Infrastructure;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Core;
    using Suftnet.Co.Bima.Core.Registry;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Models;
    using Suftnet.Co.Bima.DataAccess.Registry;

    using System;
    using System.Text;
    using System.Threading.Tasks;

    public static class ServicesConfiguration
    {
        public static IServiceProvider IoC(this IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ => { _.WithDefaultConventions(); });
                
                config.AddRegistry<CoreRegistry>();
                config.AddRegistry<DataRegistry>();
                config.AddRegistry<ServiceRegistry>();

                config.For<IJwtFactory>().Use<JwtFactory>().Singleton();
                              
                config.Populate(services);
            });

            return InitializeEngineContext(container.GetInstance<IServiceProvider>());
        }

        public static void JsonOptions(this IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });          
        }

        public static void Cors(this IServiceCollection services)
        {
            services.AddCors(options =>
                 options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));
        }
        public static void HttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
        public static void IdentityContext(this IServiceCollection services, IConfiguration configuration)
        {          
            services.AddDbContext<BimaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Suftnet.Co.Bima.DataAccess")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                 .AddEntityFrameworkStores<BimaContext>()
                 .AddDefaultTokenProviders();
        }
        public static void JwtContext(this IServiceCollection services, IConfiguration configuration)
        {
            var settingModel = configuration.GetSection(nameof(SettingModel));
            services.Configure<SettingModel>(settingModel);

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settingModel[nameof(SettingModel.SecretKey)]));
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;

                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }

                        context.NoResult();
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        context.Response.WriteAsync(context.Exception.Message).Wait();

                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }
                };
            });           

        }
        private static IServiceProvider InitializeEngineContext(IServiceProvider iServiceProvider)
        {
            var engine = EngineContext.Create();
            return engine.Initialize(iServiceProvider);
        }
    }
}