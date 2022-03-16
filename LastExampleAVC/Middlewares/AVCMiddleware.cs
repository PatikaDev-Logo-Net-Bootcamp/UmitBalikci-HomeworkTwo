using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace LastExampleAVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AVCMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AVCMiddleware(RequestDelegate next, IConfiguration iConfig)
        {
            _next = next;
            _configuration = iConfig;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var appVersion = _configuration.GetSection("MyOwnSettings").GetSection("app-version").Value;
                var fromInputVersion = httpContext.Request.Headers["app-version"];

                if (appVersion.CompareTo(fromInputVersion) < 0)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
                
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            await httpContext.Response.WriteAsync($"Unauthorized! Detail: {exception.Message}");
        }
    }
}
