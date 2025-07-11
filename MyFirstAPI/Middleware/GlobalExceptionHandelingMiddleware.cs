using System.Net;
using System.Text.Json;
using MyFirstAPI.Models.Exceptions;
using MyFirstAPI.Models;

namespace MyFirstAPI.Middleware
{
    public class GEHmiddlewware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GEHmiddlewware> _logger;

        public GEHmiddlewware(RequestDelegate next, ILogger<GEHmiddlewware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occured.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application.json";
            var errorResponse = new ErrorResponse
            {
                Timestamp = DateTime.UtcNow,
                Instance = context.Request.Path,
            };

            switch (exception)
            {
                case NotFoundException notFound:
                    context.Response.StatusCode = 404;
                    errorResponseType = "Not Found";
                    errorResponse.Title = "Resource not found";
                    errorResponse.Detail = notFound.Message;
                    errorResponse.Status = 404;
                    break;

                case BadRequestException badRequest:
                    context.Response.StatusCode = 400;
                    errorResponse.Type = "Bad Request";
                    errorResponse.Title = "Invalid request";
                    errorResponse.Detail = badRequest.Message;
                    errorResponse.Status = 400;
                    break;

                default:
                    context.Response.StatusCode = 500;
                    errorResponse.Type = "Internal Server Error";
                    errorResponse.Title = "An unexpected error occurred";
                    errorResponse.Detail = "An unexpected error occurred. Please try again later.";
                    errorResponse.Status = 500;
                    break;
            }

            var JsonResponse = 
        }
    }
}