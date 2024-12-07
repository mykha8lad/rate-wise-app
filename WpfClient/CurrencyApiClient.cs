using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CurrencyApiClient
{
    private readonly HttpClient _httpClient;

    public CurrencyApiClient()
    {
        _httpClient = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000/") };
    }

    // Метод для получения курсов валют
    public async Task<Dictionary<string, decimal>> GetExchangeRatesAsync()
    {
        return await _httpClient.GetFromJsonAsync<Dictionary<string, decimal>>("api/currency/rates");
    }
}
