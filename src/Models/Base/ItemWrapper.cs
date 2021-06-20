using csharpcore;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected virtual int CalculateDecreaseQuality()
        {
            //Quando a data de venda do item tiver passado, a qualidade(quality) do item diminui duas vezes mais rapido.
            //A qualidade(quality) do item não pode ser negativa
            if (VerifySellInIsLassThenZero() && Quality - RangeConditions.DOUBLE_DECREASE_QUALITY >= RangeConditions.QUALITY_VALUE_MIN)
            {
                return RangeConditions.DOUBLE_DECREASE_QUALITY;
            }

            return Quality - 1 >= RangeConditions.QUALITY_VALUE_MIN ? RangeConditions.DEFAULT_DECREASE_QUALITY : 0;
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

        protected bool VerifyQualityValueIsExpired()
        {

            return Quality < RangeConditions.QUALITY_VALUE_MIN;
        }

        protected bool VerifySellInIsLassThenZero()
        {
            return SellIn < RangeConditions.SELLIN_MIN_VALUE;
        }

        protected virtual void ResetQuality()
        {
            Quality = 0;
        }
    }
}
