using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
{
    public Category Create(Category category)
    {
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        var categoryFromDb = dbContext.Categories.FirstOrDefault(cat => cat.Id == category.Id);

        if (categoryFromDb is null) return new Category();

        categoryFromDb.Name = category.Name;
        dbContext.Categories.Update(categoryFromDb);
        dbContext.SaveChanges();
        return categoryFromDb;
    }

    public bool Delete(int id)
    {
        var categoryFromDb = dbContext.Categories.FirstOrDefault(cat => cat.Id == id);
        if (categoryFromDb is null) return false;

        dbContext.Categories.Remove(categoryFromDb);
        return dbContext.SaveChanges() > 0;
    }

    public Category Get(int id)
    {
        var categoryFromDb = dbContext.Categories.FirstOrDefault(cat => cat.Id == id);
        if (categoryFromDb is null) return new Category();

        return categoryFromDb;
    }

    public IEnumerable<Category> GetAll()
    {
        return dbContext.Categories.ToList();
    }
}