public interface IMyList<T>
{
    int AddFirst(T item);

    T RemoveFirst();

    int Used();
}