using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ZydusFrontline.API.Middlewares.ExceptionHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            String errorMessage = "Internal Server Error.";
            #region Commented
            // var exceptionType = ex.GetType();
            //if (exceptionType == typeof(UnauthorizedAccessException))
            // {
            //     code = HttpStatusCode.Unauthorized;
            //     errorMessage = "Unauthorized Access";
            // }                 
            // else if (exceptionType == typeof(NotImplementedException))
            // {
            //     code = HttpStatusCode.NotImplemented;
            //     errorMessage = "A server error occurred.";               
            // }           
            // else
            // {
            //     code = HttpStatusCode.InternalServerError;
            //     errorMessage = ex.Message;               
            // }
            #endregion
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            this._logger.LogError(ex, result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(errorMessage);
        }
    }
}
