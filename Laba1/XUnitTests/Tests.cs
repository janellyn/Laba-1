
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
    }
}