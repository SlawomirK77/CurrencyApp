namespace webapi.Models;

public class CurrencyTable
{
    public string Table { get; set; } = String.Empty;
    public string No { get; set; } = String.Empty;
    public DateOnly? TradingDate { get; set; }
    public DateOnly EffectiveDate { get; set; }
    public List<Rate> Rates { get; set; } = new List<Rate>();
}
