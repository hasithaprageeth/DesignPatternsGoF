namespace Adapter.Structural;

// Documentation : https://www.dofactory.com/net/adapter-design-pattern
// Converts the interface of a class into another interface that clients expect. This design pattern lets classes work together that couldn‘t otherwise because of incompatible interfaces.

public class StructuralCode
{
    public static void Run()
    {
        // Create adapter and place a request
        Target target = new Adapter();
        target.Request();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Target' class
/// </summary>
public class Target
{
    public virtual void Request()
    {
        Console.WriteLine("Called Target Request()");
    }
}

/// <summary>
/// The 'Adapter' class
/// </summary>
public class Adapter : Target
{
    private Adaptee adaptee = new();

    public override void Request()
    {
        // Possibly do some other work
        // and then call SpecificRequest
        adaptee.SpecificRequest();
    }
}

/// <summary>
/// The 'Adaptee' class
/// </summary>
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest()");
    }
}
