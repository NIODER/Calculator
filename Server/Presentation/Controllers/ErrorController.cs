using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers;

public class ErrorController(ILogger<ErrorController> logger) : ControllerBase
{
    private readonly ILogger<ErrorController> _logger = logger;

    [ApiExplorerSettings(IgnoreApi = true), Route("error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        _logger.LogError(exception, "Error occured.");
        return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: exception?.Message);
    }
}
