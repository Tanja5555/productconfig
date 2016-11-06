using System.Linq;
using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;

namespace TanLeonaShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product Get(int id)
        {

            return _productRepository.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Save(Product product)
        {
            _productRepository.Save(product);
        }

        
    }
}
