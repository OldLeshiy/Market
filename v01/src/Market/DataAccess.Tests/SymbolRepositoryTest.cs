using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;
using System.Data.Entity.Validation;

namespace DataAccess.Tests
{
    [TestClass]
    public class SymbolRepositoryTest
    {
        [TestMethod]
        public void ConstructorSymbolTest()
        {
            using (var ctx= new MarketDbContext())
            {
                var repository = new SymbolRepository(ctx);
            }
        }
        [TestMethod]
        public void AddSymbolTest()
        {
            using (var ctx = new MarketDbContext())
            {
                SymbolRepository repository = new SymbolRepository(ctx);
                Symbol symbol = new Symbol() { Name = "usd", Spread = 0.211f};
                repository.Add(symbol);
                ctx.SaveChanges();

                var id = symbol.Id;
                
                Assert.IsTrue(id > 0);
                
                var symbolFromDb = repository.Get().FirstOrDefault(s => s.Id == id);

                Assert.IsNotNull(symbolFromDb);
                Assert.AreEqual("usd",symbolFromDb.Name);
                Assert.AreEqual(0.211f, symbolFromDb.Spread);
            }
        }

        [TestMethod]
        public void UpdateSymbolTest()
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new SymbolRepository(ctx);
                var symbol = new Symbol(){Name = "usd",Spread = 0.211f};
                repository.Add(symbol);
                ctx.SaveChanges();
               
                var id = symbol.Id;
                
                symbol.Name = "eur";
                symbol.Spread = 0.6f;
                repository.Update(symbol);
                ctx.SaveChanges();
                
                var symbolFromDb = repository.Get().FirstOrDefault(s => s.Id == id);

                Assert.IsNotNull(symbolFromDb);
                Assert.AreEqual(id, symbolFromDb.Id);
                Assert.AreNotEqual("usd", symbolFromDb.Name);
                Assert.AreNotEqual(0.211f, symbolFromDb.Spread);
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddEmptySymbolMustThrowValidationExceptionTest()
        {
            using (var ctx = new MarketDbContext())
            {
                SymbolRepository repository = new SymbolRepository(ctx);
                Symbol symbol = new Symbol() { Name = "", Spread = 0.211f };
                repository.Add(symbol);
                ctx.SaveChanges();

                Symbol symbol1 = new Symbol() { Name = "usd", Spread = 0.0f };
                repository.Add(symbol1);
                ctx.SaveChanges();

            }
        }
    }
}
