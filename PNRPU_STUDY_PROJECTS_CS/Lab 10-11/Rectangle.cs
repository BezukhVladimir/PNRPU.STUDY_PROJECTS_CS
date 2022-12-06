using IRandom;
using Staff;
using System.Xml.Linq;

namespace Figure;

public class Rectangle : IRandomInit, IComparable
{
    public Person test;

    public double Width  { get; private set; }
    public double Height { get; private set; }
    public double Area   { get; private set; }

    public Rectangle()
    {
        Width  = 0;
        Height = 0;
        Area   = 0;
        test   = new ("testname", "testsurname", 0);
    }

    public Rectangle(in double width, in double height, Person newTest)
    {
        Width  = width;
        Height = height;
        Area   = width * height;
        test = newTest;
    }

    public void RandomInit()
    {
        Random random = new Random();

        Width  = random.NextDouble() * 100.0;
        Height = random.NextDouble() * 100.0;
        Area   = Width * Height;
    }

    public int CompareTo(object? obj)
    {
        if (obj is Rectangle rectangle)
            return Area.CompareTo(rectangle.Area);
        else if (obj is Person person)
            return -1;

        throw new ArgumentException($"{nameof(obj)} is not a {nameof(Rectangle)}");
    }

    public object ShallowCopy() => MemberwiseClone();
    public virtual object Clone() => new Rectangle(Width, Height, test);

    public string GetInfo() => $"{nameof(Rectangle)}: width = {Width}, height = {Height}.";
    public string GetTest() => $"Test: {test}";
    public override string ToString() => $"Width: {string.Format("{0:0.00000}", Width), -11} Height: {string.Format("{0:0.00000}", Height), -15} Area: {string.Format("{0:0.00000}", Area)}";
}