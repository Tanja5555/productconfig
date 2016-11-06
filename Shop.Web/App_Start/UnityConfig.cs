using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using TanLeonaShop.Domain.Services;
using TanLeonaShop.Domain.Repositories;
using Shop.Web.Repository;

namespace Shop.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}