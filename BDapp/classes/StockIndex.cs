using BDapp.utilities;
using BDapp_Core.Enums;

namespace BDapp.classes
{
    public class StockIndex
    {
        private readonly string Url = string.Empty;
        private readonly string[] Urls = Array.Empty<string>();

        public StockIndex()
        {
        }

        public StockIndex(string url)
        {
            if(url.Contains("||"))
            {
                Urls = url.Split("||");
            }
            else
            {
                Url = url;
            }
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
                case "CAC":
                    return Indice.CAC40;
                case "SBF120":
                case "SBF":
                    return Indice.SBF120;
                case "NASDAQ100":
                    return Indice.NASDAQ100;
                default:
                    return Indice.UNKNOWN;

            }
        }

        public List<Stock>? GetStocksFromBoursier()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Url))
                {
                    var htmlPage = HTMLHandler.DownloadSourcePage(Url);
                    return ExtractFromBoursier(htmlPage.Result);
                }
                else if (Urls.Length > 0)
                {
                    var listOfSeveralPages = new List<Stock>();
                    foreach (string url in Urls)
                    {
                        var htmlPage = HTMLHandler.DownloadSourcePage(url);
                        List<Stock> listOfOnePage = ExtractFromBoursier(htmlPage.Result);
                        foreach (Stock value in listOfOnePage)
                        {
                            listOfSeveralPages.Add(value);
                        }
                    }
                    return listOfSeveralPages;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return GetStocksFromBoursier();
            }
        }

        private string ExtractCurrency(string raw)
        {
            if(raw.Contains("€"))
            {
                return "€";
            }
            else if(raw.Contains("$"))
            {
                return "$";
            }
            return string.Empty;
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
                htmlPage = htmlPage.Replace(c.ToString(), string.Empty);
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
                var tempPrice = temp.Split($"{ExtractCurrency(temp)}</td>")[0];

                temp = splitterName[i];
                temp = temp.Split(">")[1];
                var tempName = temp.Split("</a")[0];

                var oStock = new Stock(string.Empty, 0f);
                float.TryParse(tempPrice, out float priceParser);
                oStock._StockPrice = priceParser;
                oStock._StockName = tempName;
                arrStocks.Add(oStock);
            }

            return arrStocks;
        }
    }
}
