﻿namespace Project.BlogService.Events
{
    public class UpdateProfileEvents
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
