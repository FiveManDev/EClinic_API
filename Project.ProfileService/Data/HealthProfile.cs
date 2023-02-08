namespace Project.ProfileService.Data
{
    public class HealthProfile
    {
        public Guid ProfileID { get; set; }
        public string BloodType { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Guid RelationshipID { get; set; }
        public Relationship Relationship { get; set; }
        public Profile Profile { get; set; }
    }
}
