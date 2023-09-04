using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Entites;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services;

public class CurrencyService : ICurrencyService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public CurrencyService(AppDbContext context, IMapper mapper, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<CurrencyTable>> GetCurrencyTablesAsync()
    {

        var queryResult = await _context.CurrencyTables.Include(x => x.Rates).GroupBy(x => x.Table).Select(x => x.OrderByDescending(x => x.EffectiveDate).First()).ToListAsync();
        var currencyTables = queryResult.Select(x => _mapper.Map<CurrencyTable>(x)).ToList();

        return await Task.FromResult(currencyTables);
    }

    public async Task AddCurrencyTablesAsync()
    {
        await AddTableAsync("a");
        await AddTableAsync("b");
        await AddTableAsync("c");
    }

    private async Task AddTableAsync(string table)
    {
        try
        {
            var currentTable = await _context.CurrencyTables.Include(x => x.Rates).OrderByDescending(x => x.TradingDate).FirstOrDefaultAsync(x => x.Table == table.ToUpper());
            var newTable = await GetCurrencyTableFromNbpAsync(table);
            if (currentTable is null || currentTable is not null && newTable is not null && !IsCurentTableActual(currentTable, newTable))
            {
                await CreateTableAsync(newTable);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    internal async Task<CurrencyTable?> GetCurrencyTableFromNbpAsync(string table)
    {
        try
        {
            Uri path = new($"{_configuration.GetSection("ApiUrl:NbpUrl").Value}/{table}");
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(path);
            var resultContent = response.Content.ReadFromJsonAsync<List<CurrencyTable>>().Result;
            return resultContent!.First();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        return null;
    }

    internal async Task CreateTableAsync(CurrencyTable request)
    {
        var newTable = new CurrencyTableEntity
        {
            Table = request.Table,
            No = request.Table,
            EffectiveDate = request.EffectiveDate,
            TradingDate = request.TradingDate,
            Rates = request.Rates.Select(x => new RateEntity
            {
                Currency = x.Currency,
                Code = x.Code,
                Ask = x.Ask,
                Bid = x.Bid,
                Mid = x.Mid,
            }).ToList(),
        };
        var addedTable = _context.CurrencyTables.AddAsync(newTable).Result.Entity;
        await _context.SaveChangesAsync();
    }

    internal static bool IsCurentTableActual(CurrencyTableEntity currentTable, CurrencyTable newTable)
    {
        return currentTable.No == newTable.No;
    }
}