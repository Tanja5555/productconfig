using Microsoft.AspNet.Identity.EntityFramework;

namespace TanLeonaShop.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}

