using System;
using System.ComponentModel.DataAnnotations;

namespace TanLeonaShop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public bool Delivered { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
