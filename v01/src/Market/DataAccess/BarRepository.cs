using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BarRepository : IRepository<Bar>
    {
        private MarketDbContext _context;

        public BarRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(Bar entity)
        {
            _context.Set<Bar>().Add(entity);
        }

        public void Delete(Bar entity)
        {
            _context.Set<Bar>().Remove(entity);
        }

        public IQueryable<Bar> Get()
        {
            return _context.Set<Bar>().AsNoTracking();
        }

        public void Update(Bar entity)
        {
            _context.Set<Bar>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
