using System;
using System.Collections.Generic;

namespace BDapp_API.DbModels;

public partial class Price
{
    public long Id { get; set; }

    public long StockId { get; set; }

    public DateOnly Date { get; set; }

    public double PriceValue { get; set; }

    public virtual Stock Stock { get; set; } = null!;
}
