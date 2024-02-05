using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;

    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName});
        return categoryEntity;
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepository.Get(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updated = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updated;
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
    }

}
