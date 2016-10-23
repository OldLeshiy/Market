using System;
using System.Collections.Generic;
using System.ServiceModel;
using Model;

namespace WcfServices
{
    [ServiceContract]
    public interface IQuoteService
    {
        [OperationContract]
        List<Bar> GetQuotes(string symbol, DateTime from, DateTime to, Interval interval);
    }
}