
using System.Collections.Generic;

namespace XUnitTests
{
    public class Tests
    {
        [Theory]
        [InlineData(-11)]
        [InlineData(0)]
        [InlineData(2.1)]
        [InlineData(33)]
        [InlineData(1067 / 2)]
        public void AddedElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(value);
            Assert.Contains(value, list);
            Assert.False(list.IsReadOnly);
        }

        [Fact]
        public void AddedInvalidElement()
        {
            MyLinkedList<string> list = new MyLinkedList<string>();
            Assert.Throws<ArgumentNullException>(() => list.Add(null));
        }

        [Theory]
        [InlineData(-22)]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(66)]
        public void RemovedElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -22, 0, 4, 66 };
            list.Remove(value);
            Assert.DoesNotContain(value, list);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void RemovedInvalidElement()
        {
            MyLinkedList<string> list = new MyLinkedList<string>();
            Assert.Throws<ArgumentNullException>(() => list.Remove(null));
        }

        [Fact]
        public void RemovedElementFromEmptyList()
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { };
            Assert.False(list.Remove(5));
        }

        [Theory]
        [InlineData(-22)]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(66)]
        public void ContainsElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -22, 0, 4, 66 };
            bool result = list.Contains(value); 
            Assert.True(result);
        }

        [Theory]
        [InlineData(-11)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(7)]
        public void NotContainsElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -22, 0, 4, 66 };
            bool result = list.Contains(value);
            Assert.False(result);
        }

        [Fact]
        public void ContainsInEmptyList()
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { };
            Assert.False(list.Contains(5));
        }

        [Fact]
        public void ClearList()
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -22, 0, 4, 66 };
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void CopiedToArray()
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            int[] array = new int[3];
            list.CopyTo(array, 0);

            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void CopyTo_WithInvalidArray()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();

            Assert.Throws<ArgumentNullException>(() => list.CopyTo(null, 0));

            int[] array = new int[3];
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));

            list.Add(1);
            list.Add(2);
            list.Add(3);
            array = new int[2];
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));
        }

        [Theory]
        [InlineData(-11, 0)]
        [InlineData(0, 5)]
        [InlineData(2, 1)]
        [InlineData(33, 2)]
        public void InsertedAfter(int value, int newvalue)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -11, 0, 2, 33 };
            list.InsertAfter(value, newvalue);
            Assert.Contains(newvalue, list);
        }

        [Theory]
        [InlineData(-5, 0)]
        [InlineData(1, 5)]
        [InlineData(6, 1)]
        [InlineData(105, 2)]
        public void InsertedAfterNotExistingItem(int value, int newvalue)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -11, 0, 2, 33 };
            bool result = list.InsertAfter(value, newvalue);
            Assert.False(result);
        }

        [Fact]
        public void InsertedAfterInEmptyList()
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { };
            Assert.False(list.InsertAfter(5, 2));
        }

        [Theory]
        [InlineData(-11)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(33)]
        [InlineData(1067 / 2)]
        public void AddedFirstElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { 2, 4 };
            list.AddFirst(value);
            Assert.Equal(value, list.First());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1067 / 2)]
        public void AddedFirstElementInEmptyList(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { };
            list.AddFirst(value);
            Assert.Equal(value, list.First());
        }

    }
}