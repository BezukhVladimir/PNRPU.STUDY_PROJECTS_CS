using System.Drawing;

namespace SpecificDataStructures;

public class Property
{
    private Action check;
    private bool status;
    public bool isChecked;

    public bool Status
    {
        get
        {
            if (!isChecked)
                Update();

            return status;
        }
        set { status = value; }
    }

    public Property(Action checkingMethod)
    {
        status = false;
        isChecked = false;
        check = checkingMethod;
    }

    private void Update()
    {
        check();
        isChecked = true;
    }
};

public class Money
{
    private int _rubles;
    private int _kopeks;
    static private int _numberCreatedInstancesClass;

    public int Rubles { get { return _rubles; } private set { _rubles = value; } }
    public int Kopeks { get { return _kopeks; } private set { _kopeks = value; } }
    static public int NumberCreatedInstancesClass { get { return _numberCreatedInstancesClass; } private set { _numberCreatedInstancesClass = value; }}

    public Money()
    {
        _rubles = 0;
        _kopeks = 0;
        _numberCreatedInstancesClass++;
        Console.WriteLine("Вызван конструктор по умолчанию");
    }

    public Money(int rubles, int kopeks)
    {
        _rubles = rubles;
        _kopeks = kopeks;
        _numberCreatedInstancesClass++;
        Console.WriteLine("Вызван конструктор с параметрами");
    }

    public Money(Money that)
    {
        _rubles = that._rubles;
        _kopeks = that._kopeks;
        _numberCreatedInstancesClass++;
        Console.WriteLine("Вызван копирующий конструктор");

    }

    static Money()
    {
        _numberCreatedInstancesClass = 0;
        Console.WriteLine("Вызван статический конструктор");
    }

    public Money AddKopeks(int kopeks)
    {
        _kopeks += kopeks;
        _rubles += _kopeks / 100;
        _kopeks %= 100;

        return this;
    }

    static public Money AddKopeks(Money money, int kopeks)
    {
        return money.AddKopeks(kopeks);
    }

    public static Money operator++(Money money)
    {
        // todo: https://t.me/DotNetRuChat/1389473
    }

    public static Money operator--(Money money)
    {
    }
}