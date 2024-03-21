
using Microsoft.AspNetCore.Identity;

namespace Auth.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }   
    public ApplicationUser()
    {
        Id = Guid.NewGuid();
        SecurityStamp = Guid.NewGuid().ToString();
    }

     public ApplicationUser(string userName, string email)
        : this()
    {

        UserName = userName;
        Email = email;
    }
}

 
