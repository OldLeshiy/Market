using System;
using System.Collections.Generic;
using BusinessLogic;
using Model;

namespace WcfServices
{
    public class SymbolService : ISymbolService
    {
        public Symbol Get(string name)
        {
            return new SymbolManager().Get(name);
        }

        public List<Symbol> GetSymbols()
        {
            return new SymbolManager().GetSymbols();
        }
    }
}