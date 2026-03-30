using Microsoft.AspNetCore.Mvc;
using WarehouseManager.Models;
using WarehouseManager.Services;

namespace WarehouseManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockMovementsController : ControllerBase
{
    private readonly StockMovementService _service;

    public StockMovementsController(StockMovementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<StockMovement>> GetAll() => await _service.GetAllAsync();

    [HttpPost]
    public async Task<IActionResult> Create(StockMovement movement)
    {
        var success = await _service.AddAsync(movement);
        return success ? Ok() : BadRequest("Ανεπαρκές stock για OUT κίνηση.");
    }
}
