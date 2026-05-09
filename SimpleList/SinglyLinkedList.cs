using SimpleList;
using System;
using System.Collections.Generic;

namespace DoubleList;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;

    public SinglyLinkedList()
    {
        _head = null;
    }

    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null || data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
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
        if (_head == null) return "List is empty";

        return GetBackwardText(_head) + "null";
    }

    private string GetBackwardText(Node<T>? node)
    {
        if (node == null) return "";
        return GetBackwardText(node.Next) + $"{node.Data} -> ";
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
                if (current.Data!.CompareTo(current.Next.Data!) < 0)
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
            if (counts.ContainsKey(current.Data!)) counts[current.Data!]++;
            else counts[current.Data!] = 1;
            current = current.Next;
        }

        int maxFreq = 0;
        foreach (var freq in counts.Values)
        {
            if (freq > maxFreq) maxFreq = freq;
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
            if (counts.ContainsKey(current.Data!)) counts[current.Data!]++;
            else counts[current.Data!] = 1;
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
        if (_head == null) return;

        if (_head.Data!.Equals(data))
        {
            _head = _head.Next;
            return;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data!.Equals(data))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public void DeleteAllOccurrences(T data)
    {
        while (_head != null && _head.Data!.Equals(data))
        {
            _head = _head.Next;
        }

        var current = _head;
        while (current != null && current.Next != null)
        {
            if (current.Next.Data!.Equals(data))
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }
}