
using Microsoft.AspNetCore.Identity;

namespace testaundit.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int year { get; set; }
    }
}
