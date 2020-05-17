using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZydusFrontline.API.Middlewares.Caching
{
    public class CachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _distributedcache;
        private readonly ILogger<CachingMiddleware> _logger;
        public CachingMiddleware(RequestDelegate next, IDistributedCache distributedcache, ILogger<CachingMiddleware> logger)
        {
            this._next = next;
            _distributedcache = distributedcache;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!isRequestCachable(context.Request))
            {
                await _next(context);
            }
            else
            {
                var cacheKey = string.Empty;
                var cacheKeyToLower = string.Empty;
                var req = context.Request;
                req.EnableBuffering();

                using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    var request = await reader.ReadToEndAsync();
                    cacheKey = $"{req.Scheme}{req.Host}{req.Path}{req.QueryString}{request}";
                    cacheKeyToLower = cacheKey.ToLower();
                    req.Body.Position = 0;
                }

                var cachedResponse = await _distributedcache.GetAsync(cacheKeyToLower);
                if (cachedResponse != null)
                {
                    var serializedResponse = Encoding.UTF8.GetString(cachedResponse);
                    this._logger.LogInformation(serializedResponse);
                    await context.Response.WriteAsync(serializedResponse, Encoding.UTF8);
                   
                    return;
                }
                else
                {
                    var originalBodyStream = context.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        context.Response.Body = responseBody;
                        await _next(context);
                        var response = await FormatResponse(context.Response);                       
                        await responseBody.CopyToAsync(originalBodyStream);

                        if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            var cacheobj = CacheUrlRegister.GetCacheUrlList().Where(item => item.URL.ToLower() == context.Request.Path.ToString().ToLower()).FirstOrDefault();
                            var options = new DistributedCacheEntryOptions()
                           .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheobj.AbsoluteExpirationTimeSpanInseconds))
                           .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheobj.SlidingExpirationTimeSpanInseconds));

                            this._logger.LogInformation(response);
                            await _distributedcache.SetAsync(cacheKeyToLower, Encoding.UTF8.GetBytes(response), options);
                        }
                        
                    }
                }
            }
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"{text}";
        }

        private Boolean isRequestCachable(HttpRequest request)
        {
            return request.Method == "GET" && CacheUrlRegister.GetCacheUrlList().Any(item => item.URL.ToLower() == request.Path.Value.ToString().ToLower());
        }


    }
}
