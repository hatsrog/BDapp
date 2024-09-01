using BDapp.utilities;

namespace BDapp.classes
{
    public class StockInfo
    {
        private string StockName;
        private string Url = string.Empty;
        private float Price;
        
        public StockInfo(string stockName, string url)
        {
            StockName = stockName;
            Url = url;
        }

        public StockInfo(string stockName, float price)
        {
            StockName = stockName;
            Price = price;
        }

        public string _StockName
        {
            get
                { return StockName; }
            set
                { StockName = value; }
        }

        public float _StockPrice
        {
            get
                { return Price; }
            set 
                { Price = value; }
        }

        public float getPrice()
        {
            try
            {
                if (_StockPrice == 0)
                {
                    var htmlPage = HTMLHandler.DownloadSourcePage(Url);
                    return float.Parse(Extract(htmlPage.Result));
                }
                else
                {
                    return _StockPrice;
                }
            }
            catch (Exception)
            {
                return getPrice();
            }
        }

        /// <summary>
        /// Extraction de la page web de la valeur d'une action
        /// </summary>
        /// <param name="htmlPage"></param>
        /// <returns></returns>
        private string Extract(string htmlPage)
        {
            try
            {
                string tag = @"<span data-field=""valorisationHeaderFiche"" data-streamcolor=""variation"">";
                htmlPage = htmlPage.Split(tag)[1];
                tag = "</span>";
                htmlPage = htmlPage.Split(tag)[0];

                var charsToRemove = new List<char>() { '\n', '\t', '&', 'e', 'u', 'r', 'o', ';', ' ' };

                foreach (char c in charsToRemove)
                {
                    htmlPage = htmlPage.Replace(c.ToString(), string.Empty);
                }
                return htmlPage;
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }
    }
}
