using GodPay_CMS.Controllers.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Helpers
{
    public static class CustomErrorHandlerHelper
    {
        public static void UseCustomErrors(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (environment.IsProduction())
                app.Use(WriteProductionResponse);
            else
                app.Use(WriteDevelopmentResponse);
        }

        private static Task WriteDevelopmentResponse(HttpContext httpContext, Func<Task> next)
            => WriteResponse(httpContext, includeDetails: true);

        private static Task WriteProductionResponse(HttpContext httpContext, Func<Task> next)
            => WriteResponse(httpContext, includeDetails: false);

        private static async Task WriteResponse(HttpContext httpContext, bool includeDetails)
        {
            // Try and retrieve the error from the ExceptionHandler middleware
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;

            // Should always exist, but best to be safe!
            if (ex != null)
            {
                // ProblemDetails has it's own content type
                httpContext.Response.ContentType = "application/problem+json";

                // Get the details to display, depending on whether we want to expose the raw exception
                var title = includeDetails ? "An error occured: " + ex.Message : "An error occured";
                var details = includeDetails ? ex.ToString() : null;

                var problem = new ResponseViewModel
                {
                    RtnCode = Enums.ReturnCodeEnum.InternalProgramError,
                    RtnMessage = title,
                    RtnData = details
                };

                //Serialize the problem details object to the Response as JSON (using System.Text.Json)
                var stream = httpContext.Response.Body;
                await JsonSerializer.SerializeAsync(stream, problem,
                options: new System.Text.Json.JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

            }
        }
    }
}
