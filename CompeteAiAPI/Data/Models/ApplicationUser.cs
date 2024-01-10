using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace CompeteAiAPI.Data.Models
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}


    }
}
