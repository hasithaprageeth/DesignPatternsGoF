namespace FactoryMethod.RealWorld;

// Documentation : https://www.dofactory.com/net/factory-method-design-pattern
// Defines an interface for creating an object, but let subclasses decide which class to instantiate. This pattern lets a class defer instantiation to subclasses.
// Creator class defines an interface for creating an object, but let ConcreteCreatorA, ConcreteCreatorB subclasses decide which class to instantiate.

public class RealWorldCode
{
    public static void Run()
    {
        Document[] documents = [new Resume(), new Report()];

        // Display document pages
        foreach (Document document in documents)
        {
            Console.WriteLine("\n" + document.GetType().Name + "--");
            foreach (Page page in document.Pages)
            {
                Console.WriteLine(" " + page.GetType().Name);
            }
        }
        // Wait for user
        Console.ReadKey();
    }
}

/// <summary>
/// The 'Product' abstract class
/// </summary>
abstract class Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class SkillsPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class EducationPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class ExperiencePage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class IntroductionPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class ResultsPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class ConclusionPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class SummaryPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class BibliographyPage : Page
{
}

/// <summary>
/// The 'Creator' abstract class
/// </summary>
abstract class Document
{
    private List<Page> _pages = [];

    // Constructor calls abstract Factory method
    public Document()
    {
        CreatePages();
    }
    public List<Page> Pages
    {
        get { return _pages; }
    }
    // Factory Method
    public abstract void CreatePages();
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
class Resume : Document
{
    // Factory Method implementation
    public override void CreatePages()
    {
        Pages.Add(new SkillsPage());
        Pages.Add(new EducationPage());
        Pages.Add(new ExperiencePage());
    }
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
class Report : Document
{
    // Factory Method implementation
    public override void CreatePages()
    {
        Pages.Add(new IntroductionPage());
        Pages.Add(new ResultsPage());
        Pages.Add(new ConclusionPage());
        Pages.Add(new SummaryPage());
        Pages.Add(new BibliographyPage());
    }
}
