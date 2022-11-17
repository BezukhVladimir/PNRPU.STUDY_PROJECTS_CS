namespace Staff;

public class Engineer : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Engineer() => RandomInit();

    public Engineer(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new Random();

        string[] positions = {"C# developer", "C++ developer", "Python developer", "HTML/CSS developer", "Data scientist"};
        _position = positions[random.Next(positions.Length)];
    }

    public new string GetInfo() =>             $"{nameof(Engineer)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Engineer)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";
}