using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;

namespace TanLeonaShop.Domain.Services
{
    public class TestService : ITestService
    {

        private readonly IProductRepository _productRepository;

        public TestService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddOrder(Order order)
        {
            var product = _productRepository.Get(order.Product.Id);
            if (product.ProductName != "Car") return false;
            return true;
        }
    }
}
