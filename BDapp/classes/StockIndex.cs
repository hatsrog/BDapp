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
        private Stock Stocks;

        public StockIndex(string indexName, string url, Stock stock)
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

        public List<float> getPricesFromBoursier()
        {
            try
            {
                string htmlPage = HTMLHandler.downloadSourcePage(this.Url);
                return extractFromBouriser(htmlPage);
            }
            catch (Exception ex)
            {
                return getPricesFromBoursier();
            }
        }

        private List<float> extractFromBouriser(string htmlPage)
        {
            try
            {
                List<float> dicCac40 = new List<float>();
                string tag = "<tbody>";
                htmlPage = htmlPage.Split(tag)[1];
                tag = "</tbody>";
                htmlPage = htmlPage.Split(tag)[0];

                List<char> charsToRemove = new List<char>() { '\n', '\t', '\r', ' ' };
                foreach (char c in charsToRemove)
                {
                    htmlPage = htmlPage.Replace(c.ToString(), String.Empty);
                }

                tag = "<tr>";
                for (int i = 1; i <= 40; i++)
                {
                    string temp = htmlPage.Split(tag)[i];
                    temp = temp.Split("</a></td><tdclass=\"tr\">")[1];
                    temp = temp.Split("€</td>")[0];
                    dicCac40.Add(float.Parse(temp));
                }

                return dicCac40;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
