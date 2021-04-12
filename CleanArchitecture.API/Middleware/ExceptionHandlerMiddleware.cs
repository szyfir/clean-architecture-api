using CleanArchitecture.Core.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await GetException(context, ex);
            }
        }

        private Task GetException(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var exceptionMessage = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    exceptionMessage = notFoundException.Message;
                    break;
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    exceptionMessage = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            httpContext.Response.StatusCode = (int)httpStatusCode;

            if (string.IsNullOrEmpty(exceptionMessage))
            {
                exceptionMessage = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return httpContext.Response.WriteAsync(exceptionMessage);
        }
    }
}
