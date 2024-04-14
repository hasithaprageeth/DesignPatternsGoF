namespace Singleton.Optimized;

// Documentation : https://www.dofactory.com/net/singleton-design-pattern
// Ensures a class has only one instance and provide a global point of access to it.

public class OptimizedCode
{
    public static void Run()
    {
        var b1 = LoadBalancer.GetLoadBalancer();
        var b2 = LoadBalancer.GetLoadBalancer();
        var b3 = LoadBalancer.GetLoadBalancer();
        var b4 = LoadBalancer.GetLoadBalancer();

        // Confirm these are the same instance
        if (b1 == b2 && b2 == b3 && b3 == b4)
        {
            Console.WriteLine("Same instance\n");
        }

        var balancer = LoadBalancer.GetLoadBalancer();
        // Load balance 15 requests for a server
        for (int i = 0; i < 15; i++)
        {
            var server = balancer.NextServer.Name;
            Console.WriteLine("Dispatch request to: " + server);
        }

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Singleton' class
/// </summary>
public sealed class LoadBalancer
{
    // Static members are 'eagerly initialized', that is, 
    // immediately when class is loaded for the first time.
    // .NET guarantees thread safety for static initialization
    private static readonly LoadBalancer instance = new();
    private readonly List<Server> servers;
    private readonly Random random = new();

    // Note: constructor is 'private'
    private LoadBalancer()
    {
        // Load list of available servers
        servers = [
            new(Name: "Server1", Ip: "120.14.220.18"),
            new(Name: "Server2", Ip: "120.14.220.19"),
            new(Name: "Server3", Ip: "120.14.220.20"),
            new(Name: "Server4", Ip: "120.14.220.21"),
            new(Name: "Server5", Ip: "120.14.220.22")
        ];
    }

    public static LoadBalancer GetLoadBalancer()
    {
        return instance;
    }

    // Simple, but effective load balancer
    public Server NextServer
    {
        get => servers[random.Next(servers.Count)];
    }
}

/// <summary>
/// Represents a server machine
/// </summary>
public record Server(string Name, string Ip);