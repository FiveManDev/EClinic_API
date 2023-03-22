using Project.CommunicateService.Data;
using Project.CommunicateService.Data.Configurations;
using Project.Data.Repository.MSSQL;

namespace Project.CommunicateService.Repository.ChatMessageRepositories
{
    public class ChatMessageRepository : MSSQLRepository<ApplicationDbContext, ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
