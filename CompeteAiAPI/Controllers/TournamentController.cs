using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Identity.Core;
using Microsoft.AspNet.Identity;
using CompeteAiAPI.Repositories;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly TournamentService _tournamentService;

        public TournamentController(
           Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager,
           TournamentService tournamentService)
        {
            _userManager = userManager;
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<TournamentDTO>>> GetTournaments(
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {

            return await ApiResult<TournamentDTO>.CreateAsync(
                   _tournamentService.getAll()
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
            var city = _tournamentService.get(id);

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

            if (User.Identity.IsAuthenticated)
            {
                // Get the user's ID
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine(userId);
                tournament.HostId = int.Parse(userId);
               
                
            }
            else
            {
                Console.WriteLine("not auth");
                return Unauthorized();
            }

            _tournamentService.update(tournament);

            

            return NoContent();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            tournament.HostId = int.Parse(userId);
           


           _tournamentService.add(tournament);

            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
           _tournamentService.delete(id);

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _tournamentService.get(id) != null;   
        }
    }
}
