using GildedRoseRefactoring.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseRefactoring.Models.Normal
{
    class AgedBrie : ItemWrapper
    {
        public AgedBrie() : base()
        {

        }
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Update()
        {
            DecreaseQuality();
            IncreaseQuality();

            if (VerifySellInIsLassThenZero())
            {
                ResetQuality();
            }

        }

        protected override void IncreaseQuality()
        {
            Quality = (SellIn < RangeConditions.SELLIN_MIN_VALUE) ? RangeConditions.DEFAULT_INCREASE_QUALITY : Quality + CalculateValueToIncreaseQuality();
        }

        private int CalculateValueToIncreaseQuality()
        {

            if (SellIn <= RangeConditions.DEADLINE_TO_INCREASE_TWO && (Quality + 2) > RangeConditions.QUALITY_MAX_VALUE) return 2;
            //if (SellIn <= RangeConditions.DEADLINE_TO_INCREASE_THREE && VerifyQualityValueIsExpired() && VerifyQualityValueIsExpired()) return 3;
            if (SellIn <= RangeConditions.DEADLINE_TO_INCREASE_THREE && (Quality + 3) > RangeConditions.QUALITY_MAX_VALUE) return 3;

            return RangeConditions.DEFAULT_INCREASE_QUALITY;
        }

    }
}
