using Microsoft.AspNetCore.Identity;
namespace ChallengeAlternativo.Models
 
{
    public class User:IdentityUser
    {
        public bool IsActive { get; set; }

    }
}
