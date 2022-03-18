using System;
using System.Xml;

namespace CurrencyConverter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public ListOfCurrencies CurrenciesList()
        {
            return Data();
        }

        public CurrencyItem CurrencyPerCode(string currencyCode)
        {
            ListOfCurrencies listOfCurrencies = Data();
            CurrencyItem currencyItem = new CurrencyItem();

            for (int i = 0; i < listOfCurrencies.CurrencyItems.Count; i++)
            {
                if (listOfCurrencies.CurrencyItems[i].Symbol == currencyCode)
                {
                    currencyItem = listOfCurrencies.CurrencyItems[i];
                }
            }
            return currencyItem;
        }

        public static ListOfCurrencies Data()
        {
            ListOfCurrencies listOfCurrencies = new ListOfCurrencies();
            
            XmlReader xmlReader = XmlReader.Create("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            while(xmlReader.Read())
            {
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
                {
                    if (xmlReader.HasAttributes)
                        if(xmlReader.GetAttribute("currency") != null && xmlReader.GetAttribute("rate") != null)
                        {
                            CurrencyItem currencyItem = new CurrencyItem();
                            currencyItem.Symbol = xmlReader.GetAttribute("currency");
                            currencyItem.Rate = Convert.ToDouble(xmlReader.GetAttribute("rate"),System.Globalization.CultureInfo.InvariantCulture);
                            listOfCurrencies.CurrencyItems.Add(currencyItem);
                        }     
                }
            }
            return listOfCurrencies;
        }
    }

}
