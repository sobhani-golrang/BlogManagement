using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BlogManagement.Endpoints.API.Filters
{
    public class ResultFilter : IResultFilter
    {
        private readonly ILogger<ResultFilter> _logger;
        public ResultFilter(ILogger<ResultFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var result = "";
            if (context.Result is ObjectResult)
                result = JsonSerializer.Serialize((context.Result as ObjectResult).Value, new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
                    WriteIndented = true
                });
            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.ffff} Request Finished Executing: {result}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}