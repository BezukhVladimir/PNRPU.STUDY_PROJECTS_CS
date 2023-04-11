namespace Staff;

[Serializable]
public class Employee : Person
{
    private string? _position;
    public string? Position { get => _position; private set => _position = value; }

    public Employee() : base() => _position = "";

    public Employee(string? name, string? surname, int age, string? position)
        : base(name, surname, age) => _position = position;

    public override bool Equals(object? obj)
    {
        bool result = false;

        if (obj is Employee employee)
        {
            result = (Name == employee.Name)
                  && (Surname == employee.Surname)
                  && (Age == employee.Age)
                  && (_position == employee.Position);
        }

        return result;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Surname, Age, _position);

    public override void RandomInit()
    {
        base.RandomInit();

        Random random = new();

        string[] positions = { "Manager", "Administrator", "Teamlead", "Director", "Support" };
        _position = positions[random.Next(positions.Length)];
    }

    public override object Clone() => new Employee(Name, Surname, Age, Position);

    public new string GetInfo() =>             $"{nameof(Employee)}: {Name}, {Surname}, {Age}, {Position}";
    public override string GetInfoVirtual() => $"{nameof(Employee)}: {Name}, {Surname}, {Age}, {Position}";
    public override string ToString() => $"{base.ToString()}\tPosition: {Position}";

    // lab 11
    public Person BasePerson
    {
        get
        {
            return new Person(Name, Surname, Age);
        }
    }
}