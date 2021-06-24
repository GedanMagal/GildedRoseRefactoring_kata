using csharpcore;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Shared.Constants;

namespace GildedRoseRefactoring.Models
{
    public class ItemWrapper : Item, IItemWrapper
    {

        protected ItemWrapper()
        { }

        public ItemWrapper(string nome, int sellIn, int quality) : base()
        {
            Name = nome;
            SellIn = sellIn;
            Quality = quality;
        }


        public virtual void Update()
        {
            DecreaseSellIn();
            DecreaseQuality();
        }

        protected void DecreaseSellIn()
        {
            SellIn--;
        }

        protected virtual void IncreaseQuality()
        {
            Quality++;
        }
        protected virtual void DecreaseQuality()
        {
            var valueToDecrease = CalculateDecreaseQuality();
            Quality -= valueToDecrease;
        }

        protected virtual int CalculateDecreaseQuality()
        {
            var qualityDecreaseDoubleValueMin = Quality - RangeConditions.DoubleDecreaseQuality;
            var isGreaterThanQualityValueMin = qualityDecreaseDoubleValueMin >= RangeConditions.QualityValueMin;
            if (VerifySellInIsLassThenMin() && isGreaterThanQualityValueMin)
            {
                return RangeConditions.DoubleDecreaseQuality;
            }

            return (Quality - 1) >= RangeConditions.QualityValueMin ? RangeConditions.DefaultDecreaseQuality : 0;
        }

        protected bool VerifyQualityValueIsZero()
        {

            return Quality == RangeConditions.QualityValueMin;
        }

        protected bool VerifyQualityValueIsLassThenMax()
        {

            return Quality < RangeConditions.QualityValueMin;
        }

        protected bool VerifySellInIsLassThenMin()
        {
            return SellIn < RangeConditions.SellInMinValue;
        }

        protected virtual void ResetQuality()
        {
            Quality = 0;
        }


    }
}
