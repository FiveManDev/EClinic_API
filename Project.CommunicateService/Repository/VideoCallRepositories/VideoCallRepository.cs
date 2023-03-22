using Project.CommunicateService.Data;
using Project.CommunicateService.Data.Configurations;
using Project.Data.Repository.MSSQL;

namespace Project.CommunicateService.Repository.VideoCallRepositories
{
    public class VideoCallRepository : MSSQLRepository<ApplicationDbContext, VideoCall>, IVideoCallRepository
    {
        public VideoCallRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
