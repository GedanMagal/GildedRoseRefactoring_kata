using csharpcore;
using GildedRoseRefactoring.Interface;
using GildedRoseRefactoring.Models;
using GildedRoseRefactoring.Models.Normal;
using src.Models.NormalItems;

namespace GildedRoseRefactoring.Factory
{
    public abstract class ItemWrapperFactory
    {
        public abstract ItemWrapper GetItem(string name);

        public static IItemWrapper CreateItemFactory(string name)
        {
            switch (name)
            {
                case ConstantsItem.AGED_BRIE:
                    return new AgedBrie();
                case ConstantsItem.BACKSTAGE:
                    return new Backstage();
                default:
                    return new Any();
            }
        }
    }
}
