namespace Builder.Structural;

// Documentation : https://www.dofactory.com/net/builder-design-pattern
// Separates the construction of a complex object from its representation so that the same construction process can create different representations. 

public class StructuralCode
{
    public static void Run()
    {
        // Create director and builders
        Director director = new();
        Builder b1 = new ConcreteBuilder1();
        Builder b2 = new ConcreteBuilder2();

        // Construct two products
        director.Construct(b1);
        Product p1 = b1.GetResult();
        p1.Show();

        director.Construct(b2);
        Product p2 = b2.GetResult();
        p2.Show();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Director' class
/// </summary>
class Director
{
    // Builder uses a complex series of steps
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}

/// <summary>
/// The 'Builder' abstract class
/// </summary>
abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
}

/// <summary>
/// The 'ConcreteBuilder1' class
/// </summary>
class ConcreteBuilder1 : Builder
{
    private readonly Product _product = new();

    public override void BuildPartA()
    {
        _product.Add("PartA");
    }

    public override void BuildPartB()
    {
        _product.Add("PartB");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// The 'ConcreteBuilder2' class
/// </summary>
class ConcreteBuilder2 : Builder
{
    private readonly Product _product = new();

    public override void BuildPartA()
    {
        _product.Add("PartX");
    }

    public override void BuildPartB()
    {
        _product.Add("PartY");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// The 'Product' class
/// </summary>
class Product
{
    private readonly List<string> _parts = [];

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("\nProduct Parts -------");
        foreach (string part in _parts)
            Console.WriteLine(part);
    }
}
