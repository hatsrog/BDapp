using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BDapp_API.Models
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options): base(options)
        {

        }

        public DbSet<StockModel> stockModels { get; set; } = null!;
    }
}
