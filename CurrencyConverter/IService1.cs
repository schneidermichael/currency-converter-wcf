using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CurrencyConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        ListOfCurrencies CurrenciesList();

        [OperationContract]
        CurrencyItem CurrencyPerCode(string currencyCode);

    }

    [DataContract]
    public class ListOfCurrencies
    {
        private List<CurrencyItem> currencyItems;

        [DataMember]
        public List<CurrencyItem> CurrencyItems
        {
            get
            {
                if (currencyItems == null)
                {
                    currencyItems = new List<CurrencyItem>();
                }
                return currencyItems;
            }
        }
    }



    [DataContract]
    public class CurrencyItem
    {
        private string symbol;
        private double rate;

        [DataMember]
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        [DataMember]
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }


    }


}
