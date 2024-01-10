using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<TournamentDTO>>> GetUsers(
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {

            return await ApiResult<TournamentDTO>.CreateAsync(
                    _context.Tournaments.AsNoTracking()
                        .Select(c => new TournamentDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Game = c.Game,
                            StartDate = c.StartDate,
                            Description = c.Description,
                            Host = c.Host,

                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var city = await _context.Tournaments.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))    
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var city = await _context.Tournaments.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.Id == id);
        }
    }
}
