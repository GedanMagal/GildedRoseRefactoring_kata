using System;
using System.Collections.Generic;
using System.Text;
using csharpcore;
using GildedRefactoring.Tests.Helper;
using Xunit;

namespace GildedRefactoring.Tests.NormalItemTests
{
    public class AgedBrieItemTests
    {

        [Theory]
        [InlineData(ConstantsItem.AGED_BRIE, -1, 0)]
        [InlineData(ConstantsItem.AGED_BRIE, 0, 0)]
        public void WhenAgedBrie_SellIn_LassThanZero_Quality_IncludeDouble(string name, int sellIn, int quality)
        {
            Item expected = new Item { Name = name, SellIn = sellIn - 1, Quality = 2 };
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }
    }
}
