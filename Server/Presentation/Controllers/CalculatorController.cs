using Application.Sum.GetSumQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController, Route("calculator/api")]
public class CalculatorController(ISender sender, ILogger<CalculatorController> logger) : ControllerBase
{
    private readonly ISender _sender = sender;
    private readonly ILogger<CalculatorController> _logger = logger;

    [HttpGet("sum")]
    public async Task<IActionResult> GetSumAsync(decimal num1, decimal num2)
    {
        var query = new GetSumQuery(num1, num2);
        var result = await _sender.Send(query);
        _logger.LogDebug("Sum executed for numbers {num1}, {num2}.", num1, num2);
        return Ok(result);
    }
}
