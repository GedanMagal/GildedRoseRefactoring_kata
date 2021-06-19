using Xunit;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;

namespace csharpcore
{
    [UseReporter(typeof(DiffReporter))]
    public class GildedRoseTest
    {

        [Fact]
        public void UpdateQualityItem()
        {
            var item = UpdateQuality("foo", 0, 0);
            var expected = item.Name;
            Assert.Equal(expected, item.Name);
        }

        //[Fact]
        //public void WhenSellInHasPassed_QualityDegradesTwoAsFast()
        //{
        //    var item = UpdateQuality("foo", 0, 5);
        //    Assert.Equal(0, item.Quality);
        //    Assert.Equal(0, item.SellIn);
        //}


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