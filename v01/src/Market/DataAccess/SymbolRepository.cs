using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Model;


namespace DataAccess
{
    public class SymbolRepository : IRepository<Symbol>
    {
        private MarketDbContext _context;
        
        public SymbolRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(Symbol entity)
        {
            _context.Set<Symbol>().Add(entity);
        }

        public void Delete(Symbol entity)
        {
            _context.Set<Symbol>().Remove(entity);
        }

        public void Update(Symbol entity)
        {
            _context.Set<Symbol>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<Symbol> Get()
        {
            return _context.Set<Symbol>().AsNoTracking();
        }
    }
}
