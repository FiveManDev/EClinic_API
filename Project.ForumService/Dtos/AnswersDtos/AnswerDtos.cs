using Project.ForumService.Data;

namespace Project.ForumService.Dtos.AnswersDtos
{
    public class AnswerDtos
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public List<string> Tag { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Guid AuthorID { get; set; }
        public int Likes { get; set; }
        public bool IsLike { get; set; }
    }
}
