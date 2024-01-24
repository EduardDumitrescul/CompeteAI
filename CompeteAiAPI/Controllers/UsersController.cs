using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using CompeteAiAPI.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;

        public UsersController(
            UserService userService,
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        //[HttpGet("get")]
        //public IEnumerable<UserDto> Get()
        //{
        //    List<ApplicationUser> users = _userManager.Users.ToList();
        //    return users.ConvertAll(user => new UserDto()
        //    {
        //        Id = user.Id,
        //        Firstname = user.FirstName,
        //        Lastname = user.LastName,
        //    }) ;
        //}

        [HttpGet("CurrentUser")]
        public async Task<ActionResult<ApplicationUser>> GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Get the user's ID
                var currentUser = await this._userManager.FindByIdAsync(User.Identity.GetUserId());
                return currentUser;
            }
            else
            {
                Console.WriteLine("not auth");
                return Unauthorized();
            }
        }
        [HttpGet("CurrentUserIsAdmin")]
        public async Task<ActionResult<bool>> CurrentUserIsAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await this._userManager.FindByIdAsync(User.Identity.GetUserId());
                if(currentUser == null )
                {
                    return false;
                }
                return await this._userManager.IsInRoleAsync(currentUser, "Administrator");
            }
            else
            {
                Console.WriteLine("not auth");
                return Unauthorized();
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<UserDto>>> GetUsers(
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {
            List<ApplicationUser> users = _userManager.Users.ToList();

            return await ApiResult<UserDto>.CreateAsync(
                   _userService.getAll()
                        .Select(c => new UserDto()
                        {
                            Id = c.Id,
                            Firstname = c.FirstName,
                            Lastname = c.LastName,
                          
                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

       
    } 
}
