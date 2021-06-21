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
            var isUnderQualityValueMin = qualityDecreaseDoubleValueMin >= RangeConditions.QualityValueMin;
            if (VerifySellInIsLassThenMin() && isUnderQualityValueMin)
            {
                return RangeConditions.DoubleDecreaseQuality;
            }

            return (Quality - 1) >= RangeConditions.QualityValueMin ? RangeConditions.DefaultDecreaseQuality : 0;
        }
    }
}
