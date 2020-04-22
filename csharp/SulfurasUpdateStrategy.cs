namespace csharp
{
    internal class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            //Do nothing for legendary item
            item.Quality = item.Quality;
            item.SellIn = item.SellIn;
        }
    }
}