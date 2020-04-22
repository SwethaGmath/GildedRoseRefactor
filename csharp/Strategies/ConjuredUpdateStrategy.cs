namespace csharp
{
    internal class ConjuredUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 2;
                }
            }
            
        }
    }
}