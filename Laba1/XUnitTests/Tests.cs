
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
        [InlineData(103)]
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
        [InlineData(103)]
        public void ContainsElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>() { -22, 0, 4, 66 };
            bool result = list.Contains(value); 
            Assert.Equal(result, list.Contains(value));
        }
    }
}