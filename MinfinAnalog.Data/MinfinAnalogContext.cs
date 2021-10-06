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
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<CurrencyRate> CurencyRate { get; set; }
        public virtual DbSet<Сurrency> Сurrency { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(ConfigureUser);
            builder.Entity<CurrencyRate>(ConfigureCurencyRate);
            builder.Entity<Сurrency>(ConfigureСurrency);
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

        }
        private void ConfigureСurrency(EntityTypeBuilder<Сurrency> builder)
        {
            builder.ToTable("Сurrency");

        }

        private void ConfigureCurencyRate(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.ToTable("CurrencyRate");
        }
    }
}
