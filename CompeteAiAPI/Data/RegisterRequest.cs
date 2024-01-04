using System.ComponentModel.DataAnnotations;

namespace CompeteAiAPI.Data
{
    public class RegisterRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set;}

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
