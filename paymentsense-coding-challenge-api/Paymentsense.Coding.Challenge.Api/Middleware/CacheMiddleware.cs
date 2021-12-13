using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Middleware
{
    public class CacheMiddleware
    {
        private readonly RequestDelegate _next;

        public CacheMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalResponse = context.Response.Body;
            var newResponse = new MemoryStream();

            try
            {
                if (context.Request.Method == "GET")
                {
                    context.Response.GetTypedHeaders().CacheControl =
                    new CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                    context.Response.Headers[HeaderNames.Vary] =
                        new string[] { "Accept-Encoding" };
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                context.Response.Body = originalResponse;
                newResponse.Position = 0;
            }

            await newResponse.CopyToAsync(originalResponse, context.RequestAborted);

        }
    }
}
