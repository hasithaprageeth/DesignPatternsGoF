namespace Composite.Structural;

// Documentation : https://www.dofactory.com/net/composite-design-pattern
// Composes objects into tree structures to represent part-whole hierarchies. This pattern lets clients treat individual objects and compositions of objects uniformly..

public class StructuralCode
{
    public static void Run()
    {
        // Create a tree structure
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite composite = new Composite("Composite X");
        composite.Add(new Leaf("Leaf XA"));
        composite.Add(new Leaf("Leaf XB"));
        root.Add(composite);
        root.Add(new Leaf("Leaf C"));

        // Add and remove a leaf
        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        // Recursively display tree
        root.Display(1);

        // Wait for user
        Console.ReadKey();

    }
}

/// <summary>
/// The 'Component' abstract class
/// </summary>
public abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

/// <summary>
/// The 'Composite' class
/// </summary>
public class Composite : Component
{
    List<Component> children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        children.Add(component);
    }

    public override void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);

        // Recursively display child nodes
        foreach (Component component in children)
        {
            component.Display(depth + 2);
        }
    }
}

/// <summary>
/// The 'Leaf' class
/// </summary>
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        Console.WriteLine("Cannot add to a leaf");
    }
    public override void Remove(Component component)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);
    }
}
