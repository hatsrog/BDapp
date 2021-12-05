using BDapp.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDapp.classes
{
    public  class StockIndex
    {
        private string IndexName;
        private string Url;
        private string[] Urls;
        private Stock[] Stocks;

        public StockIndex(string indexName, string url, Stock[] stock)
        {
            this.IndexName = indexName;
            this.Url = url;
            this.Stocks = stock;
        }

        public StockIndex(string indexName, string url)
        {
            this.IndexName = indexName;
            this.Url = url;
        }

        public StockIndex(string indexName, string[] urls)
        {
            this.IndexName = indexName;
            this.Urls = urls;
        }

        public List<Stock> getPricesFromBoursier()
        {
            try
            {
                if (this.Url != null)
                {
                    string htmlPage = HTMLHandler.downloadSourcePage(this.Url);
                    return extractFromBoursier(htmlPage);
                }
                else if (this.Urls != null)
                {
                    List<Stock> listOfSeveralPages = new List<Stock>();
                    foreach (string url in this.Urls)
                    {
                        string htmlPage = HTMLHandler.downloadSourcePage(url);
                        List<Stock> listOfOnePage = extractFromBoursier(htmlPage);
                        foreach (Stock value in listOfOnePage)
                        {
                            listOfSeveralPages.Add(value);
                        }
                    }
                    return listOfSeveralPages;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return getPricesFromBoursier();
            }
        }

        private List<Stock> extractFromBoursier(string htmlPage)
        {
            try
            {
                List<Stock> arrStocks = new List<Stock>();
                string tag = "<tbody>";
                htmlPage = htmlPage.Split(tag)[1];
                tag = "</tbody>";
                htmlPage = htmlPage.Split(tag)[0];

                List<char> charsToRemove = new List<char>() { '\n', '\t', '\r', ' '};
                foreach (char c in charsToRemove)
                {
                    htmlPage = htmlPage.Replace(c.ToString(), String.Empty);
                }

                // Name
                tag = "name--wrapper";
                string[] splitterName = htmlPage.Split("name--wrapper");

                // Price
                tag = "<tr>";
                string[] splitterPrice = htmlPage.Split(tag);
                for (int i = 1; i <= splitterPrice.Count() - 1; i++)
                {
                    string temp = splitterPrice[i];
                    temp = temp.Split("</a></td><tdclass=\"tr\">")[1];
                    string tempPrice = temp.Split("€</td>")[0];

                    temp = splitterName[i];
                    temp = temp.Split(">")[1];
                    string tempName = temp.Split("</a")[0];

                    Stock oStock = new Stock(null, 0f);
                    oStock._StockPrice = float.Parse(tempPrice);
                    oStock._StockName = tempName;
                    arrStocks.Add(oStock);
                }

                return arrStocks;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
