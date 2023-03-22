using Project.CommunicateService.Data;
using Project.Data.Repository.MSSQL;

namespace Project.CommunicateService.Repository.ChatMessageRepositories
{
    public interface IChatMessageRepository : IMSSQLRepository<ChatMessage>
    {
    }
}
