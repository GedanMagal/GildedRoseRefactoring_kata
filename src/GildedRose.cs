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
                UpdateQualityItem(item);
            }
            return this.Items;
        }

        public static void UpdateQualityItem(Item item)
        {

            switch (item.Name)
            {
                case ConstantsItem.AGED_BRIE:
                    HandleAgedbrieUpdate(item);
                    break;
                case ConstantsItem.BACKSTAGE:
                    HandleBackstageUpdate(item);
                    break;
                case ConstantsItem.SULFURAS:
                    item.Quality = 80;
                    break;
                default:
                    HandleOtherItemUpdate(item);
                    break;
            }
        }

        public static void HandleBackstageUpdate(Item item)
        {
            if (VerifyQualityValueExpired(item))
            {
                IncreaseQuality(item);

                if (item.SellIn <= 10 && VerifyQualityValueExpired(item))
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn <= 5 && VerifyQualityValueExpired(item))
                {
                    IncreaseQuality(item);
                }

            }

            DecreaseSellIn(item);
            if (VerifySellInIsLassThenZero(item))
            {
                ResetQuality(item);
            }
        }

        public static void HandleAgedbrieUpdate(Item item)
        {
            if (VerifyQualityValueExpired(item))
            {
                IncreaseQuality(item);
            }
            DecreaseSellIn(item);

            if (VerifySellInIsLassThenZero(item) && VerifyQualityValueExpired(item))
            {
                IncreaseQuality(item);
            }
        }

        public static void HandleOtherItemUpdate(Item item)
        {
            if (VerifyQualityValueIsGreaterThanMin(item) && !item.Name.Equals(ConstantsItem.SULFURAS))
            {
                DecreaseQuality(item);
            }
            DecreaseSellIn(item);
            if (VerifySellInIsLassThenZero(item))
            {
                if (VerifyQualityValueIsGreaterThanMin(item) && !item.Name.Equals(ConstantsItem.SULFURAS))
                {
                    DecreaseQuality(item);
                }
            }
        }

        public static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        public static void IncreaseQuality(Item item)
        {
            item.Quality++;
        }
        public static void DecreaseQuality(Item item)
        {
            item.Quality--;
        }

        public static void ResetQuality(Item item)
        {
            item.Quality = ConstantsItem.QUALITY_VALUE_MIN;
        }

        public static bool VerifyQualityValueIsGreaterThanMin(Item item)
        {
            return item.Quality > ConstantsItem.QUALITY_VALUE_MIN;
        }

        public static bool VerifyQualityValueExpired(Item item)
        {

            return item.Quality < 50;
        }

        public static bool VerifySellInIsLassThenZero(Item item)
        {
            return item.SellIn < 0;
        }
    }
}
