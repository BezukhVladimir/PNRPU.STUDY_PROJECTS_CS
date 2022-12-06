namespace Staff;

using Figure;
using IRandom;

public class Person : IRandomInit, IComparable, ICloneable
{
    private string? _name;
    private string? _surname;
    private int _age;
    
    public string? Name    { get => _name;    private set => _name = value; }
    public string? Surname { get => _surname; private set => _surname = value; }
    public int Age
    {
        get => _age;
        private set => _age = (value > 0) ? value : 0;
    }

    public Person()
    {
        _name    = "";
        _surname = "";
        _age = 0;
    }

    public Person(string? name, string? surname, int age)
    {
        _name    = name;
        _surname = surname;
        _age     = age;
    }

    public override bool Equals(object? obj)
    {
        bool result = false;

        if (obj is Person person)
        {
            result = (_name == person.Name)
                  && (_surname == person.Surname)
                  && (_age == person.Age);
        }

        return result;
    }

    public override int GetHashCode() => HashCode.Combine(_name, _surname, _age);

    public int CompareTo(object? obj)
    {
        if (obj is Person person)
            return Age.CompareTo(person.Age);
        else if (obj is Rectangle rectangle)
            return 1;
        
        throw new ArgumentException($"This object cannot be compared to a {nameof(Person)}");
    }

    public virtual void RandomInit()
    {   
        Random random = new();

        string[] names    = { "Илья", "Никита", "Тимур", "Мирослав", "Николай", "Лука", "Тимофей", "Денис", "Дмитрий", "Максим", "Василий", "Михаил", "Макар", "Егор", "Давид", "Назар", "Артём", "Владимир", "Елисей", "Андрей", "Александр", "Билал", "Кирилл", "Руслан", "Алексей", "Дамир", "Ростислав", "Константин", "Арсений", "Глеб", "Григорий", "Игорь", "Георгий", "Ярослав", "Пётр", "Леонид", "Роман", "Леон", "Лев", "Даниил", "Али", "Евгений", "Артур", "Святослав", "Мирон", "Фёдор", "Марк", "Сергей", "Вадим", "Владислав", "Станислав", "Тигран", "Захар", "Демид", "Матвей", "Виктор", "Иван", "Платон", "Данила", "Степан", "Серафим", "Филипп", "Арсен", "Адам", "Ян", "Павел", "Антон", "Марат", "Тихон", "Артемий", "Олег", "Родион", "Герман", "Савелий", "Эмиль", "Юрий", "Валерий", "Виталий", "Вячеслав", "Савва", "Эрик", "Гордей", "Данил", "Роберт", "Богдан", "Всеволод", "Эмир", "Даниэль", "Мартин", "Борис", "Семён", "Добрыня", "Ибрагим", "Демьян", "Анатолий", "Рустам", "Данис", "Яромир", "Марсель", "Аркадий" };
        string[] surnames = { "Ряполов", "Костин", "Блинов", "Набоко", "Кочерёжкин", "Иньшов", "Аронов", "Носов", "Абарников", "Ясногородский", "Шамило", "Рязанцев", "Решетилов", "Булдаков", "Клюшников", "Истомин", "Зууфин", "Вельдин", "Малахов", "Маланов", "Невзоров", "Стаин", "Лапухов", "Бабатьев", "Плеханов", "Язовицкий", "Карявин", "Селиванов", "Краснопёров", "Ивашов", "Викашев", "Симонов", "Леванов", "Трактирников", "Баушев", "Гик", "Кидин", "Жабин", "Сиянко", "Козлитин", "Праздников", "Воронин", "Муратов", "Ященко", "Квятковский", "Фененко", "Путятин", "Зубарев", "Нежданов", "Еськин", "Кодица", "Абдулов", "Бугайчук", "Сорокин", "Лукин", "Левин", "Якурин", "Ящин", "Чашин", "Молчанов", "Яшунин", "Ярцин", "Гареев", "Яшков", "Янкелевич", "Мажов", "Крымов", "Усатов", "Бормотов", "Бурцов", "Нямин", "Буков", "Жикин", "Ярцев", "Катькин", "Милов", "Козловский", "Чернышёв", "Староволков", "Соломинцев", "Штыков", "Тюлепов", "Достоевский", "Баландин", "Воробьёв", "Аглеев", "Сытников", "Шишов", "Дурченко", "Силин", "Шакмаков", "Лещёв", "Собчак", "Болдырев", "Янковский", "Яушев", "Арчибасов", "Чирков", "Усов", "Ярцов" };

        _name    = names[random.Next(names.Length)];
        _surname = surnames[random.Next(surnames.Length)];
        _age     = random.Next(18, 65);
    }

    public void ChangeName(string name) => _name = name;

    public object ShallowCopy() => MemberwiseClone();
    public virtual object Clone() => new Person(Name, Surname, Age);

    public string GetInfo() =>                $"{nameof(Person)}: {Name}, {Surname}, {Age}";
    public virtual string GetInfoVirtual() => $"{nameof(Person)}: {Name}, {Surname}, {Age}";
    public override string ToString() => $"Name: {Name, -12} Surname: {Surname, -14} Age: {Age}";
}