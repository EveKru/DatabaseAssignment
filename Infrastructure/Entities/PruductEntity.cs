using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class PruductEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    [ForeignKey(nameof(CategoryEntity.Id))]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

}
