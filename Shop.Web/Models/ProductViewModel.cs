using System.Collections.Generic;
using TanLeonaShop.Domain.Models;
using System.Linq;
using System;

namespace Shop.Web.Models
{
    public class ProductViewModel
    {

        public ProductViewModel()
        {

        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            ProductImage = product.ProductImage;
            ProductCode = product.ProductCode;
            ProductDeliveryDate = product.ProductDeliveryDate;
            ProductPrice = product.ProductPrice;
            Options = product.Options.Select(o => new OptionViewModel(o)).ToList();
        }

        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; private set; }
  
        public IList<OptionViewModel> Options { get; set; }

        public string ProductCode { get; set; }

        public DateTime? ProductDeliveryDate { get; set; }

        public double? ProductPrice { get; set; }
       
        public string SelectedOptionChoice { get; set; }
    }
}