using ConsoleClient;

string url = ConfigurationHelpers.GetUrlFromConfig();

var sender = new CalculatorRequestSender(url);

Console.WriteLine("Press CTRL+Z to stop request and exit.");
Console.WriteLine("Command structure:");
Console.WriteLine("{operation} {num1} {num2}");
Console.WriteLine("Supported operations: sum, sub, mul, div.");

while (true)
{
    string line = Console.ReadLine()!;
    var command = line.Split(' ');
    if (command is null)
    {
        continue;
    }
    if (command.Length < 3)
    {
        Console.WriteLine("Unsupported operation.");
        continue;
    }
    else if (command.Length > 3)
    {
        Console.WriteLine($"Parameters: { command[3..]
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Aggregate((s1, s2) => $"{s1} {s2}")} will be ignored.");
    }
    if (!decimal.TryParse(command[1], out decimal num1))
    {
        Console.WriteLine("Invalid input for num1.");
        continue;
    }
    if (!decimal.TryParse(command[2], out decimal num2))
    {
        Console.WriteLine("Invalid input for num2.");
        continue;
    }
    switch (command[0])
    {
        case "sum":
            Console.WriteLine(await sender.GetSum(num1, num2));
            break;
        case "sub":
            Console.WriteLine(await sender.GetSubtract(num1, num2));
            break;
        case "mul":
            Console.WriteLine(await sender.GetMultiply(num1, num2));
            break;
        case "div":
            Console.WriteLine(await sender.GetDivision(num1, num2));
            break;
        default:
            Console.WriteLine("Unsupported operation.");
            break;
    }
}
