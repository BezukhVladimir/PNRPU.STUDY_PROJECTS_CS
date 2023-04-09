using Staff;
using System.Linq;

namespace Lab14 {
    public class Lab {
        public static void ShowTaskMenu() {
            List<Engineer> collection1 = new();
            List<Person> collection2 = new();

            for (int i = 0; i < 10; ++i) {
                Engineer engineer = new();
                Worker   worker   = new();

                engineer.RandomInit();
                worker.RandomInit();

                collection1.Add(engineer);
                collection2.Add(worker);
            }

            print(collection1, "Инженеры:");
            print(collection2, "Сотрудники:");

            // union
            List<Person> collection = collection1.Cast<Person>().Union(collection2).ToList();
            print(collection, "Union инженеров и сотрудников:");

            // average (агрегирование)
            double averageAge = collection.Average(person => person.Age);
            Console.WriteLine($"Средний возраст всех сотрудников: {averageAge}");
            Console.WriteLine();

            // select
            var fullnames = collection.Select(engineer => new {
                Name = engineer.Name,
                Surname = engineer.Surname
            }).ToList();
            print(fullnames, "Select по имени:");

            // where
            var notYoungPeople = collection.Where(engineer => engineer.Age > 35).ToList();
            print(notYoungPeople, "Where старше 35:");

            // group by (группировка)
            var groupedPeople = collection1.GroupBy(engineer => engineer.Position).ToList();
            Console.WriteLine("Инженеры по специальностям:");
            foreach (var group in groupedPeople) {
                Console.WriteLine($"Специальность: {group.Key}");
                foreach (var person in group) {
                    Console.WriteLine($"\t{person}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void print<T>(List<T> collection, string text) {
            Console.WriteLine(text);
            foreach (var element in collection) {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }
    }
}
