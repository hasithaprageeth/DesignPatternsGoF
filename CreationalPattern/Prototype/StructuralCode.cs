namespace Prototype.Structural;

// Documentation : https://www.dofactory.com/net/prototype-design-pattern
// Specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

public class StructuralCode
{
    public static void Run()
    {
        // Create two instances and clone each
        ConcretePrototype1 p1 = new("1");
        ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
        Console.WriteLine("Cloned: {0}", c1.Id);

        ConcretePrototype2 p2 = new ConcretePrototype2("2");
        ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
        Console.WriteLine("Cloned: {0}", c2.Id);

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Prototype' abstract class
/// </summary>
public abstract class Prototype
{
    string id;

    // Constructor
    public Prototype(string id)
    {
        this.id = id;
    }

    // Gets id
    public string Id
    {
        get { return id; }
    }

    public abstract Prototype Clone();
}

/// <summary>
/// A 'ConcretePrototype' class 
/// </summary>
public class ConcretePrototype1 : Prototype
{
    // Constructor
    public ConcretePrototype1(string id) : base(id)
    {
    }

    // Returns a shallow copy
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}

/// <summary>
/// A 'ConcretePrototype' class 
/// </summary>
public class ConcretePrototype2 : Prototype
{
    // Constructor
    public ConcretePrototype2(string id) : base(id)
    {
    }

    // Returns a shallow copy
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}
