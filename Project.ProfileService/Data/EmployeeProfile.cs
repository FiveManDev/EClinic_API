﻿namespace Project.ProfileService.Data
{
    public class EmployeeProfile
    {
        public Guid ProfileID { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime WorkStart { get; set; }
        public string Description { get; set; }
        public Profile Profile { get; set; }
    }
}
