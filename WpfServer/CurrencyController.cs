using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/currency")]
public class CurrencyController : ControllerBase
{
    private readonly CurrencyService _currencyService = new();

    // HTTP GET для получения курсов валют
    [HttpGet("rates")]
    public async Task<IActionResult> GetRates()
    {
        var rates = await _currencyService.GetExchangeRatesAsync();
        return Ok(rates);
    }
}
