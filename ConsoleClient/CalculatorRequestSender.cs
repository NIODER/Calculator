using System.Text.Json;

namespace ConsoleClient;

internal class CalculatorRequestSender(string requestUrl)
{
    private readonly string _requestUrl = requestUrl;

    public async Task<decimal> GetSum(decimal num1, decimal num2, CancellationToken? cancellationToken = null)
    {
        string content = await GetResponseString("sum", num1, num2, cancellationToken);
        return CalculatorRequestSenderHelpers.GetCalculationResultOrThrow(content);
    }

    public async Task<decimal> GetSubtract(decimal diminutive, decimal deductible, CancellationToken? cancellationToken = null)
    {
        string content = await GetResponseString("sub", diminutive, deductible, cancellationToken);
        return CalculatorRequestSenderHelpers.GetCalculationResultOrThrow(content);
    }

    public async Task<decimal> GetMultiply(decimal num1, decimal num2, CancellationToken? cancellationToken = null)
    {
        string content = await GetResponseString("mul", num1, num2, cancellationToken);
        return CalculatorRequestSenderHelpers.GetCalculationResultOrThrow(content);
    }

    public async Task<decimal> GetDivision(decimal divisible, decimal divider, CancellationToken? cancellationToken = null)
    {
        string content = await GetResponseString("div", divisible, divider, cancellationToken);
        return CalculatorRequestSenderHelpers.GetCalculationResultOrThrow(content);
    }

    private Task<string> GetResponseString(string operation, decimal num1, decimal num2, CancellationToken? cancellationToken)
    {
        return cancellationToken is null
            ? GetResponseString(operation, num1, num2)
            : GetResponseString(operation, num1, num2, cancellationToken.Value);
    }

    private async Task<string> GetResponseString(string operation, decimal num1, decimal num2)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"{_requestUrl}/{operation}?num1={num1}&num2={num2}");
        string content = await response.Content.ReadAsStringAsync();
        CalculatorRequestSenderHelpers.ThrowIfCodeIsNotSuccess(response, content);
        return content;
    }

    private async Task<string> GetResponseString(string operation, decimal num1, decimal num2, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"{_requestUrl}/{operation}?num1={num1}&num2={num2}", cancellationToken);
        string content = await response.Content.ReadAsStringAsync(cancellationToken);
        CalculatorRequestSenderHelpers.ThrowIfCodeIsNotSuccess(response, content);
        return content;
    }
}
