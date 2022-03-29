using System.ComponentModel.DataAnnotations;
namespace ChallengeAlternativo.ViewModels.Auth
{
    public class LoginResponseViewModel

    {
        [Required]
        [MinLength(6)]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public DateTime ValidTo { get; set; }       


    }
}
