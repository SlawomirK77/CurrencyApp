using webapi.Models;

namespace webapi.Interfaces;

public interface ICurrencyService
{
    Task<List<CurrencyTable>> GetCurrencyTablesAsync();
}

