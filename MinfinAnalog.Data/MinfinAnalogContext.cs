using MinfinAnalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MinfinAnalog.Data
{
    public class MinfinAnalogContext : DbContext
    {
        public MinfinAnalogContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<CurrencyRate> CurencyRate { get; set; }
         public virtual DbSet<Сurrency> Сurrency { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CurrencyRate>(ConfigureCurencyRate);
            builder.Entity<Сurrency>(ConfigureСurrency);
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
