using Xunit;

namespace FindItemSortedArray
{
    public class UnitTests
    {
        [Fact]
        public void FindItem()
        {
            var arr = new int[] { 11, 17, 29 };
            Assert.Equal((true, 0), new ItemFinder<int>(arr).FindItem(11));
            Assert.Equal((true, 1), new ItemFinder<int>(arr).FindItem(17));
            Assert.Equal((true, 2), new ItemFinder<int>(arr).FindItem(29));
            Assert.Equal((false, -1), new ItemFinder<int>(arr).FindItem(2));
        }
    }
}
