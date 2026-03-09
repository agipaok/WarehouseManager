using System.ComponentModel.DataAnnotations;
namespace WarehouseManager.Models;


public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Το όνομα είναι υποχρεωτικό")]
    [StringLength(100, ErrorMessage = "Μέγιστο 100 χαρακτήρες")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Το SKU είναι υποχρεωτικό")]
    [StringLength(50,ErrorMessage = "Μέγιστο 50 χαρακτήρες")]
    public string SKU { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    [Range(0.01, 999999, ErrorMessage = "Η τιμή πρέπει να είναι μεταξυ 0.01-999999")]
    public decimal Price { get; set; }
    [Range(0,999999,ErrorMessage = "Το stock δεν μπορεί να είναι αρνητικό")]
    public int Stock { get; set; }
    [Range(0,999999,ErrorMessage = "Το MinStock δεν μπορεί να είναι αρνητικό")]
    public int MinStock { get; set; }
}
    
    