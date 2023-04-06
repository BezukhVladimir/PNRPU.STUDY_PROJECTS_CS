using Staff;
using BinaryHeap;
using EventHandler;
using JournalHandler;

public class MyNewCollection : MaxHeap<Person> {
    private int    _count = 0;
    private string _name  = "MyNewCollection";

    public delegate void CollectionHandler(object source, EventInfo<Person> args);
    public event CollectionHandler CollectionCountChanged;

    public string Name { get => _name; set => _name = value; }

    public override void Insert(Person obj) {
        base.Insert(obj);
        OnCollectionCountChanged(this, new EventInfo<Person>(Name, "insert", obj));
    }

    public override Person Extract() {
        Person obj = base.Extract();
        OnCollectionCountChanged(this, new EventInfo<Person>(Name, "extract", obj));
        return obj;
    }

    public void OnCollectionCountChanged(object source, EventInfo<Person> args) {
        CollectionCountChanged?.Invoke(this, args);
    }
}

namespace Lab13 {
    public class Lab {
        public static void ShowTaskMenu() {
            MyNewCollection firstCollection  = new();
            MyNewCollection secondCollection = new();
            firstCollection.Name  = "Первая";
            secondCollection.Name = "Вторая";

            Journal firstJournal  = new Journal();
            firstCollection.CollectionCountChanged += firstJournal.CollectionCountChanged;

            for (int i = 1; i <= 10; ++i) {
                Person person = new();
                person.RandomInit();
                firstCollection.Insert(person);
            }

            for (int i = 1; i <= 10; ++i) {
                firstCollection.Extract();
            }

            Console.WriteLine("Записи 1 журнала:");
            foreach (JournalEntry entry in firstJournal.journal) {
                Console.WriteLine(entry);
            }
        }
    }
}
