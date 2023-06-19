using BDapp.utilities;
using BDapp_Core.Enums;

namespace BDapp.classes
{
    public class StockIndex
    {
        private readonly string Url;
        private readonly string[] Urls;

        public StockIndex()
        {
        }

        public StockIndex(string url)
        {
            Url = url;
        }

        public StockIndex(string[] urls)
        {
            Urls = urls;
        }

        public static string GetIndiceValue(string indice)
        {
            switch (indice.ToUpper())
            {
                case "CAC40":
                    return Indice.CAC40;
                case "SBF120":
                    return Indice.SBF120;
                default:
                    return Indice.UNKNOWN;

            }
        }

        public List<Stock>? GetStocksFromBoursier()
        {
            try
            {
                if (Url != null)
                {
                    string htmlPage = HTMLHandler.DownloadSourcePage(this.Url);
                    return ExtractFromBoursier(htmlPage);
                }
                else if (Urls != null)
                {
                    var listOfSeveralPages = new List<Stock>();
                    foreach (string url in Urls)
                    {
                        string htmlPage = HTMLHandler.DownloadSourcePage(url);
                        List<Stock> listOfOnePage = ExtractFromBoursier(htmlPage);
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
            catch (Exception)
            {
                return GetStocksFromBoursier();
            }
        }

        private List<Stock> ExtractFromBoursier(string htmlPage)
        {
            var arrStocks = new List<Stock>();
            var tag = "<tbody>";
            htmlPage = htmlPage.Split(tag)[1];
            tag = "</tbody>";
            htmlPage = htmlPage.Split(tag)[0];

            var charsToRemove = new List<char>() { '\n', '\t', '\r', ' ' };
            foreach (char c in charsToRemove)
            {
                htmlPage = htmlPage.Replace(c.ToString(), String.Empty);
            }

            // Name
            var splitterName = htmlPage.Split("name--wrapper");

            // Price
            tag = "<tr>";
            var splitterPrice = htmlPage.Split(tag);
            for (int i = 1; i <= splitterPrice.Count() - 1; i++)
            {
                var temp = splitterPrice[i];
                temp = temp.Split("</a></td><tdclass=\"tr\">")[1];
                var tempPrice = temp.Split("€</td>")[0];

                temp = splitterName[i];
                temp = temp.Split(">")[1];
                var tempName = temp.Split("</a")[0];

                var oStock = new Stock(null, 0f);
                oStock._StockPrice = float.Parse(tempPrice);
                oStock._StockName = tempName;
                arrStocks.Add(oStock);
            }

            return arrStocks;
        }
    }
}
