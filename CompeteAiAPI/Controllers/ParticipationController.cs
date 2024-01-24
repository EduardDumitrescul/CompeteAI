using CompeteAiAPI.Data;
using CompeteAiAPI.Data.DTO;
using CompeteAiAPI.Data.Models;
using CompeteAiAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompeteAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipationController : ControllerBase
    {
        private readonly ParticipationService _participationService;
        private readonly ResultService _resultService;
        public ParticipationController(
            ParticipationService participationService,
            ResultService resultService
            )
        {
            _participationService = participationService;
            _resultService = resultService;
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

            this._participationService.add(p);
            this._resultService.add(result);
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

            this._participationService.remove(p);
            return Ok("User junregistered");
        }

        [HttpGet("IsUserRegistered")]
        public async Task<bool> UserIsRegistered(int userId, int tournamentId)
        {
            return this._participationService.userIsRegistered(userId, tournamentId);
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
                   this._participationService.getByTournament(tournamentId)
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
                    this._participationService.getAll()
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
