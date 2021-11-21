using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Threading.Tasks;

namespace API_GATEWAY
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            DateTime RequestTime = DateTime.Now;
            try
            {
                await _next(context);
            }
            finally
            {
                DateTime ResponseTime = DateTime.Now;
                var processTime = (decimal)(ResponseTime - RequestTime).TotalSeconds;
                LogEventInfo logEvent = new LogEventInfo();
                var logger = LogManager.GetCurrentClassLogger();
                logEvent.Properties["status"] = context.Response.StatusCode;
                logEvent.Properties["path"] = context.Request.Path;
                logEvent.Properties["time"] = RequestTime.ToString();
                logEvent.Properties["process"] = Decimal.Round(processTime, 3);
                logger.Trace(logEvent);
            }
        }
    }
}
