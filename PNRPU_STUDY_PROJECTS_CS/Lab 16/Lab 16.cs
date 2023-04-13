using Staff;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab16 {
    public class Lab {
        public static void ShowTaskMenu() {
            List<Engineer> collection1 = new();

            for (int i = 0; i < 10; ++i) {
                Engineer engineer = new();

                engineer.RandomInit();

                collection1.Add(engineer);
            }

            string path = "../../../Lab 16/staff";

            // Бинарная сериализация
            BinaryFormatter formatter = new BinaryFormatter();

            print(collection1, "Исходные данные:");
            using FileStream writer1 = new(path + ".bin", FileMode.Create);
            formatter.Serialize(writer1, collection1);
            writer1.Close();

            List<Engineer> collection2 = new();
            using FileStream reader1 = new(path + ".bin", FileMode.Open);
            collection2 = (List<Engineer>)formatter.Deserialize(reader1);
            reader1.Close();
            print(collection2, "Бинарная десериализация:");

            // JSON сериализация
            string json = JsonSerializer.Serialize(collection1);
            using StreamWriter writer2 = new(path + ".json");
            writer2.Write(json);
            writer2.Close();

            collection2.Clear();
            using StreamReader reader2 = new(path + ".json");
            json = reader2.ReadToEnd();
            collection2 = JsonSerializer.Deserialize<List<Engineer>>(json);
            reader2.Close();
            print(collection2, "JSON десериализация:");

            // XML десериализация
            XmlSerializer serializer = new(typeof(List<Engineer>));
            using StreamWriter writer3 = new(path + ".xml");
            serializer.Serialize(writer3, collection1);
            writer3.Close();

            collection2.Clear();
            serializer = new(typeof(List<Engineer>));
            using StreamReader reader3 = new StreamReader(path + ".xml");
            collection2 = (List<Engineer>)serializer.Deserialize(reader3);
            reader3.Close();
            print(collection2, "XML десериализация:");
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