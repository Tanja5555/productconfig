using System;
using System.Collections.Specialized;
using System.Linq;
using TanLeonaShop.Domain.Models;

namespace TanLeonaShop.Domain
{
    public static class Helper
    {
        public static Order FillOrderProperties(this Order order, Product product, NameValueCollection form)
        {
            var orderCode = product.ProductCode;
            foreach (var option in product.Options)
            { 
                foreach (var item in option.OptionChoices)
                    item.IsCheckedOptionChoice = false;

                if (form[option.OptionName] != null)
                {
                    var selectedChoice = option.OptionChoices.Single(och => och.Id == Int32.Parse(form[option.OptionName]));
                    orderCode += "-" + selectedChoice.OptionChoiceCode;
                    foreach (var choice in option.OptionChoices)
                        if (choice.Id == selectedChoice.Id)
                            choice.IsCheckedOptionChoice = true;
                }
            }
            order.DeliveryDate = product.Options
                                    .SelectMany(o => o.OptionChoices)
                                    .Where(oc => oc.IsCheckedOptionChoice)
                                    .Max(a => a.OptionChoiceDeliveryDate);
            order.TotalPrice = product.Options
                                    .SelectMany(o => o.OptionChoices)
                                    .Where(oc => oc.IsCheckedOptionChoice)
                                    .Sum(a => (decimal)a.OptionChoicePrice);
            //order.TotalPrice += (product.ProductPrice.HasValue) ? product.ProductPrice.Value : 0;
            order.TotalPrice += (decimal)product.ProductPrice;
            order.OrderCode = orderCode;
            return order;
        }
    }
}
