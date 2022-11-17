using InteractiveConsoleMenu;
using IRandom;
using Staff;
using Figure;
using Order;
using System;

namespace Lab10
{
    public class Lab
    {
        private static Menu menu = new(
            new MenuCategory("Главное меню",
                             "Опции лабораторной работы №10", new MenuItem[]{
                new MenuBack("Завершить работу программы"),
                new MenuAction("Выполнить первое задание", SolveFirstTask),
                new MenuAction("Выполнить второе задание", SolveSecondTask),
                new MenuAction("Выполнить третье задание", SolveThirdTask)
        }));
        private static int menuStartIndex = 0;
        private static int downWorkAreaIndex = menuStartIndex;

        public static void ShowTaskMenu()
        {
            menu.Run();
        }

        private static void SolveFirstTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            Person[] persons = GetPersons();

            Console.WriteLine("\nВызов функции GetInfo():");
            foreach (var person in persons)
            {
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine("\nВызов функции GetInfoVirtual():");
            foreach (var person in persons)
            {
                Console.WriteLine(person.GetInfoVirtual());
            }

            downWorkAreaIndex = Console.CursorTop;
        }

        private static void SolveSecondTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            Person[] persons = GetPersons();

            Console.WriteLine("\nПолный список:");
            foreach (var person in persons)
            {
                Console.WriteLine(person.GetInfoVirtual());
            }

            Console.WriteLine("\nПерсоны старше 30 лет:");
            var personsOlderThan30 = GetPersonsOlderThan(persons, 30);
            foreach (var person in personsOlderThan30)
            {
                Console.WriteLine(person.GetInfoVirtual());
            }

            Console.WriteLine("\nРабочие—электрики:");
            var electricianWorkers = GetElectricianWorkers(persons);
            foreach (var worker in electricianWorkers)
            {
                Console.WriteLine(worker.GetInfoVirtual());
            }

            Console.WriteLine("\nФамилии и имена всех рабочих:");
            var workersFullnames = GetFullnamesOfWorkers(persons);
            foreach (var fullname in workersFullnames)
            {
                Console.WriteLine(fullname);
            }

            downWorkAreaIndex = Console.CursorTop;
        }

        private static void SolveThirdTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            IRandomInit[] array = GetRandomlyGeneratedObjects();
            Console.WriteLine("\nСписок сгенерированных элементов:");
            PrintObjects(array);

            Console.WriteLine("\nОтсортированные элементы (IComparable), сначала фигуры по возрастанию площади, затем люди по возрастанию возраста:");
            Array.Sort(array);
            PrintObjects(array);

            array = GetRandomlyGeneratedObjects();
            Console.WriteLine("\nСписок сгенерированных элементов:");
            PrintObjects(array);

            Console.WriteLine("\nОтсортированные элементы (IComparer), сначала фигуры по возрастанию площади, затем люди по возрастанию возраста:");
            Array.Sort(array, new OrderByAge());
            PrintObjects(array);

            Person person = new Person();
            Person personShallow = (Person)person.ShallowCopy();
            Person personClone   = (Person)person.Clone();

            Console.WriteLine($"\nСравнение способов копирования\nСоздан объект {person.GetType().Name}:\n{person.GetInfoVirtual()}");
            Console.WriteLine($"Поверхностная копия объекта:\n{personShallow.GetInfoVirtual()}");
            Console.WriteLine($"Глубокая копия объекта:\n{personClone.GetInfoVirtual()}");

            Console.WriteLine("\nИзменяю поля name на \"Shallow\" и \"Clone\" соответственно");
            personShallow.ChangeName("Shallow");
            personClone.ChangeName("Clone");

            Console.WriteLine($"Изначальный объект:\n{person.GetInfoVirtual()}");
            Console.WriteLine($"Поверхностная копия объекта после изменения:\n{personShallow.GetInfoVirtual()}");
            Console.WriteLine($"Глубокая копия объекта после изменения:\n{personClone.GetInfoVirtual()}");
            Console.WriteLine("\nИзменённые атрибуты не содержат ссылок на другие объекты, поэтому оба способа копирования сработали корректно.");

            downWorkAreaIndex = Console.CursorTop;
        }

        private static Person[] GetPersons()
        {
            Person person =       new("Vladimir", "Bezukh", 22);
            Employee employee =   new("Vasilisa", "Simonova", 52, "Manager");
            Engineer engineer =   new("Georgii", "Gorbachev", 28, "C# developer");
            Worker firstWorker =  new("Maksim", "Kuznetsov", 35, "Electrician");
            Worker secondWorker = new("Svetlana", "Morozova", 30, "Electrician");
            Worker thirdWorker =  new("Fedor", "Sedov", 43, "Plumber");

            return new[] { person, employee, engineer, firstWorker, secondWorker, thirdWorker };
        }

        private static IRandomInit[] GetRandomlyGeneratedObjects()
        {
            IRandomInit[] result = { new Rectangle(), new Rectangle(), new Rectangle(),
                                     new Person(),    new Person(),    new Person(),
                                     new Employee(),  new Employee(),  new Employee(),
                                     new Engineer(),  new Engineer(),  new Engineer(),
                                     new Worker(),    new Worker(),    new Worker() };

            return result;
        }

        private static void PrintObjects(IRandomInit[] array)
        {
            foreach (var obj in array)
                Console.WriteLine(obj);
        }

        private static List<Person> GetPersonsOlderThan(Person[] persons, int age)
        {
            if (age < 0)
                return new List<Person>(persons);

            List<Person> personsOlder = new();
            foreach (Person person in persons)
            {
                if (person.Age > age)
                {
                    personsOlder.Add(person);
                }
            }

            return personsOlder;
        }

        private static List<Worker> GetElectricianWorkers(Person[] persons)
        {
            List<Worker> electricianWorkers = new();
            foreach (Person person in persons)
            {
                if (person is Worker worker)
                {
                    if (worker.Position == "Electrician")
                    {
                        electricianWorkers.Add(worker);
                    }
                }
            }

            return electricianWorkers;
        }

        private static List<string> GetFullnamesOfWorkers(Person[] persons)
        {
            List<string> workersFullnames = new();
            foreach (Person person in persons)
            {
                if (person is Worker worker)
                {
                    workersFullnames.Add($"{worker.Surname} {worker.Name}");
                }
            }

            return workersFullnames;
        }
    }
}