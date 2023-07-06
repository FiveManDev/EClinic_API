using Project.ProfileService.Data;

namespace Project.ProfileService.Test.Mocks
{
    public class FakeData
    {
        public List<Profile> GetProfile()
        {
            var users = new List<Profile>
            {
                new Profile
                {
                    
                    UserID = Guid.Parse("0c2474d7-2c51-42b7-baa6-57253f372ced"),
                },
                 
            };
            return users;
        }
        public List<DoctorProfile> GetDoctorProfile()
        {
            var doctorProfile = new List<DoctorProfile>
            {
                
            };
            return doctorProfile;
        }
    }
}
