namespace Staff;

public class Engineer : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Engineer() : base() => _position = "";

    public Engineer(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override bool Equals(object? obj)
    {
        bool result = false;

        if (obj is Engineer engineer)
        {
            result = (Name == engineer.Name)
                  && (Surname == engineer.Surname)
                  && (Age == engineer.Age)
                  && (_position == engineer.Position);
        }

        return result;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Surname, Age, _position);

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new();

        string[] positions = {"C# developer", "C++ developer", "Python developer", "HTML/CSS developer", "Data scientist"};
        _position = positions[random.Next(positions.Length)];
    }

    public override object Clone() => new Engineer(Name, Surname, Age, Position);

    public new string GetInfo() =>             $"{nameof(Engineer)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Engineer)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";
}