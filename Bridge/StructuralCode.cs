namespace Bridge.Structural;

// Documentation : https://www.dofactory.com/net/bridge-design-pattern
// Decouples an abstraction from its implementation so that the two can vary independently.

public class StructuralCode
{
    public static void Run()
    {
        Abstraction ab = new RefinedAbstraction();

        // Set implementation and call
        ab.Implementor = new ConcreteImplementorA();
        ab.Operation()
            ;
        // Change implemention and call
        ab.Implementor = new ConcreteImplementorB();
        ab.Operation();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Abstraction' class
/// </summary>
public class Abstraction
{
    protected Implementor implementor;

    public Implementor Implementor
    {
        set { implementor = value; }
    }
    public virtual void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class RefinedAbstraction : Abstraction
{
    public override void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'Implementor' abstract class
/// </summary>
public abstract class Implementor
{
    public abstract void Operation();
}

/// <summary>
/// The 'ConcreteImplementorA' class
/// </summary>
public class ConcreteImplementorA : Implementor
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteImplementorA Operation");
    }
}

/// <summary>
/// The 'ConcreteImplementorB' class
/// </summary>
public class ConcreteImplementorB : Implementor
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteImplementorB Operation");
    }
}
