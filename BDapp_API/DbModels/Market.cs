namespace BDapp_API.DbModels;

public partial class Market
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
