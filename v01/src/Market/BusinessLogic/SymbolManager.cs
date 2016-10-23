using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Model;

namespace BusinessLogic
{
    public class SymbolManager
    {
        public void Add(Symbol symbol)
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new SymbolRepository(ctx);
                repository.Add(symbol);
                ctx.SaveChanges();
            }
        }

        public List<Symbol> GetSymbols()
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new SymbolRepository(ctx);
                return repository.Get().ToList();
            }
        }

        public Symbol Get(string name)
        {
            Symbol symbol;
            using (var ctx = new MarketDbContext())
            {
                var repository = new SymbolRepository(ctx);
                symbol = repository.Get().SingleOrDefault(c => c.Name == name);
            }
            return symbol;
        }
    }
}
