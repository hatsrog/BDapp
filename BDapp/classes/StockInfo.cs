using BDapp.utilities;

namespace BDapp_Core.Classes
{
    public class StockInfo
    {
        private string Name;
        private string Url = string.Empty;
        private float Price;
        private ICollection<StockPrice> Prices;

        public StockInfo(string stockName, string url)
        {
            Name = stockName;
            Url = url;
        }

        public StockInfo(string stockName, float price)
        {
            Name = stockName;
            Price = price;
        }

        public string StockName
        {
            get
            { return StockName; }
            set
            { StockName = value; }
        }

        public float StockPrice
        {
            get
            { return Price; }
            set
            { Price = value; }
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
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
