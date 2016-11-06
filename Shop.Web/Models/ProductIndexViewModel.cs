using System.Collections.Generic;

namespace Shop.Web.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> Products{ get; set; }
    }
}