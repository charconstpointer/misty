using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Misty.Middleware
{
    public class ExceptionMiddleware
    {
        public class ExceptionHandling
        {
            private readonly RequestDelegate _next;

            public ExceptionHandling(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)
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

            private static Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.StatusCode = exception switch
                {
                    ApplicationException _ => (int) HttpStatusCode.BadRequest,
                    _ => 500
                };

                context.Response.ContentType = "application/json";

                var response = new {exception.Message};
                var json = JsonConvert.SerializeObject(response);
                return context.Response.WriteAsync(json);
            }
        }
    }
}