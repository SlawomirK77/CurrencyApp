namespace webapi.Entites;

public class CurrencyTableEntity
{
    public Guid Id { get; set; }
    public string Table { get; set; } = String.Empty;
    public string No { get; set; } = String.Empty;
    public DateOnly? TradingDate { get; set; }
    public DateOnly EffectiveDate { get; set; }
    public List<RateEntity> Rates { get; set; } = new List<RateEntity>();
}
