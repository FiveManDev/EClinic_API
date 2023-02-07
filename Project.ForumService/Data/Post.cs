using Project.Data.Model;

namespace Project.ForumService.Data
{
    public class Post : MongoDBEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Image { get; set; } = new string[] {};
        public Guid AuthorID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Guid> LikeUserIds { get; set; } = new List<Guid>();

    }
}
