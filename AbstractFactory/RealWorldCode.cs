namespace AbstractFactory.RealWorld;

// Documentation : https://www.dofactory.com/net/abstract-factory-design-pattern

public class RealWorldCode
{
    public static void Run()
    {
        // Continent factory 1
        ContinentFactory factory1 = new AfricaFactory();
        AnimalWorld client1 = new(factory1);
        client1.RunFoodChain();

        // Continent factory 2
        ContinentFactory factory2 = new AmericaFactory();
        AnimalWorld client2 = new(factory2);
        client2.RunFoodChain();

        // Wait for user input
        Console.ReadKey();
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

/// <summary>
/// The 'Client' class 
/// </summary>
class AnimalWorld(ContinentFactory factory)
{
    private Herbivore _herbivore = factory.CreateHerbivore();
    private Carnivore _carnivore = factory.CreateCarnivore();

    public void RunFoodChain()
    {
        _carnivore.Eat(_herbivore);
    }
}
