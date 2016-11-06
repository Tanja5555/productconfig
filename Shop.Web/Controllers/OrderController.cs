using Shop.Web.Models;
using System;
using System.Web.Mvc;
using TanLeonaShop.Domain;
using TanLeonaShop.Domain.Services;

namespace Shop.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

      
        //GET: Product
        public ActionResult UserOrders()
        {
            var model = _orderService.GetUsersOrders();
            return View(model);
        }

        public ActionResult SeePreorder(int id)
        {
            var orderVM = new OrderViewModel()
            {
                Order = _orderService.Create(id) // id is productId
            };

            var productVM = new ProductViewModel(orderVM.Order.Product);
            orderVM.Product = productVM;
            return View((orderVM));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeePreorder(OrderViewModel model)
        {

            try
            {
                var form = Request.Form;
                var id = User.Identity.Name;

                var orderVM = new OrderViewModel(id);
                var productId = Int32.Parse((form["Product.Id"] != null) ? form["Product.Id"] : "0");

                orderVM.Order = _orderService.Create(productId); // id is productId
                var product = orderVM.Order.Product;
                orderVM.Order = orderVM.Order.FillOrderProperties(product, form);
                orderVM.Order.AppUserId = orderVM.AppUser.Id;

                if(ModelState.IsValid)
                {
                    _orderService.Save(orderVM.Order);
                }
                return RedirectToAction("OrderResult", new { id = orderVM.Order.Id });
            }
            catch
            {
                return View(model);
            }
        }

         public ActionResult OrderResult(int id)
        {
            var order = _orderService.Get(id);
            var model = new OrderViewModel(order);
            var user = User.Identity.Name;
            TempData["Tack"] = "Thank you for your order, " + user + "!";
            return View(model);
        }
    }
}