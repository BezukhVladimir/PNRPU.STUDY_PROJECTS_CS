using IRandom;
using Staff;

namespace Figure;

public class Rectangle : IRandomInit, IComparable
{
    public double Width  { get; private set; }
    public double Height { get; private set; }
    public double Area   { get; private set; }

    public Rectangle()
    {
        Width  = 0;
        Height = 0;
        Area   = 0;
    }

    public Rectangle(in double width, in double height)
    {
        Width  = width;
        Height = height;
        Area   = width * height;
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

    public string GetInfo() => $"{nameof(Rectangle)}: width = {Width}, height = {Height}.";
    public override string ToString() => $"Width: {string.Format("{0:0.00000}", Width), -11} Height: {string.Format("{0:0.00000}", Height), -15} Area: {string.Format("{0:0.00000}", Area)}";
}