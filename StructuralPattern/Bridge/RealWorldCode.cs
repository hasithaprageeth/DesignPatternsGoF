namespace Bridge.RealWorld;

// Documentation : https://www.dofactory.com/net/bridge-design-pattern
// Decouples an abstraction from its implementation so that the two can vary independently.

public class RealWorldCode
{
    public static void Run()
    {
        // Create RefinedAbstraction
        var customers = new Customers();

        // Set ConcreteImplementor
        customers.Data = new CustomersData("Tokyo");

        // Exercise the bridge
        customers.Show();
        customers.Next();
        customers.Show();
        customers.Next();
        customers.Show();
        customers.Add("Henry");
        customers.ShowAll();

        // Wait for user input
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Abstraction' class
/// </summary>
public class CustomersBase
{
    private DataObject dataObject;

    public DataObject Data
    {
        set { dataObject = value; }
        get { return dataObject; }
    }

    public virtual void Next()
    {
        dataObject.NextRecord();
    }

    public virtual void Prior()
    {
        dataObject.PriorRecord();
    }

    public virtual void Add(string customer)
    {
        dataObject.AddRecord(customer);
    }

    public virtual void Delete(string customer)
    {
        dataObject.DeleteRecord(customer);
    }

    public virtual void Show()
    {
        dataObject.ShowRecord();
    }

    public virtual void ShowAll()
    {
        dataObject.ShowAllRecords();
    }
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class Customers : CustomersBase
{
    public override void ShowAll()
    {
        // Add separator lines
        Console.WriteLine();
        Console.WriteLine("------------------------");
        base.ShowAll();
        Console.WriteLine("------------------------");
    }
}

/// <summary>
/// The 'Implementor' abstract class
/// </summary>
public abstract class DataObject
{
    public abstract void NextRecord();
    public abstract void PriorRecord();
    public abstract void AddRecord(string name);
    public abstract void DeleteRecord(string name);
    public abstract string GetCurrentRecord();
    public abstract void ShowRecord();
    public abstract void ShowAllRecords();
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class CustomersData : DataObject
{
    private readonly List<string> customers = [];
    private int current = 0;
    private string city;

    public CustomersData(string city)
    {
        this.city = city;
        // Loaded from a database 
        customers.Add("Jim Jones");
        customers.Add("Samual Jackson");
        customers.Add("Allen Good");
        customers.Add("Ann Stills");
        customers.Add("Lisa Giolani");
    }

    public override void NextRecord()
    {
        if (current <= customers.Count - 1)
        {
            current++;
        }
    }

    public override void PriorRecord()
    {
        if (current > 0)
        {
            current--;
        }
    }

    public override void AddRecord(string customer)
    {
        customers.Add(customer);
    }

    public override void DeleteRecord(string customer)
    {
        customers.Remove(customer);
    }

    public override string GetCurrentRecord()
    {
        return customers[current];
    }

    public override void ShowRecord()
    {
        Console.WriteLine(customers[current]);
    }

    public override void ShowAllRecords()
    {
        Console.WriteLine("Customer City: " + city);
        foreach (string customer in customers)
        {
            Console.WriteLine(" " + customer);
        }
    }
}
