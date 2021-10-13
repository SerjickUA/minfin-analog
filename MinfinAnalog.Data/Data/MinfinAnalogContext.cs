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
        public virtual DbSet<Сurrency> Сurrencies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(ConfigureUser);
            builder.Entity<CurrencyRate>(ConfigureCurencyRate);
            builder.Entity<Сurrency>(ConfigureСurrency);
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

        }
        private void ConfigureСurrency(EntityTypeBuilder<Сurrency> builder)
        {
            builder.ToTable("Сurrencies");

        }

        private void ConfigureCurencyRate(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.ToTable("CurrencyRates");
            builder.Property(cr => cr.Rate).HasPrecision(18, 4);
        }
    }
}
