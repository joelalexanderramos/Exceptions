using System.Linq;

namespace Northwind2.Models
{
    public class NorthwindContext : INorthwindContext
    {
        NorthwindEntities Context = new NorthwindEntities();

        public IQueryable<Category> Categories
        {
            get
            {
                return Context.Categories;
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                return Context.Products;
            }
        }

        public T Add<T>(T entity) where T : class
        {
            return Context.Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Context.Set<T>().Remove(entity);
        }

        public Category FindCategoryById(int ID)
        {
            var Category = Context.Categories.Find(ID);

            if (Category == null)
            {
                throw (new Exceptions.CategoryNotFoundException(ID));
            }
            else
            { return Category;  }
        }

        public Product FindProductByID(int ID)
        {
            return Context.Products.Find(ID);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}