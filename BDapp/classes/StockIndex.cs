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

        public List<float> getPricesFromBoursier()
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
                    List<float> listOfSeveralPages = new List<float>();
                    foreach (string url in this.Urls)
                    {
                        string htmlPage = HTMLHandler.downloadSourcePage(url);
                        List<float> listOfOnePage = extractFromBoursier(htmlPage);
                        foreach (float value in listOfOnePage)
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

        private List<float> extractFromBoursier(string htmlPage)
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
                string[] splitter = htmlPage.Split(tag);
                for (int i = 1; i <= splitter.Count() - 1; i++)
                {
                    string temp = splitter[i];
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
