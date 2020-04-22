using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class UpdateStrategyFactory
    {
        public static IUpdateStrategy Create(Item item)
        {
            if (item.Name.Contains("Sulfuras"))
            {
                //return null;
               return new SulfurasUpdateStrategy();
            }
            else if (item.Name.Contains("Aged Brie"))
            {
                //return null;
                return new AgedBrieUpdateStrategy();
            }
            else if (item.Name.Contains("Backstage pass"))
            {
                //return null;
                return new BackstagePassesUpdateStrategy();
            }
            else if (item.Name.Contains("Conjured"))
            {
                //return null;
                return new ConjuredUpdateStrategy();
            }
            else
            {
                return new StandardUpdateStrategy();
            }
        }
    }
}
