using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace api;

public class GlobalExeptionHendler: IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = "An error occurred while processing your request.",
            Status = 500,
            Detail = exception.Message
        };
        
        httpContext.Response.WriteAsJsonAsync(problemDetails);
        return true;
    }
}