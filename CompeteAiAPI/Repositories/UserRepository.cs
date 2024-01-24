using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;

namespace CompeteAiAPI.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> getAll()
        {
            return _context.Users.AsQueryable();
        }
    }
}
