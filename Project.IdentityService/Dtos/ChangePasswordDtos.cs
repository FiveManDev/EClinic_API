using System.ComponentModel.DataAnnotations;

namespace Project.IdentityService.Dtos
{
    public class ChangePasswordDtos
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
