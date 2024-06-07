using Application.Sub.GetSubQuery;
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
        _logger.LogInformation("Sum executed for numbers {num1}, {num2}.", num1, num2);
        return Ok(result);
    }

    [HttpGet("sub")]
    public async Task<IActionResult> GetSubAsync(decimal num1, decimal num2)
    {
        var query = new GetSubQuery(num1, num2);
        var result = await _sender.Send(query);
        _logger.LogInformation("Subtraction executed for numbers {num1}, {num2}", num1, num2);
        return Ok(result);
    }

    [HttpGet("mul")]
    public async Task<IActionResult> GetMulAsync(decimal num1, decimal num2)
    {
        throw new NotImplementedException();
    }
}
