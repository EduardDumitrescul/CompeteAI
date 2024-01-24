using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;

namespace CompeteAiAPI.Repositories
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(
            UserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        public IQueryable<ApplicationUser> getAll()
        {
            return _userRepository.getAll();
        }
    }
}
