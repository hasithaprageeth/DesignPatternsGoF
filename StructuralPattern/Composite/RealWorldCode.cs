namespace Composite.RealWorld;

// Documentation : https://www.dofactory.com/net/composite-design-pattern
// Composes objects into tree structures to represent part-whole hierarchies. This pattern lets clients treat individual objects and compositions of objects uniformly.

public class RealWorldCode
{
    public static void Run()
    {
        // Create a tree structure
        CompositeElement root = new CompositeElement("Picture");
        root.Add(new PrimitiveElement("Red Line"));
        root.Add(new PrimitiveElement("Blue Circle"));
        root.Add(new PrimitiveElement("Green Box"));

        // Create a branch
        CompositeElement comp = new CompositeElement("Two Circles");
        comp.Add(new PrimitiveElement("Black Circle"));
        comp.Add(new PrimitiveElement("White Circle"));
        root.Add(comp);

        // Add and remove a PrimitiveElement
        PrimitiveElement pe = new PrimitiveElement("Yellow Line");
        root.Add(pe);
        root.Remove(pe);

        // Recursively display nodes
        root.Display(1);

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Component' Treenode
/// </summary>
public abstract class DrawingElement
{
    protected string name;

    public DrawingElement(string name)
    {
        this.name = name;
    }

    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
}

/// <summary>
/// The 'Leaf' class
/// </summary>
public class PrimitiveElement : DrawingElement
{
    public PrimitiveElement(string name) : base(name)
    {
    }

    public override void Add(DrawingElement c)
    {
        Console.WriteLine("Cannot add to a PrimitiveElement");
    }

    public override void Remove(DrawingElement c)
    {
        Console.WriteLine("Cannot remove from a PrimitiveElement");
    }

    public override void Display(int indent)
    {
        Console.WriteLine(new String('-', indent) + " " + name);
    }
}

/// <summary>
/// The 'Composite' class
/// </summary>
public class CompositeElement : DrawingElement
{
    List<DrawingElement> elements = new List<DrawingElement>();

    public CompositeElement(string name) : base(name)
    {
    }

    public override void Add(DrawingElement d)
    {
        elements.Add(d);
    }

    public override void Remove(DrawingElement d)
    {
        elements.Remove(d);
    }

    public override void Display(int indent)
    {
        Console.WriteLine(new String('-', indent) + "+ " + name);

        // Display each child element on this node
        foreach (DrawingElement d in elements)
        {
            d.Display(indent + 2);
        }
    }
}
