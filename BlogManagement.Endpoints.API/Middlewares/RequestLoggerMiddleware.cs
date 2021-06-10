using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace BlogManagement.Endpoints.API.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var requestScope = new Dictionary<string, string>();
            requestScope["ScopeId"] = Guid.NewGuid().ToString("N");
            using var scope = _logger.BeginScope(requestScope);

            _logger.LogInformation("{0:yyyy-MM-dd hh:mm:ss.ffff} Request Starting from \"{1}\" for \"{2}\"",
                DateTime.Now, httpContext.Connection.RemoteIpAddress, UriHelper.GetDisplayUrl(httpContext.Request));
            await _next.Invoke(httpContext);
        }
    }
}