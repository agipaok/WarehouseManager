using Microsoft.EntityFrameworkCore;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Services;

public class SupplierService
{
    private readonly AppDbContext _db;
    
    public SupplierService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _db.Suppliers.ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
        _db.Suppliers.Add(supplier);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        var existing = await _db.Suppliers.FindAsync(supplier.Id);
        if (existing != null)
        {
            existing.Name = supplier.Name;
            existing.ContactPerson = supplier.ContactPerson;
            existing.Phone = supplier.Phone;
            existing.Email = supplier.Email;
            await _db.SaveChangesAsync();
        }
    }
    
    public async Task DeleteAsync(int id)
    {
        var supplier = await _db.Suppliers.FindAsync(id);
        if (supplier != null)
        {
            _db.Suppliers.Remove(supplier);
            await _db.SaveChangesAsync();
        }
    }
}



