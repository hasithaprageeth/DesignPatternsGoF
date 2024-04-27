namespace AbstractFactory.Optimized;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern
// Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
// ContinentFactory class provides the interface, typically involves multiple factory methods, each responsible for creating a different type of object or a set of related objects.

public class OptimizedCode
{
    public static void Run()
    {
        AnimalWorld.RunFoodChain();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Client' class
/// </summary>
public class AnimalWorld
{
    /// <summary>
    /// Runs the foodchain: carnivores are eating herbivores.
    /// </summary>
    public static void RunFoodChain()
    {
        // Africa Factory
        IContinentFactory africaFactory = new AfricaFactory();
        IHerbivore herbivore = africaFactory.CreateHerbivore();
        ICarnivore carnivore = africaFactory.CreateCarnivore();
        carnivore.Eat(herbivore);

        // America Factory
        IContinentFactory americaFactory = new AmericaFactory();
        herbivore = americaFactory.CreateHerbivore();
        carnivore = americaFactory.CreateCarnivore();
        carnivore.Eat(herbivore);
    }
}

/// <summary>
/// The 'AbstractFactory' interface - IContinentFactory
/// </summary>
public interface IContinentFactory
{
    IHerbivore CreateHerbivore();
    ICarnivore CreateCarnivore();
}

/// <summary>
/// The 'ConcreteFactory1' class. - AfricaFactory
/// </summary>
public class AfricaFactory : IContinentFactory
{
    public IHerbivore CreateHerbivore() => new Wildebeest();
    public ICarnivore CreateCarnivore() => new Lion();
}

/// <summary>
/// The 'ConcreteFactory2' class. - AmericaFactory
/// </summary>
public class AmericaFactory : IContinentFactory
{
    public IHerbivore CreateHerbivore() => new Bison();
    public ICarnivore CreateCarnivore() => new Wolf();
}

/// <summary>
/// The 'AbstractProductA' interface - IHerbivore
/// </summary>
public interface IHerbivore
{
}

/// <summary>
/// The 'AbstractProductB' interface - ICarnivore
/// </summary>
public interface ICarnivore
{
    void Eat(IHerbivore h);
}

/// <summary>
/// The 'ProductA1' class - Wildebeest
/// </summary>
public class Wildebeest : IHerbivore
{
}

/// <summary>
/// The 'ProductB1' class - Lion
/// </summary>
public class Lion : ICarnivore
{
    // Eat Wildebeest
    public void Eat(IHerbivore h) =>
        Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
}

/// <summary>
/// The 'ProductA2' class - Bison
/// </summary>
public class Bison : IHerbivore
{
}

/// <summary>
/// The 'ProductB2' class - Wolf
/// </summary>
public class Wolf : ICarnivore
{
    // Eat Bison
    public void Eat(IHerbivore h) =>
        Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
}
