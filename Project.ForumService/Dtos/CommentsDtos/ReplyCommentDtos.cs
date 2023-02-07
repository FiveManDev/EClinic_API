using System.Text.Json.Serialization;

namespace Project.ForumService.Dtos.CommentsDtos
{
    public class ReplyCommentDtos
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public List<Guid> LikeUserIds { get; set; }
        public int Likes { get; set; } = 0;
        public bool IsLike { get; set; }
    }
}
