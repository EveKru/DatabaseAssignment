using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    [ForeignKey(nameof(CategoryEntity.Id))]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

}
