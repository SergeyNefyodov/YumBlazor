using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository;

public interface ICategoryRepository
{
    Category Create(Category category);
    Category Update(Category category);
    bool Delete(int id);
    Category Get(int id);
    IEnumerable<Category> GetAll();
}