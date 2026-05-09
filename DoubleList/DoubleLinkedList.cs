using System;
using System.Collections.Generic;

namespace DoubleList;

public class DoubleLinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Previous = current;

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        else
        {
            _tail = newNode;
        }

        current.Next = newNode;
    }

    public string ShowForward()
    {
        if (_head == null) return "List is empty";

        var result = "";
        var current = _head;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        return result + "null";
    }

    public string ShowBackward()
    {
        if (_tail == null) return "List is empty";

        var result = "";
        var current = _tail;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Previous;
        }
        return result + "null";
    }

    public void OrderDescending()
    {
        if (_head == null || _head.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            var current = _head;

            while (current.Next != null)
            {
                if (current.Data!.CompareTo(current.Next.Data) < 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }

    public string ShowModes()
    {
        if (_head == null) return "No data";

        var counts = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (counts.ContainsKey(current.Data!))
                counts[current.Data!]++;
            else
                counts[current.Data!] = 1;
            current = current.Next;
        }

        int maxFreq = 0;
        foreach (var val in counts.Values)
        {
            if (val > maxFreq) maxFreq = val;
        }

        var modes = new List<T>();
        foreach (var pair in counts)
        {
            if (pair.Value == maxFreq) modes.Add(pair.Key);
        }

        return "Mode(s): " + string.Join(", ", modes);
    }

    public string ShowGraph()
    {
        if (_head == null) return "No data to graph";

        var counts = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (counts.ContainsKey(current.Data!))
                counts[current.Data!]++;
            else
                counts[current.Data!] = 1;
            current = current.Next;
        }

        var graph = "";
        foreach (var pair in counts)
        {
            graph += $"{pair.Key} {new string('*', pair.Value)}\n";
        }
        return graph;
    }

    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) return true;
            current = current.Next;
        }
        return false;
    }

    public void DeleteOccurrence(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                return;
            }
            current = current.Next;
        }
    }

    public void DeleteAllOccurrences(T data)
    {
        var current = _head;
        while (current != null)
        {
            var nextNode = current.Next;
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
            }
            current = nextNode;
        }
    }

    private void RemoveNode(Node<T> node)
    {
        if (node == _head) _head = node.Next;
        if (node == _tail) _tail = node.Previous;

        if (node.Previous != null) node.Previous.Next = node.Next;
        if (node.Next != null) node.Next.Previous = node.Previous;
    }
}