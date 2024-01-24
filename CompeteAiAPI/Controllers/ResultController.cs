using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using CompeteAiAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompeteAiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ResultService _resultService;

        public ResultController(
            ResultService resultService
            )
        {
            _resultService = resultService;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(int participationId, Result result)
        {
            this._resultService.add(result);
            return CreatedAtAction("GetResult", new { id = result.Id }, result);
        }

        [HttpPut("AddWin")]
        public async Task<ActionResult<Result>> AddWin(int userId, int tournamentId)
        {
            var result = this._resultService.get(userId, tournamentId);
          
            if(result != null)
            {
                result.Wins += 1;
                result.RoundsPlayed += 1;
                this._resultService.update(result);
                return CreatedAtAction("GetResult", new { id = result.Id }, result);
            }

            return NotFound();
        }

        [HttpPut("AddLoss")]
        public async Task<ActionResult<Result>> AddLoss(int userId, int tournamentId)
        {
            var result = this._resultService.get(userId, tournamentId);

            if (result != null)
            {
                result.RoundsPlayed += 1;
                this._resultService.update(result);
                return CreatedAtAction("GetResult", new { id = result.Id }, result);
            }

            return NotFound();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var result =this._resultService.get(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResult(int id, Result result)
        {
            if (id != result.Id)
            {
                return BadRequest();
            }

            this._resultService.update(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelteResult(int id)
        {
            var result = _resultService.get(id);
            if (result == null)
            {
                return NotFound();
            }

            _resultService.delete(result);

            return NoContent();
        }


        private bool ResultExists(int id)
        {
            return _resultService.get(id) != null;
        }
    }
}
