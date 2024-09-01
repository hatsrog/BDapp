using System;
using System.Collections.Generic;

namespace BDapp_API.DbModels;

public partial class Price
{
    public long Id { get; set; }

    public long StockId { get; set; }

    public DateTime Date { get; set; }

    public double StockPrice { get; set; }

    public virtual Stock Stock { get; set; } = null!;
}
