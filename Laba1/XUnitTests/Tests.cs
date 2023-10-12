
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
        public void ListAddedElement(int value)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(value);
            Assert.Contains(value, list);
        }


    }
}