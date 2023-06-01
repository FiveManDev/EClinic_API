using Newtonsoft.Json;
using Project.CommunicateService.Data;

namespace Project.CommunicateService.Dtos.ChatMessageDtos
{
    public class ChatMessageDto
    {
        public Guid ChatMessageID { get; set; }
        [JsonIgnore]
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public bool IsImage { get; set; }
        [JsonIgnore]
        public MessageType Type { get; set; }
        public bool IsMyChat { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
