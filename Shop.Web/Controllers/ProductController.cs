using Shop.Web.Models;
using System.Linq;
using System.Web.Mvc;
using TanLeonaShop.Domain.Services;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController (IProductService productService)
        {
            _productService = productService;
        }


        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductIndexViewModel { Products = _productService.GetAll().ToList().Select(x => new ProductViewModel(x))};
            return View(model);
        }

    }
}