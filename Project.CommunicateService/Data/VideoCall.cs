namespace Project.CommunicateService.Data
{
    public class VideoCall
    {
        public Guid VideoCallID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string VideoUrl { get; set; }
        public Guid RoomID { get; set; }
        public Room Room { get; set; }
    }
}
