using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        MyLinkedList<int> circularList = new MyLinkedList<int>();

        circularList.ItemAdded += item => Console.WriteLine($"Елемент {item} доданий до списку.");
        circularList.ItemRemoved += item => Console.WriteLine($"Елемент {item} видалений зі списку.");

        circularList.Add(1);
        circularList.Add(2);
        circularList.Add(3);
        circularList.Remove(2);

        foreach (var item in circularList)
        {
            Console.WriteLine(item);
        }
    }
}
 