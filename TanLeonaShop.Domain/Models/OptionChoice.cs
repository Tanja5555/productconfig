using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace TanLeonaShop.Domain.Models
{
    public class OptionChoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, make your choice")]
        public string OptionChoiceName { get; set; }
        public string OptionChoiceCode { get; set; }

        public double OptionChoicePrice { get; set; }
        public DateTime OptionChoiceDeliveryDate { get; set; }
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }

        [NotMapped]
        
        public bool IsCheckedOptionChoice { get; set; }
    }
}
