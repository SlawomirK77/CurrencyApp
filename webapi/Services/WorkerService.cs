using Microsoft.EntityFrameworkCore;
using webapi.Entites;

namespace webapi.Services;

public class WorkerService : BackgroundService
{
    private const int generalDelay = 1000 * 5 * 1;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public WorkerService(IConfiguration configuration, IHttpClientFactory httpClientFactory, IServiceScopeFactory serviceScopeFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        while (!stoppingToken.IsCancellationRequested)
        {

            await UpdateTable(context, httpClient, "a");
            await UpdateTable(context, httpClient, "b");
            await UpdateTable(context, httpClient, "c");
            await Task.Delay(generalDelay, stoppingToken);
        }
    }

    private async Task UpdateTable(AppDbContext context, HttpClient httpClient, string table)
    {
        try
        {
            Uri path = new($"{_configuration.GetSection("ApiUrl:NbpUrl").Value}/{table}");
            var currentTable = await context.CurrencyTables.Include(x => x.Rates).OrderByDescending(x => x.TradingDate).FirstOrDefaultAsync(x => x.Table == table.ToUpper());
            var response = await httpClient.GetAsync(path);
            var resultContent = response.Content.ReadFromJsonAsync<List<CurrencyTableEntity>>().Result;
            var newTable = resultContent.First();
            if (currentTable is null || currentTable is not null && newTable is not null && !IsCurentTableActual(currentTable, newTable))
            {
                await context.CurrencyTables.AddAsync(newTable);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private static bool IsCurentTableActual(CurrencyTableEntity currentTable, CurrencyTableEntity newTable)
    {
        return currentTable.TradingDate == newTable.TradingDate && currentTable.EffectiveDate == newTable.EffectiveDate;
    }
}