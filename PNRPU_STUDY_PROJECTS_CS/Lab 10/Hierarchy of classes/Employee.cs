namespace Staff;

public class Employee : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Employee() => RandomInit();

    public Employee(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new Random();

        string[] positions = { "Manager", "Administrator", "Teamlead", "Director", "Support" };
        _position = positions[random.Next(positions.Length)];
    }

    public new string GetInfo() =>             $"{nameof(Employee)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Employee)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";
}