﻿using Moq;
using Project.IdentityService.Data;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Test.Mocks
{
    public static class MockUserRepository
    {
        private static FakeData fakeData = new FakeData();
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = fakeData.GetUsers();
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<User>())).ReturnsAsync((User User) =>
            {
                users.Add(User);
                return true;
            });
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>())).ReturnsAsync((User User) =>
            {
                users.Remove(User);
                users.Add(User);
                return true;
            });
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<User>())).ReturnsAsync((User User) =>
            {
                users.Remove(User);
                return true;
            });
            return mockRepo;
        }
        public static Mock<IRoleRepository> GetRoleRepository()
        {

            var roles = fakeData.GetRoles();
            var mockRepo = new Mock<IRoleRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(roles);
            return mockRepo;
        }
    }
}
