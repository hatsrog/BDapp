namespace BDapp.classes
{
    public class StockOwnership : Stock
    {
        private string StockName;
        private string Url;
        private float Price = 0f;
        private float Quantity = 0f;

        public StockOwnership(string stockName, float quantity, string url) : base(stockName, url)
        {
            this.StockName = stockName;
            this.Quantity = quantity;
            this.Url = url;
        }

        public StockOwnership(string stockName, float price, float quantity) : base(stockName, price)
        {
            this.StockName = stockName;
            this.Price = price;
            this.Quantity = quantity;
        }

        public float GetQuantity
        {
            get { return Quantity; }
        }
    }
}
