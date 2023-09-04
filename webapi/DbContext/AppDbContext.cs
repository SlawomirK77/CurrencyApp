using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace webapi.Entites;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RateEntity> Rates { get; set; }
    public DbSet<CurrencyTableEntity> CurrencyTables { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RateEntity>().Property(x => x.Ask).HasPrecision(12, 10);
        builder.Entity<RateEntity>().Property(x => x.Bid).HasPrecision(12, 10);
        builder.Entity<RateEntity>().Property(x => x.Mid).HasPrecision(12, 10);

        builder.Entity<CurrencyTableEntity>()
        .HasMany<RateEntity>(ct => ct.Rates)
        .WithOne(r => r.CurrencyTable)
        .HasForeignKey(ct => ct.CurrencyTableId);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
        .HaveConversion<NullableDateOnlyConverter>()
        .HaveColumnType("date");
    }

    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        public NullableDateOnlyConverter() : base(
            d => d == null
                ? null
                : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
            d => d == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(d.Value)))
        { }
    }
}