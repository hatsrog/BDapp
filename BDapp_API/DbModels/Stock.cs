using System;
using System.Collections.Generic;

namespace BDapp_API.DbModels;

public partial class Stock
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long MarketId { get; set; }

    public virtual Market Market { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
