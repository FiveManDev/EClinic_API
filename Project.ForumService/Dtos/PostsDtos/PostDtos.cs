namespace Project.ForumService.Dtos.PostsDtos
{
    public class PostDtos
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Image { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Likes { get; set; }
        public bool IsLike { get; set; }
    }
}
