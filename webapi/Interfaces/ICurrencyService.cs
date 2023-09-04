using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Interfaces;

public interface ICurrencyService
{
    Task<List<CurrencyTable>> GetCurrencyTablesAsync();
    Task AddCurrencyTablesAsync();
}

