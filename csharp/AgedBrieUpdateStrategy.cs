namespace csharp
{
    internal class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                //increase quality by one for aged brie
                item.Quality += 1;
            }
            item.SellIn -= 1;
        }
    }
}