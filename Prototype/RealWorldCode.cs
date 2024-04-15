namespace Prototype.RealWorld;

// Documentation : https://www.dofactory.com/net/prototype-design-pattern
// Specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

public class RealWorldCode
{
    public static void Run()
    {
        ColorManager colorManager = new();

        // Initialize with standard colors
        colorManager["red"] = new Color(255, 0, 0);
        colorManager["green"] = new Color(0, 255, 0);
        colorManager["blue"] = new Color(0, 0, 255);

        // User adds personalized colors
        colorManager["angry"] = new Color(255, 54, 0);
        colorManager["peace"] = new Color(128, 211, 128);
        colorManager["flame"] = new Color(211, 34, 20);

        // User clones selected colors
        Color color1 = colorManager["red"].Clone() as Color;
        Color color2 = colorManager["peace"].Clone() as Color;
        Color color3 = colorManager["flame"].Clone() as Color;

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Prototype' abstract class
/// </summary>
public abstract class ColorPrototype
{
    public abstract ColorPrototype Clone();
}

/// <summary>
/// The 'ConcretePrototype' class
/// </summary>
public class Color : ColorPrototype
{
    int red;
    int green;
    int blue;

    // Constructor
    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    // Create a shallow copy
    public override ColorPrototype Clone()
    {
        Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", red, green, blue);
        return this.MemberwiseClone() as ColorPrototype;
    }
}

/// <summary>
/// Prototype manager
/// </summary>
public class ColorManager
{
    private Dictionary<string, ColorPrototype> colors = [];

    // Indexer
    public ColorPrototype this[string key]
    {
        get { return colors[key]; }
        set { colors.Add(key, value); }
    }
}
