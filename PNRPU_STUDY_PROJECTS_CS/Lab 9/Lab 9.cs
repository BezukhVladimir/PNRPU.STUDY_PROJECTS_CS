using InteractiveConsoleMenu;
using SpecificDataStructures;
using System.Drawing;
using System.Runtime.InteropServices;
using UserInputHandler;

namespace Lab9
{
    public class Lab
    {
        public static Menu menu = new(
            new MenuCategory("Главное меню",
                             "Опции лабораторной работы №9", new MenuItem[]{
                new MenuBack("Завершить работу программы"),
                new MenuAction("Выполнить первое задание", SolveFirstTask),
                new MenuAction("Выполнить второе задание", SolveSecondTask),
                new MenuAction("Выполнить третье задание", SolveThirdTask)
        }));
        public static int menuStartIndex = 0;
        public static int downWorkAreaIndex = menuStartIndex;

        public static void ShowTaskMenu()
        {
            menu.Run();
        }

        private static void SolveFirstTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            Console.WriteLine("\nДемонстрация для класса Money, часть первая");

            Money m1 = new();
            Money m2 = new(48, 90);

            Console.WriteLine($"m1: {m1.Rubles} рублей {m1.Kopeks} копеек");
            Console.WriteLine($"m2: {m2.Rubles} рублей {m2.Kopeks} копеек");
            Console.WriteLine($"Всего создано объектов класса: {Money.NumberCreatedInstancesClass}");
            
            downWorkAreaIndex = Console.CursorTop;
        }

        private static void SolveSecondTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            Console.WriteLine("\nДемонстрация для класса Money, часть вторая");

            Money m1 = new(48, 90);
            Console.WriteLine($"m1: {m1.Rubles} рублей {m1.Kopeks} копеек");
            m1++;
            Console.WriteLine($"После m1++: {m1.Rubles} рублей {m1.Kopeks} копеек");
            --m1;
            Console.WriteLine($"После --m1: {m1.Rubles} рублей {m1.Kopeks} копеек\n");

            int explicitConversion = (int)m1;
            Console.WriteLine($"Явное преобразование m1 к int: {explicitConversion}");
            double implicitConversion = m1;
            Console.WriteLine($"Неявное преобразование m1 к double: {implicitConversion}\n");

            Console.WriteLine($"m1: {m1.Rubles} рублей {m1.Kopeks} копеек");
            m1 += 20;
            Console.WriteLine($"m1 + 20 = {m1.Rubles} рублей {m1.Kopeks} копеек");
            m1 -= 140;
            Console.WriteLine($"m1 - 140 = {m1.Rubles} рублей {m1.Kopeks} копеек");
            
            downWorkAreaIndex = Console.CursorTop;
        }

        private static void SolveThirdTask()
        {
            if (downWorkAreaIndex != menuStartIndex)
                ConsoleHandler.Cleaner.ClearRowsInRange(menu.downMenuIndex, downWorkAreaIndex);

            Console.WriteLine("\nДемонстрация для класса MoneyArray");

            Console.WriteLine("Создан пустой объект класса MoneyArray");
            MoneyArray emptyArray = new();

            Console.WriteLine("Создан пустой объект класса MoneyArray, требующий заполнения");
            MoneyArray nonemptyArray = new(5);

            Money min = nonemptyArray.GetMin();
            Console.WriteLine($"Среди них минимальный элемент Money: {min.Rubles} рублей {min.Kopeks} копеек");
            Console.WriteLine($"Всего создано объектов класса: {MoneyArray.NumberCreatedInstancesClass}");
            downWorkAreaIndex = Console.CursorTop;
        }
    }
}