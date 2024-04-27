using System.Text.Json;

namespace Prototype.Optimized;

// Documentation : https://www.dofactory.com/net/prototype-design-pattern
// Specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

public class OptimizedCode
{
    public static void Run()
    {
        var colorManager = new ColorManager();

        // Initialize with standard colors
        colorManager[ColorType.Red] = new Color { Red = 255, Blue = 0, Green = 0 };
        colorManager[ColorType.Green] = new Color { Red = 0, Blue = 255, Green = 0 };
        colorManager[ColorType.Blue] = new Color { Red = 0, Blue = 0, Green = 255 };

        // User adds personalized colors
        colorManager[ColorType.Angry] = new Color { Red = 255, Blue = 54, Green = 0 };
        colorManager[ColorType.Peace] = new Color { Red = 128, Blue = 211, Green = 128 };
        colorManager[ColorType.Flame] = new Color { Red = 211, Blue = 34, Green = 20 };

        // User uses selected colors
        _ = colorManager[ColorType.Red].Clone();
        _ = colorManager[ColorType.Peace].Clone();
        _ = colorManager[ColorType.Flame].Clone(false); // Deep Copy

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// ICloneable is not supported in .NET Core
/// </summary>
public interface ICloneableObject
{
    object Clone();
}

/// <summary>
/// The 'ConcretePrototype' class
/// </summary>
public class Color : ICloneableObject
{
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    // Returns a shallow or a deep copy
    public object? Clone(bool shallow)
    {
        return shallow ? Clone() : DeepCopy();
    }

    // Creates a shallow copy
    public object Clone()
    {
        Console.WriteLine("Shallow copy of color RGB: {0,3},{1,3},{2,3}", Red, Green, Blue);
        return MemberwiseClone();
    }

    // Creates a deep copy
    public object? DeepCopy()
    {
        // use serialized to create a deep copy
        var serialized = JsonSerializer.Serialize(this);
        var copy = JsonSerializer.Deserialize<Color>(serialized);

        if (copy is not null)
        {
            Console.WriteLine("*Deep* copy of color RGB: {0,3},{1,3},{2,3}",
                (copy as Color).Red, (copy as Color).Green, (copy as Color).Blue);
        }
        return copy;
    }
}

/// <summary>
/// Type-safe prototype manager
/// </summary>
public record ColorManager
{
    private readonly Dictionary<ColorType, Color> colors = [];

    // Gets or sets color
    public Color this[ColorType type]
    {
        get => colors[type];
        set => colors.Add(type, value);
    }
}

/// <summary>
/// Color type enumerations
/// </summary>
public enum ColorType
{
    Red,
    Green,
    Blue,
    Angry,
    Peace,
    Flame
}