using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace SerenaApi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureErrorHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler((IApplicationBuilder appError) =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            //...
                            _ => StatusCodes.Status500InternalServerError
                        };
                            
                        logger.LogError($"we've got exception: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetail()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
