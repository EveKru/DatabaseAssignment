namespace Infrastructure.Dtos;

public class ProductDto
{
    public string Title { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

}
