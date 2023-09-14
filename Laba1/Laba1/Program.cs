using System.Collections;
using System.Collections.Generic;

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
 