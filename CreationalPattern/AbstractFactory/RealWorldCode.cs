namespace AbstractFactory.RealWorld;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern
// Provides an interface for creating families of related or dependent objects without specifying their concrete classes.
// ContinentFactory class provides the interface, typically involves multiple factory methods, each responsible for creating a different type of object or a set of related objects.

public class RealWorldCode
{
    public static void Run()
    {
        AnimalWorld.RunFoodChain();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Client' class - AnimalWorld
/// </summary>
class AnimalWorld()
{
    public static void RunFoodChain()
    {
        // Continent factory 1
        ContinentFactory africaFactory = new AfricaFactory();
        Herbivore herbivore = africaFactory.CreateHerbivore();
        Carnivore carnivore = africaFactory.CreateCarnivore();
        carnivore.Eat(herbivore);

        // Continent factory 2
        ContinentFactory americaFactory = new AmericaFactory();
        herbivore = americaFactory.CreateHerbivore();
        carnivore = americaFactory.CreateCarnivore();
        carnivore.Eat(herbivore);
    }
}

/// <summary>
/// The 'ContinentFactory' abstract class
/// </summary>
abstract class ContinentFactory
{
    public abstract Herbivore CreateHerbivore();
    public abstract Carnivore CreateCarnivore();
}

/// <summary>
/// The 'AfricaFactory' class
/// </summary>
class AfricaFactory : ContinentFactory
{
    public override Herbivore CreateHerbivore()
    {
        return new Wildebeest();
    }
    public override Carnivore CreateCarnivore()
    {
        return new Lion();
    }
}

/// <summary>
/// The 'AmericaFactory' class
/// </summary>
class AmericaFactory : ContinentFactory
{
    public override Herbivore CreateHerbivore()
    {
        return new Bison();
    }
    public override Carnivore CreateCarnivore()
    {
        return new Wolf();
    }
}

/// <summary>
/// The 'Herbivore' abstract class
/// </summary>
abstract class Herbivore
{
}

/// <summary>
/// The 'Carnivore' abstract class
/// </summary>
abstract class Carnivore
{
    public abstract void Eat(Herbivore h);
}

/// <summary>
/// The 'ProductA1' class - Wildebeest
/// </summary>
class Wildebeest : Herbivore
{
}

/// <summary>
/// The 'ProductB1' class - Lion
/// </summary>
class Lion : Carnivore
{
    public override void Eat(Herbivore h)
    {
        // Eat Wildebeest
        Console.WriteLine(this.GetType().Name +
          " eats " + h.GetType().Name);
    }
}

/// <summary>
/// The 'ProductA2' class - Bison
/// </summary>
class Bison : Herbivore
{
}

/// <summary>
/// The 'ProductB2' class - Wolf
/// </summary>
class Wolf : Carnivore
{
    public override void Eat(Herbivore h)
    {
        // Eat Bison
        Console.WriteLine(this.GetType().Name +
          " eats " + h.GetType().Name);
    }
}
