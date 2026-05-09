namespace DoubleList;

public interface ILinkedList<T>
{
    void Add(T data);
    string ShowForward();
    string ShowBackward();
    void OrderDescending();
    string ShowModes();
    string ShowGraph();
    bool Exists(T data);
    void DeleteOccurrence(T data);
    void DeleteAllOccurrences(T data);
}