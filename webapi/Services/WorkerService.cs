using webapi.Interfaces;

namespace webapi.Services;

public class WorkerService : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly ICurrencyService _currencyService;
    public WorkerService(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _currencyService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICurrencyService>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int.TryParse(_configuration.GetSection("GetCurrencyTablesInterval").Value, out int generalDelay);
        while (!stoppingToken.IsCancellationRequested)
        {
            await _currencyService.AddCurrencyTablesAsync();
            await Task.Delay(generalDelay, stoppingToken);
        }
    }

}