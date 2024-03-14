using System.ComponentModel.DataAnnotations;

namespace MvcEcommerce.Models;

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public string? Color { get; set; }
    public decimal Image { get; set; }
}