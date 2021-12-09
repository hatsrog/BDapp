using BDapp.classes;

namespace BDapp_API.Models
{
    public class StockModel
    {
        public long id { get; set; }

        public string? stockName { get; set; }

        public float stockPrice { get; set; }
    }
}
