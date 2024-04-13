namespace AbstractFactory.Structural;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern

public class StructuralCode
{
    public static void Run()
    {
        // Abstract factory 1
        AbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new(factory1);
        client1.Run();

        // Abstract factory 2
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new(factory2);
        client2.Run();

        // Wait for user input
        Console.ReadKey();
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

/// <summary>
/// The 'Client' class. Interaction environment for the products.
/// </summary>
class Client(AbstractFactory factory)
{
    private AbstractProductA _abstractProductA = factory.CreateProductA();
    private AbstractProductB _abstractProductB = factory.CreateProductB();

    public void Run()
    {
        _abstractProductB.Interact(_abstractProductA);
    }
}
