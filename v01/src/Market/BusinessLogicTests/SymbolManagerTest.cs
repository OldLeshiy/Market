using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class SymbolManagerTest
    {
        [TestInitialize]
        public void FillTestDataIfEmpty()
        {
            var manager = new SymbolManager();
            if (manager.GetSymbols().Count > 0)
            {
                return;
            }

            var names = new[]
            {
                "usd/jpy",
                "eur/jpy",
                "rur/jpy",
                "usd/eur",
                "lat/usd",
                "cad/jpy",
                "aud/jpy",
                "gbp/chf",
                "chf/usd",
                "eur/chf"
            };
            for (var i = 1; i <= 10; i++)
            {
                var symbol = new Symbol
                {
                    Name = names[i - 1],
                    Spread = (float)i / 10
                };
                manager.Add(symbol);
            }
        }

        [TestMethod]
        public void GetTest()
        {
            var manager = new SymbolManager();

            var returnSymbol = manager.Get("eur/jpy");
            Assert.IsNotNull(returnSymbol);
            Assert.AreEqual("eur/jpy", returnSymbol.Name);

        }
    }
}