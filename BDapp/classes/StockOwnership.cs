using BDapp_Core.Classes;

namespace BDapp.classes
{
    public class StockOwnership : StockInfo
    {
        private string? StockName;
        private string? Url;
        private float? Price = 0f;
        private float Quantity = 0f;

        public StockOwnership(string stockName, float quantity, string url) : base(stockName, url)
        {
            StockName = stockName;
            Quantity = quantity;
            Url = url;
        }

        public StockOwnership(string stockName, float price, float quantity) : base(stockName, price)
        {
            StockName = stockName;
            Price = price;
            Quantity = quantity;
        }
    }
}
