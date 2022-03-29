using ChallengeAlternativo.Models;
using ChallengeAlternativo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ChallengeAlternativo.ViewModels.Auth.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ChallengeAlternativo.ViewModels.Auth;

namespace ChallengeAlternativo.Controllers
{

    [ApiController]
    [Route(template:"api/[controller]")]
    public class AuthenticationController:ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;



           public AuthenticationController (UserManager<User> userManager,SignInManager<User> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [Route(template:"registro")]

        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            //revisar si existe usuario

            var userExists = await _userManager.FindByNameAsync(model.Username);

            // si existe devuelvo error

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }


            // si no existe , registrar usuario

            var user = new User

            { 
                UserName = model.Username,
                Email=model.Email,
                IsActive=true
            
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)

            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    value:new
                    { 
                        Status = "Error",
                        message = $"User Creation Failed!"
                        //message =$"User Creation Failed! Errors: {result.Errors.Select(x:IdentityError => x.Description)}" 
                        // $"{string.Join(separator:", ",values:result.Errors.Select(x:IdentityError => x.Description))}"
                    });


            }


            return Ok(new 
            
            { 
                status="Success",
                
                message = $"User created Successfully"
                      
            });
                                
                        
        }


        //Login
        [HttpPost]
        [Route(template:"login")]

        public async Task <IActionResult> Login(LoginRequestViewModel model)
        {
            // ver que el usuario exista y password sea correcta

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(model.Username);
                if (currentUser.IsActive)
                {
                    // Generar Token 
                    // Devolver token
                    return Ok(await GetToken(currentUser));

                }
            }

            return StatusCode(StatusCodes.Status401Unauthorized,
                value:new


            {

                Status ="Error",
                Message = $"El usuario {model.Username} no esta autorizado."

            });
                       
        }


         private async Task<LoginResponseViewModel> GetToken(User currentUser)
        {
            //  var userRoles:IList<string> = await _userManager.GetRolesAsync(currentUser);
            var UserRoles = await _userManager.GetRolesAsync(currentUser);

            var authClaims = new List<Claim>()
            {
                new Claim (type:ClaimTypes.Name,value:currentUser.UserName),
                new Claim(type:JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString())

            };


            // authClaims.AddRange(collection:userRoles.Select(X:string => new Claim (type:ClaimTypes.Role,value:X)));

            var authSigingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: "KeySecretaSuperLargaDeAUTORIZACION"));
            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigingKey, algorithm: SecurityAlgorithms.HmacSha256));

            return new LoginResponseViewModel
            {

                Token=new JwtSecurityTokenHandler().WriteToken(token),
                  ValidTo = token.ValidTo

            };

           
        }

    }
}
