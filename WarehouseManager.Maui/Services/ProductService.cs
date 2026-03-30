using Microsoft.EntityFrameworkCore;
using WarehouseManager.Data;   
using  WarehouseManager.Models;

namespace WarehouseManager.Services;

public class ProductService
{
    private readonly AppDbContext _db;
    
    public ProductService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var existing = await _db.Products.FindAsync(product.Id);
        if (existing != null)
        {
            existing.SKU = product.SKU;
            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            existing.MinStock = product.MinStock;
            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if  (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _db.Products.FindAsync(id);
    }
}