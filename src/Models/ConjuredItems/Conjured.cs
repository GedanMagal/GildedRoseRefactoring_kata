using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseRefactoring.Models.Normal
{
    class Conjured : ItemWrapper
    {
        public Conjured() : base()
        {

        }
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }
    }
}
