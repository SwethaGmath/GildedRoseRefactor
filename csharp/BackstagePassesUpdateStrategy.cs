namespace csharp
{
    internal class BackstagePassesUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            //throw new System.NotImplementedException();
            if (item.Quality < 50)
            {
                item.Quality += 1;
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
            }
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                //quality drops to zero
                item.Quality -= item.Quality;
            }
        }
    }
}