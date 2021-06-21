using System;
using System.Collections.Generic;
using System.Text;
using csharpcore;
using GildedRefactoring.Tests.Helper;
using Xunit;

namespace GildedRefactoring.Tests.LegendaryItemTests
{
    public class Sulfuras
    {

        [Theory]
        [InlineData(ConstantsItem.SULFURAS, 0, 20)]
        public void WhenSulfuras_SellIn_Is_Expired_QualityDefaultIsEighty(string name, int sellIn, int quality)
        {
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            var expected = new Item { Name = item.Name, SellIn = item.SellIn, Quality = 80 };
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }
    }
}
