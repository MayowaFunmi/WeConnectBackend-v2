using WeConnectBackend.Data;
using WeConnectBackend.Models;

namespace WeConnectBackend.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _dbcontext;

    public CategoryService(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<ServiceCategory.Category> CreateCategory(ServiceCategory.Category category)
    {
        var result = _dbcontext.Categories.Add(category);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteCategory(string name)
    {
        var category = _dbcontext.Categories.FirstOrDefault(c => c.Name == name);
        if (category != null)
        {
            _dbcontext.Categories.Remove(category);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<List<ServiceCategory.Category>> GetCategoriesList()
    {
        List<ServiceCategory.Category> categoryList = new();
        foreach(var category in _dbcontext.Categories)
        {
            categoryList.Add(category);
        }
        return categoryList;
    }

    public async Task<ServiceCategory.Category> UpdateCategory(string categoryName, string editedName)
    {
        var category = _dbcontext.Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category != null)
        {
            category.Name = editedName;
            category.UpdatedAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return category;
        }
        else
        {
            return null;
        }
    }
}