using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.Models;

public class Supplier
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Το όνομα είναι υποχρεωτικό")]
    [StringLength(100,ErrorMessage = "Μέγιστο 100 χαρακτήρες")]
    public string Name { get; set; } = string.Empty;
    [StringLength(100)]
    public string ContactPerson { get; set; } = string.Empty;
    [Phone(ErrorMessage = "Μη έγκυρο τηλέφωνο")]
    public string Phone  { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "Μη έγκυρο email")]
    public string Email { get; set; } = string.Empty;
}