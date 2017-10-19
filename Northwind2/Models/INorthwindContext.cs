using System.Linq;

namespace Northwind2.Models
{
    public interface INorthwindContext
    {
        IQueryable<Category> Categories { get; }

        IQueryable<Product> Products { get; }

        Category FindCategoryById(int ID);

        Product FindProductByID(int ID);

        T Add<T>(T entity) where T : class;

        T Delete<T>(T entity) where T : class;

        int SaveChanges();


    }
}
