namespace FactoryMethod.Structural;

// Documentation : https://www.dofactory.com/net/factory-method-design-pattern
// Defines an interface for creating an object, but let subclasses decide which class to instantiate. This pattern lets a class defer instantiation to subclasses.
// Creator class defines an interface for creating an object, but let ConcreteCreatorA, ConcreteCreatorB subclasses decide which class to instantiate.

public class StructuralCode
{
    public static void Run()
    {
        // An array of creators
        Creator[] creators = [new ConcreteCreatorA(), new ConcreteCreatorB()];

        // Iterate over creators and create products
        foreach (Creator creator in creators)
        {
            Product product = creator.CreateProduct();
            Console.WriteLine("Created {0}", product.GetType().Name);
        }

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Product' abstract class
/// </summary>
abstract class Product
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class ConcreteProductA : Product
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class ConcreteProductB : Product
{
}

/// <summary>
/// The 'Creator' abstract class
/// </summary>
abstract class Creator
{
    public abstract Product CreateProduct();
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
class ConcreteCreatorA : Creator
{
    public override Product CreateProduct()
    {
        return new ConcreteProductA();
    }
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
class ConcreteCreatorB : Creator
{
    public override Product CreateProduct()
    {
        return new ConcreteProductB();
    }
}
