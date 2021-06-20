using GildedRoseRefactoring.Models;

namespace src.Models.NormalItems
{
    public class Any : ItemWrapper
    {
        public Any() : base()
        { }

        public Any(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }
    }
}