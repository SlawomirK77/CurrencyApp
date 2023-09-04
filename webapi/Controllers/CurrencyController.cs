using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet("CurrencyTables")]
    public async Task<List<CurrencyTable>> GetCurrencyTables()
    {
        var result = await _currencyService.GetCurrencyTablesAsync();
        return result;
    }
}
