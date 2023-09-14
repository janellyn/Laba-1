using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyLinkedList<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    public MyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public int Count => count;

    private class Node<TNode>
    {
        public TNode Data { get; }
        public Node<TNode> Next { get; set; }

        public Node(TNode data)
        {
            Data = data;
            Next = null;
        }
    }
    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            tail.Next = head;
        }
        else
        {
            newNode.Next = head;
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
        OnItemAdded(item);
    }

    public bool Remove(T item)
    {
        if (head == null)
            return false;

        Node<T> current = head;
        Node<T> previous = null;

        do
        {
            if (current.Data.Equals(item))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                    if (current == head)
                        head = current.Next;
                    if (current == tail)
                        tail = previous;
                }
                else
                {
                    head = head.Next;
                    tail.Next = head;
                }
                count--;
                OnItemRemoved(item);
                return true;
            }

            previous = current;
            current = current.Next;
        } while (current != head);

        return false;
    }

    public bool Contains(T item)
    {
        if (head == null)
            return false;

        Node<T> current = head;

        do
        {
            if (current.Data.Equals(item))
                return true;

            current = current.Next;
        } while (current != head);

        return false;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public event Action<T> ItemAdded;

    public event Action<T> ItemRemoved;

    protected virtual void OnItemAdded(T item)
    {
        ItemAdded?.Invoke(item);
    }

    protected virtual void OnItemRemoved(T item)
    {
        ItemRemoved?.Invoke(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (head != null)
        {
            Node<T> current = head;
            do
            {
                yield return current.Data;
                current = current.Next;
            } while (current != head);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
