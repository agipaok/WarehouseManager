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

    public async Task AddAsync(StockMovement movement)
    {
        _db.StockMovements.Add(movement);
        
        var product = await _db.Products.FindAsync(movement.ProductId);

        if (product != null)
        {
            if (movement.MovementType == "IN")
                product.Stock += movement.Quantity;
            else if  (movement.MovementType == "OUT")
                product.Stock -= movement.Quantity;
        }
        await _db.SaveChangesAsync();
    }
}

