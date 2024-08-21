using Amazon.DTOs;
using Amazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Amazon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registration(RegistrationDto userDto)
        {
            if(ModelState.IsValid)
            {
                //save 
                ApplicationUser user = new ApplicationUser();
                user.Email = userDto.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                user.UserName = userDto.UserName;
                user.Address = userDto.Address;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Image = userDto.Image;

                IdentityResult result = await userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Created Successfully");
                }
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Password",item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto UserDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(UserDto.UserName);
                if(user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, UserDto.Password);
                    if (found)
                    {
                        //Claims Token 
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, UserDto.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        SecurityKey securityKey = 
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));

                        SigningCredentials signing = 
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        // create token
                        JwtSecurityToken myToken = new JwtSecurityToken(
                            issuer: config["JWT: Issuer"],
                            audience: config["JWT: Audience"],
                            expires: DateTime.Now.AddMinutes(Convert.ToDouble(config["Jwt:DurationInMinutes"])),
                            claims: claims,
                            signingCredentials: signing
                            );
                        return Ok(new
                        {
                            token= new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration= myToken.ValidTo
                        });
                    }
                }
                return Unauthorized();
            }
            return Unauthorized();
        }
    }
}

