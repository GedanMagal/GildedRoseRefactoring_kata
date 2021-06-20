using GildedRoseRefactoring.Factory;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public IList<Item> UpdateQuality()
        {
            foreach (Item item in Items)
            {
                var concreteItem = ItemWrapperFactory.CreateItemFactory(item.Name);
                concreteItem.Update();
                //UpdateQualityItem(item);
            }
            return Items;
        }
    }
}
