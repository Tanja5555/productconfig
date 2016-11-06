using System.Linq;
using TanLeonaShop.Domain.Models;

namespace TanLeonaShop.Domain.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();

        Product Get(int id);

        void Save(Product product);
      
    }
}
