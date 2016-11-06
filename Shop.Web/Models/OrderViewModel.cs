using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Models
{
    public class OrderViewModel
    {

        public OrderViewModel()
        {
            Product = new ProductViewModel(); 
        }

        public OrderViewModel(string userId)
        {
            var shopContext = new ShopContext();
            var userStore = new UserStore<AppUser>(shopContext);
            var userManager = new UserManager<AppUser>(userStore);
            var user = userManager.FindByName(userId);

            AppUser = user;
            Product = new ProductViewModel();
            Order = new Order()
            {
                OrderDate = DateTime.Now
            };
        }

        public OrderViewModel(Order order)
        {
            AppUser = order.AppUser;
            Product = new ProductViewModel(order.Product);
            Order = order;          
               
        }
        public ProductViewModel Product { get; set; }
        public Order Order { get; set; }
        public AppUser AppUser { get; set; }
    }
}
