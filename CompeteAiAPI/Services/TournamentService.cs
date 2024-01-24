using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompeteAiAPI.Repositories
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService(
            TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public IQueryable<Tournament> getAll()
        {
            return _tournamentRepository.getAll();
        }

        public Tournament? get(int id)
        {
            return _tournamentRepository.get(id);
        }

        public void update(Tournament tournament)
        {
            _tournamentRepository.update(tournament);
        }

        public void add(Tournament tournament)
        {
            _tournamentRepository.add(tournament);
        }

        public void delete(Tournament tournament)
        {
            _tournamentRepository.delete    (tournament);
        }

        public void delete(int id)
        {
            _tournamentRepository.delete(id);
        }

    }
}
