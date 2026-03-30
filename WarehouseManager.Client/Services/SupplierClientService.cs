using System.Net.Http.Json;
using WarehouseManager.Models;

namespace WarehouseManager.Client.Services;

public class SupplierClientService
{
    private readonly HttpClient _http;

    public SupplierClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Supplier>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Supplier>>("api/suppliers") ?? new();

    public async Task AddAsync(Supplier supplier) =>
        await _http.PostAsJsonAsync("api/suppliers", supplier);

    public async Task UpdateAsync(Supplier supplier) =>
        await _http.PutAsJsonAsync($"api/suppliers/{supplier.Id}", supplier);

    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/suppliers/{id}");
}
