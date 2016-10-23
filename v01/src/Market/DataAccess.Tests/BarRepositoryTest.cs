using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Model;
using System.Linq;
using System.Data.Entity.Validation;

namespace DataAccess.Tests
{
    [TestClass]
    public class BarRepositoryTests
    {
        [TestMethod]
        public void ConstructorBarTest()
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new BarRepository(ctx);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddInvalidBarPriceTest()
        {
            using (var ctx = new MarketDbContext())
            {
                var date = DateTime.UtcNow;
                var repository = new BarRepository(ctx);
                var bar = new Bar()
                {
                    Symbol = "test",
                    TimeStamp = date,
                };
                repository.Add(bar);
                ctx.SaveChanges();
            }
        }

        [TestMethod]
        public void AddBarTest()
        {
            using (var ctx = new MarketDbContext())
            {
                var date = DateTime.UtcNow;
                var repository = new BarRepository(ctx);
                var bar = new Bar()
                {
                    Symbol = "test",
                    TimeStamp = date,
                    High = 1,
                    Close = 2,
                    Low = 3,
                    Open = 4
                };
                repository.Add(bar);

                ctx.SaveChanges();

                var id = bar.Id;
                Assert.IsTrue(bar.Id > 0);

                var addedBarFromDb = repository.Get().FirstOrDefault(c => c.Id == id);

                Assert.IsNotNull(addedBarFromDb);
                Assert.AreEqual("test", addedBarFromDb.Symbol);
                Assert.AreEqual(date, addedBarFromDb.TimeStamp);
            }
        }
    }
}
