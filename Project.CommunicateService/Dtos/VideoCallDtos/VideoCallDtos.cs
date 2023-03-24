namespace Project.CommunicateService.Dtos.VideoCallDtos
{
    public class VideoCallDtos
    {
        public Guid VideoCallID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string VideoUrl { get; set; }
    }
}
