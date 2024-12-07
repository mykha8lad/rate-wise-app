using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class CurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService()
    {
        _httpClient = new HttpClient();
    }

    // Метод для получения курсов валют
    public async Task<Dictionary<string, decimal>> GetExchangeRatesAsync()
    {
        string url = "https://api.exchangerate.host/latest?base=USD"; // URL API

        // Выполняем GET-запрос и десериализуем JSON-ответ
        var response = await _httpClient.GetFromJsonAsync<CurrencyResponse>(url);
        return response?.Rates ?? new Dictionary<string, decimal>();
    }
}

// Класс для десериализации ответа API
public class CurrencyResponse
{
    public Dictionary<string, decimal> Rates { get; set; }
}
