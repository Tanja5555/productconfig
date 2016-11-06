using System.Collections.Generic;


namespace TanLeonaShop.Domain.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public virtual ICollection<OptionChoice> OptionChoices { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
