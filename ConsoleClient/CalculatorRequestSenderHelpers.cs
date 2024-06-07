using ConsoleClient;
using System.Text.Json;

namespace ConsoleClient;

internal static class CalculatorRequestSenderHelpers
{
    public static decimal GetCalculationResultOrThrow(string content)
    {
        return JsonSerializer.Deserialize<CalculationResult>(content)?.Result
            ?? throw new FormatException("Can't parse result.");
    }

    public static void ThrowIfCodeIsNotSuccess(HttpResponseMessage response, string content)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error occured while trying to get sum.\n" +
                $"Status code: {response.StatusCode}.\n" +
                $"Message: {content}.");
        }
    }
}