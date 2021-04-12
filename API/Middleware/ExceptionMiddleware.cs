using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger Logger;
        private readonly IHostEnvironment Env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, 
        IHostEnvironment env)
        {
            Env = env;
            Logger = logger;
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
               await Next(context);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode= (int) HttpStatusCode.InternalServerError;

                var Response = Env.IsDevelopment()
                ? new ApiExceptions(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                : new ApiExceptions(context.Response.StatusCode,"Internal Server Error");

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(Response, options);
                await context.Response.WriteAsync(json);
            }
        }

    }
}