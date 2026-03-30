using System.Net.Http.Json;
using WarehouseManager.Models;

namespace WarehouseManager.Client.Services;

public class ProductClientService
{
    private readonly HttpClient _http;

    public ProductClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Product>>("api/products") ?? new();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Product>($"api/products/{id}");

    public async Task<Product?> AddAsync(Product product)
    {
        var response = await _http.PostAsJsonAsync("api/products", product);
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task UpdateAsync(Product product) =>
        await _http.PutAsJsonAsync($"api/products/{product.Id}", product);

    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/products/{id}");
}
