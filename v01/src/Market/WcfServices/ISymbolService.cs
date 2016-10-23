using System.Collections.Generic;
using System.ServiceModel;
using Model;

namespace WcfServices
{
    [ServiceContract]
    public interface ISymbolService
    {
        [OperationContract]
        List<Symbol> GetSymbols();

        [OperationContract]
        Symbol Get(string name);
    }
}