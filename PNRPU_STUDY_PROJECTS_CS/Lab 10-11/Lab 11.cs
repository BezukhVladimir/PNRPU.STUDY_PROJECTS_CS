using Figure;
using IRandom;  
using Staff;
using System.Diagnostics;
using UserInputHandler;

namespace Lab11
{
    public class Lab
    {
        public static void ShowTaskMenu()
        {
            SolveFirstTask();
        }

        public static Person[] GetPersons()
        {
            Person person = new("Vladimir", "Bezukh", 22);
            Employee employee = new("Vasilisa", "Simonova", 52, "Manager");
            Engineer engineer = new("Georgii", "Gorbachev", 28, "C# developer");
            Worker firstWorker = new("Maksim", "Kuznetsov", 35, "Electrician");
            Worker secondWorker = new("Svetlana", "Morozova", 30, "Electrician");
            Worker thirdWorker = new("Fedor", "Sedov", 43, "Plumber");

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

        private static void SolveFirstTask()
        {
            Console.Write("Введите количество элементов в коллекциях от 0 до 10000: ");
            int size = Integer.GetFromRange(0, 10000);
            int first = 0;
            int middle = size / 2;
            int last = size - 1;

            TestCollections collections = new TestCollections();
            collections.RandomInit(size);
            bool found;

            // 1 List<Person>
            Console.WriteLine("\nПоиск 1-го элемента в List<Person>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPerson, (Person)collections.fcPerson.First().Clone(), out found)} мс.");
            Print(found, "1-ый");

            Console.WriteLine("Поиск центрального элемента в List<Person>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPerson, (Person)collections.fcPerson[middle].Clone(), out found)} мс. ");
            Print(found, "Центральный");

            Console.WriteLine("Поиск последнего элемента в List<Person>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPerson, (Person)collections.fcPerson.Last().Clone(), out found)} мс.");
            Print(found, "Последний");

            Console.WriteLine("Поиск элемента, не входящего в List<Person>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPerson, new Person("name", "surname", 0), out found)} мс.");
            Print(found, "Отсутствующий");
            Console.WriteLine();

            // 2 List<string>
            Console.WriteLine("Поиск 1-го элемента в List<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, (string)collections.fcString.First().Clone(), out found)} мс.");
            Print(found, "1-ый");

            Console.WriteLine("Поиск центрального элемента в List<string>.");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, collections.fcString[middle], out found)} мс.");
            Print(found, "Центральный");

            Console.WriteLine("Поиск последнего элемента в List<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, (string)collections.fcString.Last().Clone(), out found)} мс.");
            Print(found, "Последний");

            Console.WriteLine("Поиск элемента, не входящего в List<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, "smthng", out found)} мс.");
            Print(found, "Отсутствующий");
            Console.WriteLine();

            // 3 Dictionary<Person, Employee>
            List<Person> keys = new(collections.scPersonEmployee.Keys);
            Console.WriteLine("Поиск 1-го ключа в Dictionary<Person, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPersonEmployee, (Person)keys[first].Clone(), out found)} мс.");
            Print(found, "1-ый");

            Console.WriteLine("Поиск центрального ключа в Dictionary<Person, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPersonEmployee, (Person)keys[middle].Clone(), out found)} мс.");
            Print(found, "Центральный");

            Console.WriteLine("Поиск последнего ключа в Dictionary<Person, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPersonEmployee, (Person)keys[last].Clone(), out found)} мс.");
            Print(found, "Последний");

            Console.WriteLine("Поиск ключа, не входящего в Dictionary<Person, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPersonEmployee, new Person("name", "surname", 0), out found)} мс.");
            Print(found, "Отсутствующий");
            Console.WriteLine();

            // 4 Dictionary<string, Employee>
            List<string> keysString = new(collections.scStringEmployee.Keys);
            Console.WriteLine("Поиск 1-го ключа в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringEmployee, (string)keysString[first].Clone(), out found)} мс.");
            Print(found, "1-ый");

            Console.WriteLine("Поиск центрального ключа в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringEmployee, (string)keysString[middle].Clone(), out found)} мс.");
            Print(found, "Центральный");

            Console.WriteLine("Поиск последнего ключа в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringEmployee, (string)keysString[last].Clone(), out found)} мс.");
            Print(found, "Последний");

            Console.WriteLine("Поиск ключа, не входящего в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringEmployee, "smthng", out found)} мс.");
            Print(found, "Отсутствующий");
            Console.WriteLine();

            List<Employee> values = new(collections.scStringEmployee.Values);
            Console.WriteLine("Поиск 1-го элемента в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringEmployee, (Employee)values[first].Clone(), out found)} мс.");
            Print(found, "1-ый");

            Console.WriteLine("Поиск центрального элемента в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringEmployee, (Employee)values[middle].Clone(), out found)} мс.");
            Print(found, "Центральный");

            Console.WriteLine("Поиск последнего элемента в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringEmployee, (Employee)values[last].Clone(), out found)} мс.");
            Print(found, "Последний");

            Console.WriteLine("Поиск элемента, не входящего в Dictionary<string, Employee>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringEmployee, new Employee("name", "surname", 0, "position"), out found)} мс.");
            Print(found, "Отсутствующий");
            Console.WriteLine();
        }

        public static string GetTimeList<T>(List<T> list, T obj, out bool found)
        {
            Stopwatch w = new();
            w.Start();
            found = list.Contains(obj);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }

        public static string GetTimeDictionaryKey<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, out bool found)
        {
            Stopwatch w = new();
            w.Start();
            found = dict.ContainsKey(key);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }

        public static string GetTimeDictionaryValue<TKey, TValue>(Dictionary<TKey, TValue> dict, TValue value, out bool found)
        {
            Stopwatch w = new();
            w.Start();
            found = dict.ContainsValue(value);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }

        static void Print(in bool found, string value)
        {
            Console.Write(value + " элемент");

            if (!found)
            {
                Console.Write(" не");
            }

            Console.WriteLine(" был найден.");
        }
    }
}