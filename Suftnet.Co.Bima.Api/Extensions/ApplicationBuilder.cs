namespace Suftnet.Co.Bima.Api.Extensions
{
    using Suftnet.Co.Bima.Api.Middleware.Security;
    using Suftnet.Co.Bima.Api.Middleware.Exception;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
     using Microsoft.AspNetCore.Builder;
    using System;
   
    public static class Configures
    {
        public static void Cors(this IApplicationBuilder app)
        {
            app.UseCors(
                options => options.AllowAnyOrigin()
            );                       
        }

        public static void Spa(this IApplicationBuilder app)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "frontend";
                spa.UseReactDevelopmentServer(npmScript: "start");
                //spa.UseProxyToSpaDevelopmentServer("http://localhost:62137");

            });
        }

        public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return app.UseMiddleware<SecurityHeadersMiddleware>(builder.Build());
        }

        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}
