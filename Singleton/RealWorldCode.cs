namespace Singleton.RealWorld;

// Documentation : https://www.dofactory.com/net/singleton-design-pattern
// Ensures a class has only one instance and provide a global point of access to it.

public class RealWorldCode
{
    public static void Run()
    {
        LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

        // Same instance?
        if (b1 == b2 && b2 == b3 && b3 == b4)
        {
            Console.WriteLine("Same instance\n");
        }

        // Load balance 15 server requests
        LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
        for (int i = 0; i < 15; i++)
        {
            string server = balancer.Server;
            Console.WriteLine("Dispatch Request to: " + server);
        }

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Singleton' class
/// </summary>
public class LoadBalancer
{
    static LoadBalancer? instance;
    List<string> servers = [];
    Random random = new();

    // Lock synchronization object
    private static object locker = new();

    // Constructor (protected)
    protected LoadBalancer()
    {
        // List of available servers
        servers.Add("Server1");
        servers.Add("Server2");
        servers.Add("Server3");
        servers.Add("Server4");
        servers.Add("Server5");
    }

    public static LoadBalancer GetLoadBalancer()
    {
        // Support multi-threaded applications through 'Double checked locking' pattern
        // which (once the instance exists) avoids locking each time the method is invoked
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new LoadBalancer();
                }
            }
        }
        return instance;
    }

    // Simple, but effective random load balancer
    public string Server
    {
        get
        {
            int r = random.Next(servers.Count);
            return servers[r].ToString();
        }
    }
}
