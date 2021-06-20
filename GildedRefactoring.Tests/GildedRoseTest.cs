using Xunit;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Reporters;
using csharpcore;

namespace GildedRefactoring.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GildedRoseTest
    {

        [Fact]
        public void CreationItem()
        {
            var item = CreateItem("foo", 0, 0);
            ApprovalTest.Equals(item, item);
        }


        [Theory]
        [InlineData("Foo", 0, 10)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 12)]
        [InlineData("Aged Brie", 0, 14)]
        public void When_SellIn_Is_Expired_Quality_Decrease_Twice_Fast(string name, int sellIn, int quality)
        {
            var item = UpdateQuality(name, sellIn, quality);
            var expected = new Item {Name = item.Name, SellIn = item.SellIn , Quality = (item.Quality - 2)};
            ApprovalTest.Equals(expected, item);
        }

        private static Item UpdateQuality(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items.First();
        }

        private static Item CreateItem(string name, int sellIn, int quality)
        {
            return new Item { Name = name, SellIn = sellIn, Quality = quality };
        }
    }
}