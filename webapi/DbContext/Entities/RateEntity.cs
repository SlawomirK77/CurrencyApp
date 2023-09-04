using Microsoft.EntityFrameworkCore;

namespace webapi.Entites;

public class RateEntity
{
    public Guid Id { get; set; }
    public string Currency { get; set; } = String.Empty;
    public string Code { get; set; } = String.Empty;
    public decimal? Bid { get; set; }
    public decimal? Ask { get; set; }
    public decimal? Mid { get; set; }
    public Guid CurrencyTableEntityId { get; set; }
    public required CurrencyTableEntity CurrencyTableEntity { get; set; }
}

