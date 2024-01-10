using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CompeteAiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            JwtHandler jwtHandler
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password)) {
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password."
                });
            }

            var secToken = await _jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Login Successful",
                Token = jwt
            });
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            string role_RegisteredUser = "RegisteredUser";

            if (registerRequest == null)
            {
                return Unauthorized(new RegisterResult()
                {
                    Success= false,
                    Message = "Invalid Request",
                });
            }

            var user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
            };

            // insert the user into the DB
            await _userManager.CreateAsync(user, registerRequest.Password);

            // assign the "RegisteredUser" role
            await _userManager.AddToRoleAsync(user, role_RegisteredUser);

            // confirm the e-mail and remove lockout
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;


            var secToken = await _jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);

            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Registration Successful",
                Token = jwt
            });
        }
    }
}
