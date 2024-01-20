using CompeteAiAPI.Data;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipationController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("RegisterUser")]
        public async Task<IActionResult> RegisterUser(int userId, int tournamentId)
        {
            //bool registered = await UserIsRegistered(userId, tournamentId);
            //if(registered == true)
            //{ 
            //    return BadRequest("User already registered");
            //}

            Participation p = new Participation
            {
                RegisteredUserId = userId,
                RegisteredTournamentId = tournamentId
            };

            _context.Participations.Add(p);
            _context.SaveChanges();
            return Ok("User registered");
        }

        [HttpPut("UnregisterUser")]
        public async Task<IActionResult> UnregisterUser(int userId, int tournamentId)
        {
            //bool registered = await UserIsRegistered(userId, tournamentId);
            //if (registered == false)
            //{ 
            //    return BadRequest("User is not registered");
            //}

            Participation p = new Participation
            {
                RegisteredUserId = userId,
                RegisteredTournamentId = tournamentId
            };

            _context.Participations.Remove(p);
            _context.SaveChanges();
            return Ok("User junregistered");
        }

        [HttpGet("IsUserRegistered")]
        public async Task<bool> UserIsRegistered(int userId, int tournamentId)
        {
            return null != _context.Participations.Find(userId, tournamentId);
        }

        [HttpGet]
        public async Task<IEnumerable<Participation>> get()
        {
            return _context.Participations;
        }
    }
}
