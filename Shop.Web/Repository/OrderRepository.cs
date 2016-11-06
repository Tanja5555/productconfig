using Shop.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;
using Microsoft.AspNet.Identity;

namespace Shop.Web.Repository
{
    public class OrderRepository : IOrderRepository
    {
 
        readonly ShopContext _context = new ShopContext();

        public Order Create(int productId)
        {
            var order = new Order();
            var product = _context.dbProducts.Where(x => x.Id == productId).FirstOrDefault();
            order.Product = product;
            return order;
        }

        public Order Get(int id)
        {
            return _context.dbOrders.Where(x => x.Id == id).Include(x => x.Product.Options.Select(och => och.OptionChoices)).FirstOrDefault();
        }

        public IQueryable<Order> GetAll()
        {
            return _context.dbOrders.AsQueryable();
        }

        public string GetCurrentUser()
        {
            var user = HttpContext.Current.User.Identity.GetUserId();
            return user;
        }

        public IQueryable<Order> GetUsersOrders()
        {
            var userId = GetCurrentUser();
            var orders = GetAll().Where(x => x.AppUserId == userId);
            return orders;
        }

        public void Save(Order order)
        {
            if (order.Id == 0)
                _context.dbOrders.Add(order);
            else
                _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}