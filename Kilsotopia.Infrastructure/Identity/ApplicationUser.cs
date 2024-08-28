using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kilsotopia.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string Provider { get; set; }
    }
}
