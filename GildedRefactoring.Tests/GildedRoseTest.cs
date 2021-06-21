using Xunit;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Reporters;
using csharpcore;
using GildedRefactoring.Tests.Helper;
using GildedRoseRefactoring.Shared.Constants;

namespace GildedRefactoring.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GildedRoseTest
    {

        [Fact]
        public void CreationItem()
        {
            var item = SharedFunctions.CreateItem("foo", 0, 0);
            ApprovalTest.Equals(item, item);
        }

        [Theory]
        [InlineData("Test", 0, 20)]
        public void When_SellIn_Is_Expired_Quality_Decrease_Twice_Fast_To_NormalItem(string name, int sellIn, int quality)
        {
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            var expected = new Item { Name = item.Name, SellIn = item.SellIn, Quality = quality - RangeConditions.DoubleDecreaseQuality };
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }


    }
}