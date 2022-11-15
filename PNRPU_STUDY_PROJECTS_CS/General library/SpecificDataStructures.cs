using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.CompilerServices;

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
    static public int NumberCreatedInstancesClass { get { return _numberCreatedInstancesClass; } private set { _numberCreatedInstancesClass = value; } }

    public Money()
    {
        _rubles = 0;
        _kopeks = 0;
        _numberCreatedInstancesClass++;
        //Console.WriteLine("Вызван конструктор по умолчанию");
    }

    public Money(int kopeks)
    {
        if (kopeks <= 0)
        {
            _rubles = 0;
            _kopeks = 0;
            return;
        }

        _rubles = kopeks / 100;
        _kopeks = kopeks % 100;
        _numberCreatedInstancesClass++;
        //Console.WriteLine("Вызван конструктор с параметром");

    }

    public Money(int rubles, int kopeks)
    {
        if (rubles <= 0 || kopeks <= 0)
        {
            _rubles = 0;
            _kopeks = 0;
            return;
        }

        _rubles = rubles + kopeks / 100;
        _kopeks = kopeks % 100;
        _numberCreatedInstancesClass++;
        //Console.WriteLine("Вызван конструктор с параметрами");
    }

    public Money(Money that)
    {
        _rubles = that._rubles;
        _kopeks = that._kopeks;
        _numberCreatedInstancesClass++;
        //Console.WriteLine("Вызван копирующий конструктор");

    }

    static Money()
    {
        _numberCreatedInstancesClass = 0;
        //Console.WriteLine("Вызван статический конструктор");
    }

    public Money AddKopeks(int kopeks)
    {
        if (kopeks <= 0)
            kopeks = 0;

        _kopeks += kopeks;
        _rubles += _kopeks / 100;
        _kopeks %= 100;

        return this;
    }

    static public Money AddKopeks(Money money, int kopeks)
    {
        return money.AddKopeks(kopeks);
    }

    public static Money operator+(Money money, int kopeks)
    {
        if (kopeks < 0)
            return money - -kopeks;

        int result_kopeks = money._kopeks + kopeks;
        int result_rubles = money._rubles + result_kopeks / 100;
            result_kopeks %= 100;

        return new Money(result_rubles, result_kopeks);
    }

    public static Money operator-(Money money, int kopeks)
    {
        if (kopeks < 0)
            return money + -kopeks;

        int result_kopeks = money._rubles * 100 + money._kopeks;
        result_kopeks -= kopeks; 

        if (result_kopeks < 0)
            result_kopeks = 0;

        int result_rubles = result_kopeks / 100;
        result_kopeks %= 100;

        return new Money(result_rubles, result_kopeks);
    }

    public static Money operator++(Money money)
    {
        return money + 1;
        // https://t.me/DotNetRuChat/1389473
    }

    public static Money operator--(Money money)
    {
        return money - 1;
    }

    public static explicit operator int(Money money) => money._rubles;
    public static implicit operator double(Money money) => money._kopeks;
}

class MoneyArray
{
    private int _defaultSize = 10;

    private Money[] _data;
    private readonly int _size;
    static private int _numberCreatedInstancesClass;

    static public int NumberCreatedInstancesClass { get { return _numberCreatedInstancesClass; } private set { _numberCreatedInstancesClass = value; } }

    public MoneyArray()
    {
        _size = _defaultSize;
        _data = new Money[_size];

        for (var i = 0; i < _size; ++i)
        {
            _data[i] = new Money();
        }

        ++_numberCreatedInstancesClass;
    }

    public MoneyArray(int length)
    {
        _size = length;
        _data = new Money[_size];

        ArrayHandler.OneDimensional.Fill(_data);

        ++_numberCreatedInstancesClass;
    }

    public MoneyArray(Money[] money)
    {
        _size = money.Length;
        _data = new Money[_size];

        for (int i = 0; i < _size; i++)
        {
            _data[i] = new Money(money[i].Rubles, money[i].Kopeks);
        }
    }

    public int Length() => _data.Length;

    public void Print()
    {
        foreach (var money in _data)
        {
            Console.WriteLine($"{money.Rubles} рублей\t{money.Kopeks} копеек");
        }
    }

    public Money this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            return _data[index];
        }

        set
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            _data[index] = value;
        }
    }

    public Money GetMin()
    {
        if (_size == 0)
            return new Money();

        if (_size == 1)
            return _data[0];

        int min = int.MaxValue;
        int minIndex = 0;

        for (int i = 0; i < _size; ++i)
        {
            int current = _data[i].Rubles * 100 + _data[i].Kopeks;

            if (current < min)
            {
                min = current;
                minIndex = i;
            }
        }    

        return _data[minIndex];
    }
}