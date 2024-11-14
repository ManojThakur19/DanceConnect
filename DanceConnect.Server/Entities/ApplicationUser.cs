using DanceConnect.Server.Enums;
using Microsoft.AspNetCore.Identity;

namespace DanceConnect.Server.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public UserType UserType { get; set; } = UserType.User;
        public bool Active { get; set; } = true;
    }

    public class ApplicationRole : IdentityRole
    {
        
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

}
