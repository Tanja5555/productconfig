using System;
using System.Linq;
using System.Web;
using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;
using Microsoft.AspNet.Identity;

namespace TanLeonaShop.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
       
        public OrderService (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Create(int productId)
        {
            var order = _orderRepository.Create(productId);
            //Läg till DeliveryDate property på Order
            //var deliveryDate = order.Product.Options
            //    .SelectMany(o => o.OptionChoices)
            //    .Max(a => a.OptionChoiceDeliveryDate);
            //order.DeliveryDate = deliveryDate;
            //order.TotalPrice = order.Product.Options
            //    .SelectMany(o => o.OptionChoices)
            //    .Where(oc => oc.IsCheckedOptionChoice)
            //    .Sum(a => a.OptionChoicePrice);
            //order.TotalPrice += (order.Product.ProductPrice.HasValue) ? order.Product.ProductPrice.Value : 0;
            order.OrderDate = DateTime.Now;
            return order;
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public IQueryable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Save(Order order)
        {
            _orderRepository.Save(order);
        }

        public IQueryable<Order> GetUsersOrders()
        {
            return _orderRepository.GetUsersOrders();
        }

        public string GetCurrentUser()
        {
            var user = HttpContext.Current.User.Identity.GetUserId();
            return user;
        }
    }
}
