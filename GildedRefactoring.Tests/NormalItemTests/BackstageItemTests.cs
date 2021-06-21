using System;
using System.Collections.Generic;
using System.Text;
using csharpcore;
using GildedRefactoring.Tests.Helper;
using GildedRoseRefactoring.Shared.Constants;
using Xunit;

namespace GildedRefactoring.Tests.NormalItemTests
{
    public class BackstageItemTests
    {


        [Theory]
        [InlineData(ConstantsItem.BACKSTAGE, 11, 24)]
        public void WhenBackstage_SellIn_EqualOrLassThenFive_Quality_Include(string name, int sellIn, int quality)
        {
            Item expected = new Item { Name = name, SellIn = sellIn - 1, Quality = quality + 1 };
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }

        [Theory]
        [InlineData(ConstantsItem.BACKSTAGE, 4, 47)]
        public void WhenBackstage_SellIn_EqualOrLassThenFive_Quality_IncludeTriple(string name, int sellIn, int quality)
        {
            Item expected = new Item { Name = name, SellIn = sellIn - 1, Quality = quality + 3 };
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }

        [Theory]
        [InlineData(ConstantsItem.BACKSTAGE, 10, 25)]
        public void WhenBackstage_SellIn_EqualOrLassThenTen_Quality_IncludeDouble(string name, int sellIn, int quality)
        {
            Item expected = new Item { Name = name, SellIn = sellIn - 1, Quality = quality + 2 };
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }

        [Theory]
        [InlineData(ConstantsItem.BACKSTAGE, 0, 0)]
        public void WhenBackstage_SellIn_Is_Expired_Quality_Reset(string name, int sellIn, int quality)
        {
            Item expected = new Item { Name = name, SellIn = sellIn - 1, Quality = RangeConditions.QualityValueMin };
            var item = SharedFunctions.UpdateQuality(name, sellIn, quality);
            Assert.Equal(expected.Name, item.Name);
            Assert.Equal(expected.Quality, item.Quality);
            Assert.Equal(expected.SellIn, item.SellIn);
        }
    }
}
