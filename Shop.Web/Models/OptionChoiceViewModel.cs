using System;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Models
{
    public class OptionChoiceViewModel
    {
        public OptionChoiceViewModel()
        {

        }

        public OptionChoiceViewModel(OptionChoice optionChoice)
        {
            Id = optionChoice.Id;
            OptionChoiceName = optionChoice.OptionChoiceName;
            OptionChoiceCode = optionChoice.OptionChoiceCode;
            OptionChoicePrice = optionChoice.OptionChoicePrice;
            OptionChoiceDeliveryDate = optionChoice.OptionChoiceDeliveryDate;
            IsCheckedOptionChoice = optionChoice.IsCheckedOptionChoice;
            
        }

        public int Id { get; set; }
        public bool IsCheckedOptionChoice { get; set; }
        public string OptionChoiceCode { get; set; }
        public DateTime OptionChoiceDeliveryDate { get; set; }
        public string OptionChoiceName { get; set; }
        public double OptionChoicePrice { get; set; }
      

       

     
    }
}