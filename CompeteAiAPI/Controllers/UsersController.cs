using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
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
                    _context.Users.AsQueryable()
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
