using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data;

public class Product
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Range(0.01, 1000)] public double Price { get; set; }
    public string? Description { get; set; }
    public string? SpecialTag { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public string? ImageUrl { get; set; }
}