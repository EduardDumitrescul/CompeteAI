using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;

namespace CompeteAiAPI.Repositories
{
    public class ResultService
    {
        private readonly ResultRepository _resultRepository;

        public ResultService(
           ResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public void add(Result result)
        {
            _resultRepository.add(result);
        }

        public Result? get(int id)
        {
            return _resultRepository.get(id);
        }

        public Result? get(int userId, int tournamentId)
        {
            return _resultRepository.get(userId, tournamentId);
        }

        public void update(Result result)
        {
            _resultRepository.update(result);

        }

        public void delete(Result result)
        {
            _resultRepository.delete(result);
        }
    }
}
