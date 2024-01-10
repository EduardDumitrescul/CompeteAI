using Microsoft.EntityFrameworkCore;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CompeteAiAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base()
        {

        }

        public ApplicationDbContext(DbContextOptions options): base(options) { }    



    }
}
