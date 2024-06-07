using System.Text.Json.Nodes;

namespace ConsoleClient;

internal static class ConfigurationHelpers
{
    public static string GetUrlFromConfig()
    {
        var config = File.ReadAllText("client_config.json");
        var url = JsonNode.Parse(config)?["url"]?.GetValue<string>() 
            ?? throw new NullReferenceException("Can't parse configuration.");
        return url;
    }
}
