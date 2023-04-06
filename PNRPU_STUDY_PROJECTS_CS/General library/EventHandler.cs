namespace EventHandler;

public class EventInfo<T> : EventArgs {
    private string _collectionName;
    private string _changeType;
    private T      _chainedObject;

    public string CollectionName { get => _collectionName; }
    public string ChangeType     { get => _changeType;     }
    public T      ChainedObject  { get => _chainedObject;  }

    public EventInfo(string collectionName, string changeType, T chainedObject) {
        _collectionName = collectionName;
        _changeType     = changeType;
        _chainedObject  = chainedObject;
    }

    public override string ToString() {
        return $"Имя коллекции: {CollectionName}, тип изменения: {ChangeType}";
    }
}