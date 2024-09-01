namespace BDapp_Core.Classes
{
    public class StockInformation
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<StockPrice> Prices { get; set; }
    }
}
