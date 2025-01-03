using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var productFromDb = await dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == product.Id);

        if (productFromDb is null) return new Product();

        productFromDb.Name = product.Name;
        productFromDb.Price = product.Price;
        productFromDb.Description = product.Description;
        productFromDb.SpecialTag = product.SpecialTag;
        productFromDb.CategoryId = product.CategoryId;
        productFromDb.ImageUrl = product.ImageUrl;
        dbContext.Products.Update(productFromDb);
        await dbContext.SaveChangesAsync();
        return productFromDb;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var productFromDb = await dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == id);
        if (productFromDb is null) return false;

        dbContext.Products.Remove(productFromDb);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Product> GetAsync(int id)
    {
        var productFromDb = await dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == id);
        return productFromDb ?? new Product();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }
}