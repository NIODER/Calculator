using System.Text.Json.Serialization;

namespace ConsoleClient;

internal class CalculationResult
{
    [JsonPropertyName("operation")]
    public string Operation { get; set; } = null!;
    [JsonPropertyName("number1")]
    public decimal Number1 { get; set; }
    [JsonPropertyName("number2")]
    public decimal Number2 { get; set; }
    [JsonPropertyName("result")]
    public decimal Result { get; set; }
};
