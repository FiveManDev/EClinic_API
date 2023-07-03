using Moq;
using Project.ProfileService.Data;
using Project.ProfileService.Repository.DoctorProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;
using System.Linq.Expressions;

namespace Project.ProfileService.Test.Mocks
{
    public static class MockProfileRepository
    {
        private static FakeData fakeData = new FakeData();
        public static Mock<IProfileRepository> GetProfileRepository()
        {
            var Profiles = fakeData.GetProfile();
            var mockRepo = new Mock<IProfileRepository>();

            mockRepo.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Profile, bool>>>())).ReturnsAsync((Expression<Func<Profile, bool>> filter) =>
            {
                var filteredProfiles = Profiles.Where(filter.Compile());
                return filteredProfiles.ToList();
            });
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(Profiles);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Profile>())).ReturnsAsync((Profile Profile) =>
            {
                Profile.ProfileID = Guid.NewGuid();
                Profiles.Add(Profile);
                return true;
            });
            mockRepo.Setup(r => r.CreateEntityAsync(It.IsAny<Profile>())).ReturnsAsync((Profile Profile) =>
            {
                Profile.ProfileID = Guid.NewGuid();
                Profiles.Add(Profile);
                return Profile;
            });
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Profile>())).ReturnsAsync((Profile Profile) =>
            {
                Profiles.Remove(Profile);
                Profiles.Add(Profile);
                return true;
            });
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Profile>())).ReturnsAsync((Profile Profile) =>
            {
                Profiles.Remove(Profile);
                return true;
            });
            return mockRepo;
        }
        public static Mock<IDoctorProfileRepository> GetRoleRepository()
        {

            var doctor = fakeData.GetDoctorProfile();
            var mockRepo = new Mock<IDoctorProfileRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(doctor);
            return mockRepo;
        }
    }
}
