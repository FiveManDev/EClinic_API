﻿using System.ComponentModel.DataAnnotations;

namespace Project.ProfileService.Dtos.EmployeeProfile
{
    public class UpdateEmployeeProfileDtos
    {
        [Required]
        public Guid ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime WorkStart { get; set; }
        public DateTime? WorkEnd { get; set; } = null;
        [Required]
        public string Description { get; set; }
        [Required]
        public bool EnabledAccount { get; set; }
    }
}
