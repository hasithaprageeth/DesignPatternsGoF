namespace Builder.Optimized;

// Documentation : https://www.dofactory.com/net/builder-design-pattern
// Separates the construction of a complex object from its representation so that the same construction process can create different representations. 

public class OptimizedCode
{
    public static void Run()
    {
        // Create shop
        var shop = new Shop();

        // Construct and display vehicles
        shop.Construct(new ScooterBuilder());
        shop.ShowVehicle();

        shop.Construct(new CarBuilder());
        shop.ShowVehicle();

        shop.Construct(new MotorCycleBuilder());
        shop.ShowVehicle();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Director' class
/// </summary>
public class Shop
{
    private VehicleBuilder? builder;

    // Builder uses a complex series of steps
    public void Construct(VehicleBuilder vehicleBuilder)
    {
        builder = vehicleBuilder;
        builder.BuildFrame();
        builder.BuildEngine();
        builder.BuildWheels();
        builder.BuildDoors();
    }

    public void ShowVehicle()
    {
        builder?.Vehicle.Show();
    }
}

/// <summary>
/// The 'Builder' abstract class
/// </summary>
public abstract class VehicleBuilder(VehicleType vehicleType)
{
    public Vehicle Vehicle { get; private set; } = new Vehicle(vehicleType);
    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}

/// <summary>
/// The 'ConcreteBuilder1' class
/// </summary>
public class MotorCycleBuilder : VehicleBuilder
{
    // Invoke base class constructor
    public MotorCycleBuilder() : base(VehicleType.MotorCycle)
    {
    }

    public override void BuildFrame() => Vehicle[PartType.Frame] = "MotorCycle Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "500 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "2";
    public override void BuildDoors() => Vehicle[PartType.Door] = "0";
}

/// <summary>
/// The 'ConcreteBuilder2' class
/// </summary>
public class CarBuilder : VehicleBuilder
{
    // Invoke base class constructor
    public CarBuilder() : base(VehicleType.Car)
    {
    }

    public override void BuildFrame() => Vehicle[PartType.Frame] = "Car Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "2500 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "4";
    public override void BuildDoors() => Vehicle[PartType.Door] = "4";
}

/// <summary>
/// The 'ConcreteBuilder3' class
/// </summary>
public class ScooterBuilder : VehicleBuilder
{
    // Invoke base class constructor
    public ScooterBuilder() : base(VehicleType.Scooter)
    {
    }

    public override void BuildFrame() => Vehicle[PartType.Frame] = "Scooter Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "50 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "2";
    public override void BuildDoors() => Vehicle[PartType.Door] = "0";
}

/// <summary>
/// The 'Product' class
/// </summary>
public class Vehicle(VehicleType vehicleType)
{
    private readonly Dictionary<PartType, string> parts = [];
    private readonly VehicleType vehicleType = vehicleType;

    public string this[PartType key]
    {
        get => parts[key];
        set => parts[key] = value;
    }
    public void Show()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($" Vehicle Type: {vehicleType}");
        Console.WriteLine($" Frame  : {this[PartType.Frame]}");
        Console.WriteLine($" Engine : {this[PartType.Engine]}");
        Console.WriteLine($" #Wheels: {this[PartType.Wheel]}");
        Console.WriteLine($" #Doors : {this[PartType.Door]}");
    }
}

/// <summary>
/// Part type enumeration
/// </summary>
public enum PartType
{
    Frame,
    Engine,
    Wheel,
    Door
}

/// <summary>
/// Vehicle type enumeration
/// </summary>
public enum VehicleType
{
    Car,
    Scooter,
    MotorCycle
}