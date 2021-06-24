using System;
using System.Collections.Generic;
using System.Text;
using GildedRoseRefactoring.Shared.Constants;

namespace GildedRoseRefactoring.Models.Normal
{
    class Conjured : ItemWrapper
    {
        public Conjured() : base()
        {

        }
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void Update()
        {
            DecreaseSellIn();
            IncreaseQuality();
        }
        protected override void DecreaseQuality()
        {
            var valueToDecrease = CalculateDecreaseQuality();
            Quality -= valueToDecrease;
        }

        protected override int CalculateDecreaseQuality()
        {
            var qualityDecreaseDoubleValueMin = Quality - RangeConditions.DoubleDecreaseQuality;

            var isGreaterThanQualityValueMin = qualityDecreaseDoubleValueMin >= RangeConditions.QualityValueMin;
            if (VerifySellInIsLassThenMin() && isGreaterThanQualityValueMin)
            {
                return RangeConditions.DoubleDecreaseQuality * 2;
            }

            return (Quality - 1) >= RangeConditions.QualityValueMin ? RangeConditions.DefaultDecreaseQuality : 0;
        }
    }
}
