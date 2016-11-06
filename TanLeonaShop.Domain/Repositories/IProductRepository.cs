using System.Linq;
using TanLeonaShop.Domain.Models;

namespace TanLeonaShop.Domain.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        Product Get(int id);

        void Save(Product product);
    }
}
