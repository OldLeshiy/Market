using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;

namespace DataAccess.Tests
{
    [TestClass]
    public class MarketDbContextTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var ctx = new MarketDbContext();
        }


    }
}
