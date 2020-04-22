using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class StandardItems
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            //Assert.AreEqual("foo", Items[0].Name);
            Assert.That(Items[0].Name, Is.EqualTo("foo"));
        }

        [Test]
        public void decrement_SellIn()
        {
            Item item = new Item { Name = "foo", SellIn = 1, Quality = 10 }.updateQuality();
            //GildedRose app = new GildedRose(items);
            //app.UpdateQuality();
            Assert.AreEqual(0, item.SellIn);
        }
        [Test]
        public void decrement_quality()
        {
            Item item = new Item { Name = "standard item", SellIn = 1, Quality = 10 }.updateQuality();
            Assert.AreEqual(9, item.Quality);
        }

        [Test]
        public void quality_should_decrement_twice_once_sellin_passed()
        {
            Item item = new Item { Name = "standard item", SellIn = 0, Quality = 10 }.updateQuality();
            //IList<Item> items = new List<Item> { item };
            //GildedRose app = new GildedRose(items);
            //app.UpdateQuality();
            Assert.AreEqual(8, item.Quality);

        }

        [Test]
        public void quality_should_not_be_negative()
        {
            Item item = new Item { Name = "foo", SellIn = 0, Quality = 0 }.updateQuality();
            Assert.AreEqual(0, item.Quality);

        }

    }
    [TestFixture]
    public class LegendaryItems
    {
        [Test]
        public void it_should_not_decrease_quality()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 10 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(10));
        }
        [Test]
        public void should_not_decrese_sell_in()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 10 }.updateQuality();
            Assert.That(item.SellIn, Is.EqualTo(1));
        }
    }
    [TestFixture]
    public class SpecialItems
    {
        [Test]
        public void should_increase_quality()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 40 }.updateQuality();
            Assert.That(item.SellIn, Is.EqualTo(0));
            Assert.That(item.Quality, Is.EqualTo(41));
        }
        [Test]
        public void quality_should_increase_when_sellin_zero()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 40 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(41));
        }

        [Test]
        public void quality_should_not_be_grater_than_fifty()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(50));
        }
        [Test]
        public void quality_increases_by_one_when_sellin_greater_than_ten()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 40 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(41));
        }
        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]

        [Test]
        public void quality_doubles_when_sellin_less_than_eleven(int daysLeft)
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = daysLeft, Quality = 40 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(42));
        }
        [Test]
        public void quality_increases_by_three_when_selln_less_than_six()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 40 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(43));
        }
        [Test]
        public void quality_drops_to_zero_when_selln_is_zero()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(0));
        }
    }
    [TestFixture]
    public class ConjouredItems
    {
        [Test]
        public void should_degrade_twice_as_fast_as_normal_item()
        {
            Item item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 }.updateQuality();
            Assert.That(item.Quality, Is.EqualTo(8));
        }
    }


    public static class Helper
    {
        public static Item updateQuality(this Item item)
        {
            IList<Item> items = new List<Item> { item };
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            return item;

        }
    }

}

