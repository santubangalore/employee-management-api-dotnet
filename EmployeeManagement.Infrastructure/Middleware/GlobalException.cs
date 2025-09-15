using EmployeeManagement.Infrastructure.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace EmployeeManagement.Infrastructure.Middleware
{

    public class GlobalException(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            //declare default variables
            string message = "Sorry, internal server error happened";
            int statuscode = (int)HttpStatusCode.InternalServerError;
            string title = "Error";
            try
            {
                await next(context);
                if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    title = "Warning";
                    message = "Too many requests made";
                    statuscode = (int)StatusCodes.Status429TooManyRequests;
                    await ModifyHeader(context, title, message, statuscode);
                }
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    title = "Unauthorized";
                    message = "You are not authorized to access";
                    statuscode = (int)StatusCodes.Status401Unauthorized;
                    await ModifyHeader(context, title, message, statuscode);
                }
                //if response is forbidden
                if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
                {
                    title = "Out of Access";
                    message = "You are not allowed to access";
                    statuscode = (int)StatusCodes.Status403Forbidden;
                    await ModifyHeader(context, title, message, statuscode);
                }
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                //check if timeout exception 
                if (exception is TaskCanceledException || exception is TimeoutException)
                {
                    message = "Request timeout... try again";
                    title = "Timeout";
                    statuscode = (int)StatusCodes.Status408RequestTimeout;
                }
                // If none of the above, do the defaults
                await ModifyHeader(context, title, message, statuscode);
            }
        }

        private static async Task ModifyHeader(HttpContext context, string title, string message, int statuscode)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails()
            {
                Title = title,
                Detail = message,
                Status = statuscode
            }
            ), CancellationToken.None);
            return;
        }
    }
}
