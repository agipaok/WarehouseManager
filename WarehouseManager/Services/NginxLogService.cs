using Microsoft.EntityFrameworkCore;
using WarehouseManager.Data;
using WarehouseManager.Models;

namespace WarehouseManager.Services;

public class NginxLogService
{
    private readonly AppDbContext _db;

    public NginxLogService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<NginxLogEntry>> GetAllAsync()
    {
        return await _db.NginxLogEntries
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync();
    }

    public async Task AddRangeAsync(List<NginxLogEntry> logs)
    {
        await _db.NginxLogEntries.AddRangeAsync(logs);
        await _db.SaveChangesAsync();
    }
}