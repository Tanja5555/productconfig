using System.Linq;
using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;
using Shop.Web.Models;
using System.Data.Entity;

namespace Shop.Web.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ShopContext _context = new ShopContext();

      
        public Product Get(int id)
        {
            return _context.dbProducts.Where(x => x.Id == id).Include(x => x.Options.Select(o => o.OptionChoices)).FirstOrDefault();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.dbProducts.AsQueryable();
        }


        public void Save(Product product)
        {
            if(product.Id == 0)
                _context.dbProducts.Add(product);
            else
                _context.Entry(product).State = EntityState.Modified;
            //_context.SaveChanges();
        }
    }
}