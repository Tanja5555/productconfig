
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TanLeonaShop.Domain.Models;
using TanLeonaShop.Domain.Repositories;

namespace Shop.Web.Repository
{
    public class FakeProductRepository : IProductRepository
    {

        public Product Get(int id)
        {
            var product = new Product
            {
                Id = id,
                ProductName = "Car"
            };
            var option = new Option()
            {
                
                OptionName = "Color",
                ProductId = product.Id
            };
            product.Options = new Collection<Option>();
            product.Options.Add(option);

            var optionChoice = new OptionChoice()
            {
               
                OptionChoiceName = "Blue",
                OptionId = option.Id
            };
            option.OptionChoices = new Collection<OptionChoice>();
            option.OptionChoices.Add(optionChoice);

            return product;
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}