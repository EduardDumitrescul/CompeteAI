using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompeteAiAPI.Data.Models
{
    [Table("Results")]
    public class Result
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int RoundsPlayed { get; set; } = 0;

        public int Wins { get; set; } = 0;

        [ForeignKey(nameof(Participation))]
        public int ParticipationId { get; set; }

        public Participation? Participation { get; set; } = null!;
    }
}
