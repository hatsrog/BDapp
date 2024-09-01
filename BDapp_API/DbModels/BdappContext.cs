using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BDapp_API.DbModels;

public partial class BdappContext : DbContext
{
    public BdappContext()
    {
    }

    public BdappContext(DbContextOptions<BdappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Market> Markets { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BDappDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Market>(entity =>
        {
            entity.ToTable("markets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.ToTable("prices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.StockId).HasColumnName("stockId");
            entity.Property(e => e.StockPrice).HasColumnName("stockPrice");

            entity.HasOne(d => d.Stock).WithMany(p => p.Prices)
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prices_stocks");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_stock");

            entity.ToTable("stocks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MarketId).HasColumnName("marketId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Market).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.MarketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_stocks_markets");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
