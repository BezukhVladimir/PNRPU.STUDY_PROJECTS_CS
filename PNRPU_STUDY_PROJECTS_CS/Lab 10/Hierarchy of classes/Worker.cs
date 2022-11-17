namespace Staff;

public class Worker : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Worker() => RandomInit();

    public Worker(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new Random();

        string[] positions = { "Electrician", "Plumber", "Janitor", "Warehouseman", "Courier" };
        _position = positions[random.Next(positions.Length)];
    }

    public new string GetInfo() =>             $"{nameof(Worker)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Worker)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";
}