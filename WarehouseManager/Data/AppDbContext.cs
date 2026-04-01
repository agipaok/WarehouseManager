using  Microsoft.EntityFrameworkCore;
using WarehouseManager.Shared.Models;
using WarehouseManager.Models;
namespace WarehouseManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<NginxLogEntry> NginxLogEntries { get; set; }
    
  
}