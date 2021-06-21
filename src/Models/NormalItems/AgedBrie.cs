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
            DecreaseSellIn();
            IncreaseQuality();
        }

        protected override void IncreaseQuality()
        {
            int valueIncrement = CalculateValueToIncreaseQuality();

            Quality += valueIncrement;
        }

        private int CalculateValueToIncreaseQuality()
        {
            var condition = (Quality + 2) <= RangeConditions.QualityValueMax;

            if (VerifySellInIsLassThenMin() && condition) return 2;
            return Quality + 1 <= RangeConditions.QualityValueMax ? RangeConditions.DefaultIncreaseQuality : 0;
        }
    }
}
