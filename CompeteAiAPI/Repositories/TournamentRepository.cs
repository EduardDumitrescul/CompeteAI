using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompeteAiAPI.Repositories
{
    public class TournamentRepository
    {
        private readonly ApplicationDbContext _context;

        public TournamentRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Tournament> getAll()
        {
            return _context.Tournaments.AsNoTracking();
        }

        public Tournament? get(int id)
        {
            return _context.Tournaments.Find(id);
        }

        public void update(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
        }

        public void add(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
        }

        public void delete(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
        }

        public void delete(int id)
        {
            var tournament = _context.Tournaments.Find(id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
            }
        }

    }
}
