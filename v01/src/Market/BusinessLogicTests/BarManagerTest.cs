using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using DataAccess;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BarManagerTest
    {
        [TestInitialize]
        public void FillTestDataIfEmpty()
        {
            // remove all bar data
            using (var ctx = new MarketDbContext())
            {
                ctx.Set<Bar>().RemoveRange(ctx.Set<Bar>()
                    .Where(c => c.Symbol == "test").ToList());
                ctx.SaveChanges();
            }
            using (var ctx = new MarketDbContext())
            {
                if(ctx.Set<Bar>().Any(c => c.Symbol=="test"))
                {
                    return;
                }
            }

            // fill bar data
            var manager = new BarManager();
            var rnd = new Random();

            for (int i = 0; i <= 30; i++)
            {
                var date = new DateTime(2016, 11, rnd.Next(5) + 1, rnd.Next(12), rnd.Next(59), rnd.Next(59));
                var bar = new Bar
                {
                    Symbol = "test",
                    TimeStamp = date,
                    High = rnd.Next(234) + 0.1f,
                    Close = rnd.Next(23) + 0.1f,
                    Low = rnd.Next(89) + 0.1f,
                    Open = rnd.Next(276) + 0.1f
                };
                manager.Add(bar);
            }
        }

        [TestMethod]
        public void AddRangeTest()
        {
            var range = new[] { new Bar() { Symbol = "ar2", Close = 4, Open = 2, High = 3, Low = 1, TimeStamp = DateTime.UtcNow}, new Bar() { Symbol = "ar2", Close = 4, Open = 2, High = 3, Low = 1, TimeStamp = DateTime.UtcNow.AddSeconds(10) } };
            var man = new BarManager();
            man.AddRange(range);
            Assert.IsTrue(range[0].Id > 0);
            Assert.IsTrue(range[1].Id > 0);
            Assert.AreNotEqual(range[0].Id, range[1].Id);
        }

        [TestMethod]
        public void GetTest()
        {
            var manager = new BarManager();

            var barList = manager.Get("test", new DateTime(2016, 11, 1, 8, 0, 0, DateTimeKind.Utc), new DateTime(2016, 11, 3, 12, 0, 0, DateTimeKind.Utc), Interval.Hour);
            Assert.AreEqual(13,barList.Count);
            Assert.AreEqual(8,barList[0].TimeStamp.Hour);
            Assert.AreEqual(9, barList[1].TimeStamp.Hour);
            Assert.AreEqual(11, barList[2].TimeStamp.Hour);
            Assert.AreEqual(3, barList[3].TimeStamp.Hour);
            
        }

    }
}
