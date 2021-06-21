using GildedRoseRefactoring.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseRefactoring.Models.Normal
{
    class Backstage : ItemWrapper
    {
        public Backstage() : base()
        { }
        public Backstage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }
        public override void Update()
        {
            IncreaseQuality();
            DecreaseSellIn();
            if (SellIn < 0)
            {
                ResetQuality();
            }
        }

        protected override void IncreaseQuality()
        {
            if ((SellIn >= 6) && (SellIn <= 10) && (Quality + 2) <= RangeConditions.QualityValueMax)
            {
                Quality += 2;
            }
            else if ((SellIn <= 5) && ((Quality + 3) <= RangeConditions.QualityValueMax))
            {
                Quality += 3;
            }
            else
            {
                if ((Quality + 1) <= RangeConditions.QualityValueMax)
                {
                    Quality++;
                }
            }
        }
    }
}
