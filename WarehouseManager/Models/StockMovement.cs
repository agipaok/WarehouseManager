using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.Models;

public class StockMovement
{
  
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    [Required(ErrorMessage = "Δεν μπορεί να είναι μηδενική κίνηση")]
    [Range(1,9999,ErrorMessage = "Η ποσότητα πρέπει να είναι μεταξύ 1-9999")]
    public int Quantity { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Notes { get; set; } = string.Empty;

}