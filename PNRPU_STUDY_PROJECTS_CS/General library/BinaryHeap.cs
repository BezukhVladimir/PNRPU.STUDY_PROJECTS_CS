namespace BinaryHeap;

public class MaxHeap<T>
    where T : IComparable {
    private readonly List<T> _items = new();
    public int Count => _items.Count;

    public T? Peek() {
        if (Count > 0) {
            return _items[0];
        } else {
            return default;
        }
    }

    public T Extract() {
        int rootIndex = 0;
        var result = _items[rootIndex];

        _items[rootIndex] = _items[Count - 1];
        _items.RemoveAt(Count - 1);

        SortAllItems();
        return result;
    }

    private void SortAllItems() {
        int currentIndex = 0;
        int maxIndex = currentIndex;
        int leftIndex;
        int rightIndex;

        while (currentIndex < Count) {
            leftIndex  = 2 * currentIndex + 1;
            rightIndex = 2 * currentIndex + 2;

            if (leftIndex < Count
             && _items[leftIndex].CompareTo(_items[maxIndex]) > 0) {
                maxIndex = leftIndex;
            }

            if (rightIndex < Count
             && _items[rightIndex].CompareTo(_items[maxIndex]) > 0) {
                maxIndex = rightIndex;
            }

            if (maxIndex == currentIndex) {
                break;
            }

            SwapTwoItems(currentIndex, maxIndex);
            currentIndex = maxIndex;
        }
    }

    public void Insert(T item) {
        _items.Add(item);

        var currentIndex = Count - 1;
        var parentIndex = GetParentIndex(currentIndex);

        while (currentIndex > 0
            && _items[parentIndex].CompareTo(_items[currentIndex]) < 0) {
            SwapTwoItems(currentIndex, parentIndex);

            currentIndex = parentIndex;
            parentIndex = GetParentIndex(currentIndex);
        }
    }

    private void SwapTwoItems(int currentIndex, int parentIndex) {
        (_items[parentIndex], _items[currentIndex]) = (_items[currentIndex], _items[parentIndex]);
    }

    private int GetParentIndex(int currentIndex) {
        return (currentIndex - 1) / 2;
    }
}