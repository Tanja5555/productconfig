using System.Linq;
using TanLeonaShop.Domain.Models;

namespace TanLeonaShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Order Create(int productId);

        IQueryable<Order> GetAll();

        Order Get(int id);

        void Save(Order order);

        IQueryable<Order> GetUsersOrders();

        string GetCurrentUser();
    }
}
