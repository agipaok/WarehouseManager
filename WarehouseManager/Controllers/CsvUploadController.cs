using Microsoft.AspNetCore.Mvc;
using System.Text;
using WarehouseManager.Models;
using WarehouseManager.Services;

namespace WarehouseManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CsvUploadController : ControllerBase
{
    private readonly ProductService _service;

    public CsvUploadController(ProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file is null || file.Length == 0) return BadRequest();

        using var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
        var content = await reader.ReadToEndAsync();
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines.Skip(1))
        {
            var values = line.Split(',');
            if (values.Length < 6) continue;

            var product = new Product
            {
                SKU = values[0].Trim(),
                Name = values[1].Trim(),
                Category = values[2].Trim(),
                Price = decimal.TryParse(values[3].Trim(), out var price) ? price : 0,
                Stock = int.TryParse(values[4].Trim(), out var stock) ? stock : 0,
                MinStock = int.TryParse(values[5].Trim(), out var minStock) ? minStock : 0
            };

            await _service.AddAsync(product);
        }

        return Ok();
    }
}
