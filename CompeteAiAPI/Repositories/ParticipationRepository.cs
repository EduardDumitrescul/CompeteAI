using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CompeteAiAPI.Repositories
{
    public class ParticipationRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipationRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(Participation participation)
        {
            _context.Participations.Add(participation);
            _context.SaveChanges();
        }

        public void remove(Participation participation)
        {
            _context.Participations.Remove(participation);
            _context.SaveChanges();
        }

        public bool userIsRegistered(int userId, int tournamentId)
        {
            return null != _context.Participations.Find(userId, tournamentId);
        }

        public IQueryable<Participation> getByTournament(int tournamentId)
        {
            return _context.Participations.AsNoTracking()
                        .Where(c => c.RegisteredTournamentId.Equals(tournamentId));
        }

        public IQueryable<Participation> getAll()
        {
            return _context.Participations.AsNoTracking();
        }
    }
}
