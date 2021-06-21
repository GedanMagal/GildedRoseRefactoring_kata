using System;
using System.Collections.Generic;
using csharpcore;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Models;
using GildedRoseRefactoring.Models.Normal;
using src.Models.NormalItems;

namespace GildedRoseRefactoring.Factory
{
    public abstract class ItemWrapperFactory
    {

        public static void UpdateQuality(Item item)
        {
            var concrete = ItemWrapperFactory.CreateItemFactory(item);
            concrete.Update();
            UpdateItem(item, concrete);
        }

        private static ItemWrapper CreateItemFactory(Item item)
        {
            switch (item.Name)
            {
                case ConstantsItem.AGED_BRIE:
                    return new AgedBrie(item.Name, item.SellIn, item.Quality);
                case ConstantsItem.BACKSTAGE:
                    return new Backstage(item.Name, item.SellIn, item.Quality);
                case ConstantsItem.SULFURAS:
                    return new Sulfuras(item.Name, item.SellIn, item.Quality);
                default:
                    return new Any(item.Name, item.SellIn, item.Quality);
            }
        }

        private static void UpdateItem(Item item, Item changed)
        {
            item.Name = changed.Name;
            item.Quality = changed.Quality;
            item.SellIn = changed.SellIn;
        }

    }
}
