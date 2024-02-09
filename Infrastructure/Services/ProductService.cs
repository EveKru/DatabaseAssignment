using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProductService(ProductRepository productRepository, CategoryService categoryService)
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly CategoryService _categoryService = categoryService;


    public ProductEntity CreateProduct(ProductDto productDto)
    {

        var categoryEntity = _categoryService.CreateCategory(productDto.Category);

        var productEntity = new ProductEntity
        {
            Title = productDto.Title,
            ArticleNumber = productDto.ArticleNumber,
            Description = productDto.Description,
            Price = productDto.Price,
            CategoryId = categoryEntity.Id,
        };

        _productRepository.Create(productEntity);
        return productEntity;
    }

    public ProductEntity GetProductById(int id)
    {
        var productEntity = _productRepository.Get(x => x.Id == id);
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetAll()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updated = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
        return updated;
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }

}

