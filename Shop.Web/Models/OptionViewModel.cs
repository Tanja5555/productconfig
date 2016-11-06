using System.Collections.Generic;
using TanLeonaShop.Domain.Models;
using System.Linq;


namespace Shop.Web.Models
{
    public class OptionViewModel
    {
        public OptionViewModel()
        {

        }

        public OptionViewModel(Option option)
        {
            Id = option.Id;
            OptionName = option.OptionName;
            OptionChoices = option.OptionChoices.Select(och => new OptionChoiceViewModel(och)).ToList();
            SelectedOptionChoice = option.OptionChoices.FirstOrDefault(och => och.IsCheckedOptionChoice);
        }

        public int Id { get; set; }
        public string OptionName { get; set; }
        public IList<OptionChoiceViewModel> OptionChoices { get; set; }

        public OptionChoice SelectedOptionChoice { get; set; }
       

    }
}