using Staff;
using BinaryHeap;

namespace Lab12
{
    public class Lab
    {
        public static void ShowTaskMenu()
        {
            MaxHeap<int> simpleTest = new();
            Console.WriteLine("Демонстрация работы\n");

            for (int i = -10; i <= 10; ++i) {
                simpleTest.Insert(i);
            }

            for (int i = -10; i <= 10; ++i) {
                Console.WriteLine($"Peek: {simpleTest.Peek()} \textract: {simpleTest.Extract()}");
            }

            Console.WriteLine();

            MaxHeap<Person> complexTest = new();
            for (int i = -10; i <= 10; ++i) {
                Person person = new();
                person.RandomInit();
                complexTest.Insert(person);
            }

            for (int i = -10; i <= 10; ++i) {
                Console.WriteLine($"Peek:    {complexTest.Peek()}\n" +
                                  $"Extract: {complexTest.Extract()}\n");
            }
        }
    }
}
