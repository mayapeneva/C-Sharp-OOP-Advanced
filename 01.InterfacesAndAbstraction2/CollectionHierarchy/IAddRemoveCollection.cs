public interface IAddRemoveCollection<T>
{
    int AddFirst(T item);

    T RemoveLast();
}