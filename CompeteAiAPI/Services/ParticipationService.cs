using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CompeteAiAPI.Repositories
{
    public class ParticipationService
    {
        private readonly ParticipationRepository _participationRepository;

        public ParticipationService(
            ParticipationRepository participationRepository)
        {
           _participationRepository = participationRepository;
        }

        public void add(Participation participation)
        {
            _participationRepository.add(participation);
        }

        public void remove(Participation participation)
        {
            _participationRepository.remove(participation);
        }

        public bool userIsRegistered(int userId, int tournamentId)
        {
            return null != _participationRepository.getByUserAndTournament(userId, tournamentId);
        }

        public IQueryable<Participation> getByTournament(int tournamentId)
        {
            return _participationRepository.getByTournament(tournamentId);
        }

        public IQueryable<Participation> getAll()
        {
            return _participationRepository.getAll();
        }
    }
}
