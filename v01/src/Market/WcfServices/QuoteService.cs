using System;
using System.Collections.Generic;
using BusinessLogic;
using Model;

namespace WcfServices
{
    public class QuoteService : IQuoteService
    {
        public List<Bar> GetQuotes(string symbol, DateTime from, DateTime to, Interval interval)
        {
            return new BarManager().Get(symbol, from, to, interval);
        }
    }
}