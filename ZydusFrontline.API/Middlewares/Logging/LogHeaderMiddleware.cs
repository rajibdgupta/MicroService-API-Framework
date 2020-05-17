using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZydusFrontline.API.Middlewares.Logging
{
    public class LogHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogHeaderMiddleware> _logger;

        public LogHeaderMiddleware(RequestDelegate next, ILogger<LogHeaderMiddleware> logger)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers["CorrelationId"];
            string sessionId;

            if (header.Count > 0)
            {
                using (_logger.BeginScope("{@CorrelationId}", header[0]))
                {
                    await this._next(context);
                }
                sessionId = header[0];
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                context.Items["CorrelationId"] = sessionId;
                using (_logger.BeginScope("{@CorrelationId}", sessionId))
                    await this._next(context);
            }
        }
    }
}
