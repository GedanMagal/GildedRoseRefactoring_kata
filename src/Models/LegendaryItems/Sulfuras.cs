using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseRefactoring.Models.Normal
{
    class Sulfuras : ItemWrapper
    {

        public Sulfuras() : base()
        { }
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            this.Quality = 80;
        }
        public override void Update()
        { }
    }
}
