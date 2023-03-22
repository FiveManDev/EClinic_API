using Project.CommunicateService.Data;
using Project.Data.Repository.MSSQL;

namespace Project.CommunicateService.Repository.VideoCallRepositories
{
    public interface IVideoCallRepository : IMSSQLRepository<VideoCall>
    {
    }
}
