using BDapp.utilities;

namespace BDapp.classes
{
    public class Stock
    {
        private string StockName;
        private string Url;
        private float Price;
        
        public Stock(string stockName, string url)
        {
            this.StockName = stockName;
            this.Url = url;
        }

        public Stock(string stockName, float price)
        {
            this.StockName = stockName;
            this.Price = price;
        }

        public string _StockName
        {
            get
                { return this.StockName; }
            set
                { this.StockName = value; }
        }

        public float _StockPrice
        {
            get
                { return this.Price; }
            set 
                { this.Price = value; }
        }

        public float getPrice()
        {
            try
            {
                if (_StockPrice == 0)
                {
                    string htmlPage = HTMLHandler.downloadSourcePage(this.Url);
                    return float.Parse(extract(htmlPage));
                }
                else
                {
                    return _StockPrice;
                }
            }
            catch(Exception ex)
            {
                return getPrice();
            }
        }

        /// <summary>
        /// Extraction de la page web de la valeur d'une action
        /// </summary>
        /// <param name="htmlPage"></param>
        /// <returns></returns>
        private string extract(string htmlPage)
        {
            try
            {
                string tag = @"<span data-field=""valorisationHeaderFiche"" data-streamcolor=""variation"">";
                htmlPage = htmlPage.Split(tag)[1];
                tag = "</span>";
                htmlPage = htmlPage.Split(tag)[0];

                List<char> charsToRemove = new List<char>() { '\n', '\t', '&', 'e', 'u', 'r', 'o', ';', ' ' };

                foreach (char c in charsToRemove)
                {
                    htmlPage = htmlPage.Replace(c.ToString(), String.Empty);
                }
                return htmlPage;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
