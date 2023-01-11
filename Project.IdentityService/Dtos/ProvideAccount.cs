using System.ComponentModel.DataAnnotations;

namespace Project.IdentityService.Dtos
{
    public class ProvideAccount
    {
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
