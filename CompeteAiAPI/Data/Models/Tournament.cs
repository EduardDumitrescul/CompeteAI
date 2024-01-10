using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CompeteAiAPI.Data.Models
{
    [Table("Tournaments")]
    [Index(nameof(Name))]
    [Index(nameof(Game))]
    [Index(nameof(StartDate))]
    public class Tournament
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }    

        public string Game { get; set; }


        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int HostId { get; set; }

        public ApplicationUser? Host { get; set; } = null!;
    }
}
