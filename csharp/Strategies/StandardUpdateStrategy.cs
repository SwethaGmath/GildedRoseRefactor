namespace csharp
{
    internal class StandardUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
            // Decrease SellIn Date
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}