using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MarketDbContext : DbContext, IUnitOfWork
    {
        static MarketDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MarketDbContext>());
        }

        public MarketDbContext() : this("MarketDbConnectionString")
        {
        }

        public MarketDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.Initialize(false);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Configuration.ValidateOnSaveEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bar>();
            modelBuilder.Entity<Symbol>();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
