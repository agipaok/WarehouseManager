using Microsoft.EntityFrameworkCore;
using WarehouseManager.Models;
using WarehouseManager.Data;

namespace WarehouseManager.Services;

public class StockMovementService
{
    private readonly AppDbContext _db;
    
    public StockMovementService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<StockMovement>> GetAllAsync()
    {
        return await _db.StockMovements.Include(m => m.Product)
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();
    }

    public async Task<bool> AddAsync(StockMovement movement)
    {
        var product = await _db.Products.FindAsync(movement.ProductId);
        if (product == null) return  false;
        if (movement.MovementType == "OUT" && product.Stock - movement.Quantity < 0)
            return  false;
        if (movement.MovementType == "IN")
            product.Stock += movement.Quantity;
        else if (movement.MovementType == "OUT")
            product.Stock -= movement.Quantity;
        _db.StockMovements.Add(movement);
        await _db.SaveChangesAsync();
        return true;
    }
}

