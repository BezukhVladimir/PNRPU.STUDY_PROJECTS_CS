using Figure;
using InteractiveConsoleMenu;
using IRandom;
using Order;
using Staff;
using System.Text;

namespace Lab10
{
    public class Lab
    {
        private static Menu s_menu = new(
            new MenuCategory("Главное меню",
                             "Опции лабораторной работы №10", new MenuItem[]{
                new MenuBack("Завершить работу программы"),
                new MenuAction("Выполнить первое задание", OutputToConsoleFirstTaskResult),
                new MenuAction("Выполнить второе задание", OutputToConsoleSecondTaskResult),
                new MenuAction("Выполнить третье задание", OutputToConsoleThirdTaskResult)
        }));
        private static int s_menuStartIndex = 0;
        private static int s_downWorkAreaIndex = s_menuStartIndex;

        public static string GetFirstTaskResult()  => SolveFirstTask();
        public static string GetSecondTaskResult() => SolveSecondTask();
        public static string GetThirdTaskResult()  => SolveThirdTask();

        public static void ShowTaskMenu()
        {
            s_menu.Run();
        }

        public static Person[] GetPersons()
        {
            Person person =       new("Vladimir", "Bezukh", 22);
            Employee employee =   new("Vasilisa", "Simonova", 52, "Manager");
            Engineer engineer =   new("Georgii", "Gorbachev", 28, "C# developer");
            Worker firstWorker =  new("Maksim", "Kuznetsov", 35, "Electrician");
            Worker secondWorker = new("Svetlana", "Morozova", 30, "Electrician");
            Worker thirdWorker =  new("Fedor", "Sedov", 43, "Plumber");

            return new[] { person, employee, engineer, firstWorker, secondWorker, thirdWorker };
        }

        public static IRandomInit[] GetRandomlyGeneratedObjects()
        {
            IRandomInit[] result = { new Rectangle(), new Rectangle(), new Rectangle(),
                                     new Person(),    new Person(),    new Person(),
                                     new Employee(),  new Employee(),  new Employee(),
                                     new Engineer(),  new Engineer(),  new Engineer(),
                                     new Worker(),    new Worker(),    new Worker() };

            foreach (IRandomInit obj in result)
                obj.RandomInit();

            return result;
        }

        public static List<Person> GetPersonsOlderThan(Person[] persons, int age)
        {
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

        public static List<Worker> GetElectricianWorkers(Person[] persons)
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

        public static List<string> GetWorkersFullnames(Person[] persons)
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

        private static string PrintObjects(IRandomInit[] array)
        {
            var result = new StringBuilder();

            foreach (var obj in array)
            {
                result.Append(obj);
                result.Append('\n');
            }

            return result.ToString();
        }

        private static string SolveFirstTask()
        {
            Person[] persons = GetPersons();

            var result = new StringBuilder();
            result.Append("Вызов функции GetInfo():\n");
            foreach (var person in persons)
            {
                result.Append(person.GetInfo());
                result.Append('\n');
            }

            result.Append("\nВызов функции GetInfoVirtual():\n");
            foreach (var person in persons)
            {
                result.Append(person.GetInfoVirtual());
                result.Append('\n');
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        private static string SolveSecondTask()
        {
            Person[] persons = GetPersons();

            var result = new StringBuilder();
            result.Append("Полный список:\n");
            foreach (var person in persons)
            {
                result.Append(person.GetInfoVirtual());
                result.Append('\n');
            }

            result.Append("\nПерсоны старше 30 лет:\n");
            var personsOlderThan30 = GetPersonsOlderThan(persons, 30);
            foreach (var person in personsOlderThan30)
            {
                result.Append(person.GetInfoVirtual());
                result.Append('\n');
            }

            result.Append("\nРабочие-электрики:\n");
            var electricianWorkers = GetElectricianWorkers(persons);
            foreach (var worker in electricianWorkers)
            {
                result.Append(worker.GetInfoVirtual());
                result.Append('\n');
            }

            result.Append("\nФамилии и имена всех рабочих:\n");
            var workersFullnames = GetWorkersFullnames(persons);
            foreach (var fullname in workersFullnames)
            {
                result.Append(fullname);
                result.Append('\n');
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        private static string SolveThirdTask()
        {
            IRandomInit[] array = GetRandomlyGeneratedObjects();

            var result = new StringBuilder();
            result.Append("Список сгенерированных элементов:\n");
            result.Append(PrintObjects(array));

            result.Append("\nОтсортированные элементы (IComparable), сначала фигуры по возрастанию площади, затем люди по возрастанию возраста:\n");
            Array.Sort(array);
            result.Append(PrintObjects(array));

            array = GetRandomlyGeneratedObjects();
            result.Append("\nСписок сгенерированных элементов:\n");
            result.Append(PrintObjects(array));

            result.Append("\nОтсортированные элементы (IComparer), сначала фигуры по возрастанию площади, затем люди по возрастанию возраста:\n");
            Array.Sort(array, new OrderByAge());
            result.Append(PrintObjects(array));

            Person person = new();
            Person personShallow = (Person)person.ShallowCopy();
            Person personClone   = (Person)person.Clone();

            result.Append($"\nСравнение способов копирования\nСоздан объект {person.GetType().Name}:\n{person.GetInfoVirtual()}\n");
            result.Append($"Поверхностная копия объекта:\n{personShallow.GetInfoVirtual()}\n");
            result.Append($"Глубокая копия объекта:\n{personClone.GetInfoVirtual()}\n");

            result.Append("\nИзменяю поля name на \"Shallow\" и \"Clone\" соответственно\n");
            personShallow.ChangeName("Shallow");
            personClone.ChangeName("Clone");

            result.Append($"Изначальный объект:\n{person.GetInfoVirtual()}\n");
            result.Append($"Поверхностная копия объекта после изменения:\n{personShallow.GetInfoVirtual()}\n");
            result.Append($"Глубокая копия объекта после изменения:\n{personClone.GetInfoVirtual()}\n");
            result.Append("\nИзменённые атрибуты не содержат ссылок на другие объекты, поэтому оба способа копирования сработали корректно.");
            
            return result.ToString();
        }

        private static void OutputToConsoleFirstTaskResult()
        {
            if (s_downWorkAreaIndex != s_menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(s_menu.downMenuIndex, s_downWorkAreaIndex);

            Console.Write("{0}{1}", '\n', GetFirstTaskResult());

            s_downWorkAreaIndex = Console.CursorTop;
        }

        private static void OutputToConsoleSecondTaskResult()
        {
            if (s_downWorkAreaIndex != s_menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(s_menu.downMenuIndex, s_downWorkAreaIndex);

            Console.Write("{0}{1}", '\n', GetSecondTaskResult());

            s_downWorkAreaIndex = Console.CursorTop;

        }

        private static void OutputToConsoleThirdTaskResult()
        {
            if (s_downWorkAreaIndex != s_menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(s_menu.downMenuIndex, s_downWorkAreaIndex);

            Console.Write("{0}{1}", '\n', GetThirdTaskResult());

            s_downWorkAreaIndex = Console.CursorTop;
        }
    }
}