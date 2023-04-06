using Staff;
using EventHandler;

namespace JournalHandler;

public class JournalEntry {
    private string _collectionName;
    private string _changeType;
    private string _objectInfo;

    public string CollectionName { get => _collectionName; }
    public string ChangeType     { get => _changeType;     }
    public string ObjectInfo     { get => _objectInfo;     }

    public JournalEntry(string collectionName, string changeType, string objectInfo) {
        _collectionName = collectionName;
        _changeType     = changeType;
        _objectInfo     = objectInfo;
    }

    public override string ToString() {
        return $"Название коллекции: {CollectionName}, тип изменения: {ChangeType}, информация об объекте: {ObjectInfo}";
    }
}

public class Journal
{
    public List<JournalEntry> journal = new();

    public void CollectionCountChanged(object source, EventInfo<Person> args) {
        journal.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ChainedObject.ToString()));
    }
}
