using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharpcore;

namespace GildedRefactoring.Tests.Helper
{
    public abstract class SharedFunctions
    {

        public  static Item UpdateQuality(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items.First();
        }

        public static Item CreateItem(string name, int sellIn, int quality)
        {
            return new Item { Name = name, SellIn = sellIn, Quality = quality };
        }
    }
}
