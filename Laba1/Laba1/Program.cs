using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        MyLinkedList<int> list = new MyLinkedList<int>();

        list.ItemAdded += item => Console.WriteLine($"Елемент {item} доданий до списку.");
        list.ItemRemoved += item => Console.WriteLine($"Елемент {item} видалений з списку.");
        list.Contain += item => Console.WriteLine($"Елемент {item} є у списку.");
        list.ClearUp += item => Console.WriteLine($"Список чистий.");
        list.ItemAddedFirst += item => Console.WriteLine($"Елемент {item} доданий на перше місце у списку.");

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Remove(2);
        list.Contains(3);
        list.AddFirst(4);

        foreach (var item in list)
        {
            Console.Write(item + ", ");
        }
    }
}
 