namespace AbstractFactory.Structural;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern
// Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
// AbstractFactory class provides the interface, typically involves multiple factory methods, each responsible for creating a different type of object or a set of related objects.

public class StructuralCode
{
    public static void Run()
    {
        Client.Run();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Client' class. Interaction environment for the products.
/// Enjoys the flexibility of seamlessly switching between families of objects by changing the concrete factory instance.
/// </summary>
class Client()
{
    public static void Run()
    {
        AbstractFactory factory1 = new ConcreteFactory1();
        AbstractProductA abstractProductA = factory1.CreateProductA();
        AbstractProductB abstractProductB = factory1.CreateProductB();
        abstractProductB.Interact(abstractProductA);

        AbstractFactory factory2 = new ConcreteFactory2();
        abstractProductA = factory2.CreateProductA();
        abstractProductB = factory2.CreateProductB();
        abstractProductB.Interact(abstractProductA);
    }
}

/// <summary>
/// The 'AbstractFactory' abstract class
/// </summary>
abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}

/// <summary>
/// The 'ConcreteFactory1' class
/// </summary>
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

/// <summary>
/// The 'ConcreteFactory2' class
/// </summary>
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

/// <summary>
/// The 'AbstractProductA' abstract class
/// </summary>
abstract class AbstractProductA
{
}

/// <summary>
/// The 'AbstractProductB' abstract class
/// </summary>
abstract class AbstractProductB
{
    public abstract void Interact(AbstractProductA a);
}

/// <summary>
/// The 'ProductA1' class
/// </summary>
class ProductA1 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB1' class
/// </summary>
class ProductB1 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " interacts with " + a.GetType().Name);
    }
}

/// <summary>
/// The 'ProductA2' class
/// </summary>
class ProductA2 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB2' class
/// </summary>
class ProductB2 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " interacts with " + a.GetType().Name);
    }
}
