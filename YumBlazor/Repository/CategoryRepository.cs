using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
{
    public async Task<Category> CreateAsync(Category category)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var categoryFromDb = await dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == category.Id);

        if (categoryFromDb is null) return new Category();

        categoryFromDb.Name = category.Name;
        dbContext.Categories.Update(categoryFromDb);
        await dbContext.SaveChangesAsync();
        return categoryFromDb;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var categoryFromDb = await dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
        if (categoryFromDb is null) return false;

        dbContext.Categories.Remove(categoryFromDb);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Category> GetAsync(int id)
    {
        var categoryFromDb = await dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
        return categoryFromDb ?? new Category();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await dbContext.Categories.ToListAsync();
    }
}