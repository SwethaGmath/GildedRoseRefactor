using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItem()
        {
            //for (var i = 0; i < Items.Count; i++)
            foreach(Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;
                else
                {
                    UpdateQuality(item);

                    //decrement the sell in with each passing day
                    item.SellIn--;
                    UpdateQualityFurther(item);

                }

                //if (item.Name != "Sulfuras, Hand of Ragnaros")
                //{
                //    //Decrease sell in for everything except sulfuras
                //    item.SellIn -= 1;
                //}

                //if (item.SellIn < 0)
                //{
                //    if (item.Name == "Aged Brie")
                //    {
                //        if (item.Quality < 50)
                //        {
                //            item.Quality += 1;
                //        }
                //    }
                //    else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                //    {
                //            if (item.Quality < 50)
                //            {
                //                item.Quality -= item.Quality;
                //            }
                //    }
                //    else
                //    {
                //        if (item.Quality > 0)
                //        {
                //            if (item.Name != "Sulfuras, Hand of Ragnaros")
                //            {
                //                item.Quality -= 1;
                //            }
                //        }
                //    }

                //}
            }
        }

        private static void UpdateQualityFurther(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality -= item.Quality;

                }
                else if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }

            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                // Updating the quality as per requirements
                if (item.Quality < 50)
                {
                    //increase quality by one for aged brie
                    item.Quality += 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn <= 10)
                        {
                            if (item.Quality < 50)
                            {
                                //Increase quality by one more for Backstage (+2)
                                item.Quality += 1;
                            }
                        }
                        if (item.SellIn <= 5)
                        {
                            if (item.Quality < 50)
                            {
                                //Increase quality once more for backstage( +3)
                                item.Quality += 1;
                            }
                        }
                        if (item.SellIn < 0)
                        {
                            //quality drops to zero
                            item.Quality -= item.Quality;
                        }
                    }
                }
            }
            //conjoured items degrade twice as fast as normal items
            else if (item.Name == "Conjured Mana Cake")
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 2;
                }
            }
            else if (item.Quality > 0)
            {
                //For all the other items except Sulfuras decrease quality by one
                item.Quality -= 1;
            }
        }
    }
}
