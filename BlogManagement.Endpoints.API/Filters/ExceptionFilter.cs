using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BlogManagement.Endpoints.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.ffff} {context.Exception}");
            context.Result = new ObjectResult(new { Message = "در انجام عملیات مشکلی پیش آمده است", RequestId = context.HttpContext.TraceIdentifier });
        }
    }
}