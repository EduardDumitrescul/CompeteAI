using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;

namespace CompeteAiAPI.Repositories
{
    public class ResultRepository
    {
        private readonly ApplicationDbContext _context;

        public ResultRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(Result result)
        {
            _context.Add(result);
            _context.SaveChanges();
        }

        public Result? get(int id)
        {
            return _context.Results.Find(id);
        }

        public Result? get(int userId, int tournamentId)
        {
            return _context.Results
                    .FirstOrDefault(x => x.RegisteredUserId == userId && x.RegisteredTournamentId == tournamentId);
        }

        public void update(Result result)
        {
            _context.Results.Update(result);

        }

        public void delete(Result result)
        {
            _context.Results.Remove(result);
            _context.SaveChanges();
        }
    }
}
