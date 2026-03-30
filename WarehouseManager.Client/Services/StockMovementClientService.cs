using System.Net.Http.Json;
using WarehouseManager.Models;

namespace WarehouseManager.Client.Services;

public class StockMovementClientService
{
    private readonly HttpClient _http;

    public StockMovementClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<StockMovement>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<StockMovement>>("api/stockmovements") ?? new();

    public async Task<bool> AddAsync(StockMovement movement)
    {
        var response = await _http.PostAsJsonAsync("api/stockmovements", movement);
        return response.IsSuccessStatusCode;
    }
}
