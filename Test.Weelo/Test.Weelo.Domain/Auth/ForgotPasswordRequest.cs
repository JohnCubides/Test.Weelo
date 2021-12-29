using System.ComponentModel.DataAnnotations;

namespace Test.Weelo.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
