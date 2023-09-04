using webapi.Entites;
using webapi.Models;
using webapi.Services;
using Xunit;

public class CurrencyServiceTests
{
    [Fact]
    public async Task CheckTables()
    {
        // Arrange
        var savedTable = new CurrencyTableEntity
        {
            Id = Guid.NewGuid(),
            Table = "A",
            No = "170/A/NBP/2023",
            TradingDate = null,
            EffectiveDate = DateOnly.FromDateTime(DateTime.Today),
        };
        var newTable = new CurrencyTable
        {
            Table = "A",
            No = "170/A/NBP/2023",
            TradingDate = null,
            EffectiveDate = DateOnly.FromDateTime(DateTime.Today),
        };
        var olderTable = new CurrencyTable
        {
            Table = "A",
            No = "168/A/NBP/2023",
            TradingDate = null,
            EffectiveDate = DateOnly.FromDateTime(DateTime.Today),
        };

        // Act
        var result1 = CurrencyService.IsCurentTableActual(savedTable, newTable);
        var result2 = CurrencyService.IsCurentTableActual(savedTable, olderTable);

        // Assert
        Assert.True(result1);
        Assert.False(result2);
    }


}