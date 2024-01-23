using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            Result result = new Result
            {
                RoundsPlayed = 0,
                Wins = 0,
                RegisteredTournamentId = tournamentId,
                RegisteredUserId = userId
            };

            Participation p = new Participation
            {
                RegisteredUserId = userId,
                RegisteredTournamentId = tournamentId, 
                ParticipationResult = result
            };

            _context.Participations.Add(p);
            _context.Results.Add(result);
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

        [HttpGet("Tournament")]
        public async Task<ActionResult<ApiResult<ParticipationDTO>>> GetParticipantsForTournament(
                int tournamentId, 
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {

            return await ApiResult<ParticipationDTO>.CreateAsync(
                    _context.Participations.AsNoTracking()
                        .Where(c => c.RegisteredTournamentId.Equals(tournamentId))
                        .Select(c => new ParticipationDTO()
                        {
                           UserId = c.RegisteredUserId,
                           TournamentId = c.RegisteredTournamentId,
                           Username = c.RegisteredUser.UserName,
                           ResultId = c.ParticipationResult.Id,
                           RoundsPlayed = c.ParticipationResult.RoundsPlayed,
                           Wins = c.ParticipationResult.Wins,


                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<ParticipationDTO>>> GetParticipants(
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {

            return await ApiResult<ParticipationDTO>.CreateAsync(
                    _context.Participations.AsNoTracking()
                        .Select(c => new ParticipationDTO()
                        {
                            UserId = c.RegisteredUserId,
                            Username = c.RegisteredUser.UserName,
                            TournamentId = c.RegisteredTournamentId,
                            ResultId = c.ParticipationResult.Id,
                            RoundsPlayed = c.ParticipationResult.RoundsPlayed,
                            Wins = c.ParticipationResult.Wins,


                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }
    }
}
