using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinfinAnalog.Data.Entities;

namespace MinfinAnalog.Infrastructure;
public class MinfinAnalogContext : DbContext
{
    public MinfinAnalogContext(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
    public virtual DbSet<Currency> Сurrencies { get; set; }
    public virtual DbSet<UserWatchlist> UserWatchlists { get; set; }
    public virtual DbSet<ExchangeOperation> ExchangeOperations { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(ConfigureUser);
        builder.Entity<CurrencyRate>(ConfigureCurrencyRate);
        builder.Entity<Currency>(ConfigureСurrency);
        builder.Entity<UserWatchlist>(ConfigureUserWatchlist);
        builder.Entity<ExchangeOperation>(ConfigureExchangeOperation);
    }
    private void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
    }
    private void ConfigureСurrency(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Сurrencies");
    }
    private void ConfigureCurrencyRate(EntityTypeBuilder<CurrencyRate> builder)
    {
        builder.ToTable("CurrencyRates");
        builder.Property(cr => cr.Rate).HasPrecision(18, 4);
    }
    private void ConfigureUserWatchlist(EntityTypeBuilder<UserWatchlist> builder)
    {
        builder.ToTable("UserWatchlist");
    }
    private void ConfigureExchangeOperation(EntityTypeBuilder<ExchangeOperation> builder)
    {
        builder.ToTable("ExchangeOperationsHistory");
        builder.Property(eo => eo.BankFee).HasPrecision(18, 2);
        builder.Property(eo => eo.Amount).HasPrecision(18, 2);
    }
}