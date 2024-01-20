using Microsoft.EntityFrameworkCore;
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

        [ForeignKey(nameof(Result))]
        public int ResultId { get; set; }

        public Result? Result { get; set; } = null!;
    }

}
