using System.ComponentModel.DataAnnotations;

namespace Project.CommunicateService.Dtos.VideoCallDtos
{
    public class CreateVideoCallDtos
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public IFormFile Video { get; set; }
        [Required]
        public Guid RoomID { get; set; }
    }
}
