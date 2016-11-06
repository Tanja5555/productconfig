using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {

        //public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Fel typ av input")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}