using Microsoft.AspNetCore.Mvc;
using WarehouseManager.Data;
using WarehouseManager.Shared.Models;

namespace WarehouseManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NginxLogsController : ControllerBase
{
    private readonly AppDbContext _context;

    public NginxLogsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SaveLogs([FromBody] List<NginxLogEntry> logs)
    {
        _context.NginxLogEntries.AddRange(logs);
        await _context.SaveChangesAsync();

        return Ok();
    }
}