using Microsoft.EntityFrameworkCore;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CompeteAiAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(): base()
        {

        }

        public ApplicationDbContext(DbContextOptions options): base(options) { }    


        public DbSet<Tournament> Tournaments => Set<Tournament>();

        public DbSet<Participation> Participations => Set<Participation>();

        public DbSet<Result> Results => Set<Result>();
    }
}
