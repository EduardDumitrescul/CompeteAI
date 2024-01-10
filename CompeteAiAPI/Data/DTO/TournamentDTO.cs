using CompeteAiAPI.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompeteAiAPI.Data.DTO
{
    public class TournamentDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Game { get; set; }


        public DateTime? StartDate { get; set; }

        public string? Description { get; set; }

        public ApplicationUser? Host { get; set; }
    }
}
