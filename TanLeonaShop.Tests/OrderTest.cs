using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanLeonaShop.Domain.Services;
using TanLeonaShop.Domain.Models;
using Shop.Web.Repository;
using Shop.Web.Models;

namespace TanLeonaShop.Tests
{
    [TestClass]
    public class OrderTest
    {
        private TestService _testService;
        private FakeProductRepository _fakeProductRepo;

        [TestInitialize]
        public void TestSetup()
        {
            _fakeProductRepo = new FakeProductRepository();
            _testService = new TestService(_fakeProductRepo);
        }


        [TestMethod]
        public void Can_save_order()
        {
            var order = new Order();
            order.Product = _fakeProductRepo.Get(1);

            var result = _testService.AddOrder(order);
            Assert.IsTrue(result);

        }
    }
}
