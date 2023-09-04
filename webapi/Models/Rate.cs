namespace webapi.Models;

public class Rate
{
    public string Currency { get; set; } = String.Empty;
    public string Code { get; set; } = String.Empty;
    public decimal? Bid { get; set; }
    public decimal? Ask { get; set; }
    public decimal? Mid { get; set; }
}

