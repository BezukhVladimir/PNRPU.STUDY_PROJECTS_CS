using System.Xml.Linq;

namespace Staff;

public class Worker : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Worker() : base() => _position = "";

    public Worker(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override bool Equals(object? obj)
    {
        bool result = false;

        if (obj is Worker worker)
        {
            result = (Name == worker.Name)
                  && (Surname == worker.Surname)
                  && (Age == worker.Age)
                  && (_position == worker.Position);
        }

        return result;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Surname, Age, _position);

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new();

        string[] positions = { "Electrician", "Plumber", "Janitor", "Warehouseman", "Courier" };
        _position = positions[random.Next(positions.Length)];
    }

    public override object Clone() => new Worker(Name, Surname, Age, Position);

    public new string GetInfo() =>             $"{nameof(Worker)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Worker)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";
}