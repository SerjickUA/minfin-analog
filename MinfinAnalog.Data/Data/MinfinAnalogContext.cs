using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MinfinAnalog.Domain.Entities;

namespace MinfinAnalog.Data
{
    public class MinfinAnalogContext : DbContext
    {
        public MinfinAnalogContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CurrencyRate> CurencyRates { get; set; }
        public virtual DbSet<Currency> Сurrencies { get; set; }
        public virtual DbSet<UserWatchlist> UserWatchlists { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(ConfigureUser);
            builder.Entity<CurrencyRate>(ConfigureCurencyRate);
            builder.Entity<Currency>(ConfigureСurrency);
            builder.Entity<UserWatchlist>(ConfigureUserWatchlist);
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

        }
        private void ConfigureСurrency(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Сurrencies");
        }
        private void ConfigureCurencyRate(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.ToTable("CurrencyRates")
                .Property(cr => cr.Rate).HasPrecision(18, 4);
        }
        private void ConfigureUserWatchlist(EntityTypeBuilder<UserWatchlist> builder)
        {
            builder.ToTable("UserWatchlist");
        }
    }
}
