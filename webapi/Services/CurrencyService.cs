using Microsoft.EntityFrameworkCore;
using webapi.Entites;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services;

public class CurrencyService : ICurrencyService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CurrencyService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<List<CurrencyTable>> GetCurrencyTablesAsync()
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var queryResult = await context.CurrencyTables.Include(x => x.Rates).GroupBy(x => x.Table).Select(x => x.OrderByDescending(x => x.EffectiveDate).First()).ToListAsync();
        var currencyTables = queryResult.Select(x => new CurrencyTable
        {
            Table = x.Table,
            No = x.No,
            TradingDate = x.TradingDate,
            EffectiveDate = x.EffectiveDate,
            Rates = x.Rates.Select(r => new Rate
            {
                Currency = r.Currency,
                Code = r.Code,
                Ask = r.Ask,
                Bid = r.Bid,
                Mid = r.Mid,
            }).ToList()
        }).ToList();

        return await Task.FromResult(currencyTables);
    }
}