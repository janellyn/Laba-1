using System.Collections;

public class MyLinkedList<T> : ICollection<T>, IEnumerable<T> 
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
    public bool IsReadOnly => false;

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
        if (item == null)
        {
            throw new ArgumentNullException($"{typeof(T)} {nameof(item)} is null");
        }

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
        if (item == null)
        {
            throw new ArgumentNullException($"{typeof(T)} {nameof(item)} is null");
        }

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
            {
                OnItemContain(item);
                return true;
            }

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

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));

        if (count > array.Length - arrayIndex)
            throw new ArgumentException("The number of elements in the source collection is greater than the available space from the index to the end of the destination array.");

        Node<T> current = head;
        int currentIndex = 0;

        while (current != null && arrayIndex + currentIndex < array.Length)
        {
            array[arrayIndex + currentIndex] = current.Data;
            current = current.Next;
            currentIndex++;
        }
    }

    public bool InsertAfter(T existingItem, T newItem)
    {
        Node<T> newNode = new Node<T>(newItem);

        if (head == null)
            return false;

        Node<T> current = head;

        do
        {
            if (current.Data.Equals(existingItem))
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                    tail = newNode;
                count++;
                OnItemAdded(newItem);
                return true;
            }

            current = current.Next;
        } while (current != head);

        return false;
    }

    public void AddFirst(T item)
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
            head = newNode;
        }
        count++;
        OnItemAddedFirst(item);
    }

    public event Action<T> ItemAdded;

    public event Action<T> ItemRemoved;

    public event Action<T> Contain;

    public event Action<T> ItemAddedFirst;

    protected virtual void OnItemAdded(T item)
    {
        ItemAdded?.Invoke(item);
    }

    protected virtual void OnItemRemoved(T item)
    {
        ItemRemoved?.Invoke(item);
    }

    protected virtual void OnItemContain(T item)
    {
        Contain?.Invoke(item);
    }

    protected virtual void OnItemAddedFirst(T item)
    {
        ItemAddedFirst?.Invoke(item);
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
