using GildedRoseRefactoring.Factory;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Models;
using GildedRoseRefactoring.Shared.Constants;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                ItemWrapperFactory.UpdateQuality(item);
            }
        }
    }
}
