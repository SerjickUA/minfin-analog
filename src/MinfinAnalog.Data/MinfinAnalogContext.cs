using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinfinAnalog.Domain.Entities;

namespace MinfinAnalog.Data;
public class MinfinAnalogContext : DbContext
{
    public MinfinAnalogContext(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<CurrencyRate> CurrencyRates => Set<CurrencyRate>();
    public virtual DbSet<Currency> Сurrencies => Set<Currency>();
    public virtual DbSet<UserWatchlist> UserWatchlists => Set<UserWatchlist>();
    public virtual DbSet<UserExchangeOperation> ExchangeOperations => Set<UserExchangeOperation>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(ConfigureUser);
        builder.Entity<CurrencyRate>(ConfigureCurrencyRate);
        builder.Entity<Currency>(ConfigureСurrency);
        builder.Entity<UserWatchlist>(ConfigureUserWatchlist);
        builder.Entity<UserExchangeOperation>(ConfigureExchangeOperation);
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
        builder.Property(cr => cr.Rate).HasPrecision(18, 6);
    }
    private void ConfigureUserWatchlist(EntityTypeBuilder<UserWatchlist> builder)
    {
        builder.ToTable("UserWatchlist");
    }
    private void ConfigureExchangeOperation(EntityTypeBuilder<UserExchangeOperation> builder)
    {
        builder.ToTable("ExchangeOperationsHistory");
        builder.Property(eo => eo.BankFee).HasPrecision(18, 2);
        builder.Property(eo => eo.Amount).HasPrecision(18, 2);
    }
}