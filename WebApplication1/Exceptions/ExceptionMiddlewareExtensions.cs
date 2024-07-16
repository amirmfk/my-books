using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using WebApplication1.Data.ViewModels;

namespace WebApplication1.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureBuidInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                var contextRequest = context.Features.Get<IHttpRequestFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorVM()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Path = context.Request.Path
                    }.ToString());
                }
            });

        });
           
        }

        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
