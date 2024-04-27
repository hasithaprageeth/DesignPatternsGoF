using Prototype.Optimized;
using Prototype.RealWorld;
using Prototype.Structural;

var app = string.Empty;
var validApps = new List<string> { "s", "r", "o" };

while (true)
{
    Console.Write("Enter the application [Structural (s), Real World (r), Optimized (o)] :");
    app = Console.ReadLine();

    app = app?.ToLower() ?? string.Empty;
    if (app == "q")
        return;
    else if (!validApps.Contains(app))
        Console.WriteLine("Invalid application selected.");
    else
        break;
}

switch (app)
{
    case "s":
        StructuralCode.Run();
        break;
    case "r":
        RealWorldCode.Run();
        break;
    case "o":
        OptimizedCode.Run();
        break;
}
