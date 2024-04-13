namespace AbstractFactory.Optimized;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern

public class OptimizedCode
{
    public static void Run()
    {
        // Create and run the African animal world
        var africaFactory = new AnimalWorld<AfricaFactory>();
        africaFactory.RunFoodChain();

        // Create and run the American animal world
        var americaFactory = new AnimalWorld<AmericaFactory>();
        americaFactory.RunFoodChain();

        // Wait for user input
        Console.ReadKey();
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

/// <summary>
/// The 'Client' interface
/// </summary>
public interface IAnimalWorld
{
    void RunFoodChain();
}

/// <summary>
/// The 'Client' class 
/// </summary>
public class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
{
    private readonly IHerbivore herbivore;
    private readonly ICarnivore carnivore;

    public AnimalWorld()
    {
        // Create new continent factory
        var factory = new T();

        // Factory creates carnivores and herbivores
        carnivore = factory.CreateCarnivore();
        herbivore = factory.CreateHerbivore();
    }

    /// <summary>
    /// Runs the foodchain: carnivores are eating herbivores.
    /// </summary>
    public void RunFoodChain()
    {
        carnivore.Eat(herbivore);
    }
}
