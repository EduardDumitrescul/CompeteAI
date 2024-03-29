﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompeteAiAPI.Data.Models
{
    [Table("Participations")]
    [PrimaryKey(nameof(RegisteredUserId), nameof(RegisteredTournamentId))]
    [Index(nameof(RegisteredUserId))]
    [Index(nameof(RegisteredTournamentId))]
    public class Participation
    {
        
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public int? RegisteredUserId {  get; set; }

        [ForeignKey(nameof(Tournament))]
        [Required]
        public int? RegisteredTournamentId { get; set; }

        public ApplicationUser? RegisteredUser { get; set; } = null!;

        public Tournament? RegisteredTournament { get; set; } = null!;

        public Result ParticipationResult { get; set; }
    }

}
