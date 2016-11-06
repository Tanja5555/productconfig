using System;
using System.Collections.Generic;


namespace TanLeonaShop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double ? ProductPrice { get; set; }
        public DateTime ? ProductDeliveryDate { get; set; }
        public string ProductImage { get; set; }
        public virtual ICollection<Option> Options { get; set; }
            
    }
}
