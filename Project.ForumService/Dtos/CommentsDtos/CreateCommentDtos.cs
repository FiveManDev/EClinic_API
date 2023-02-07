namespace Project.ForumService.Dtos.CommentsDtos
{
    public class CreateCommentDtos
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
    }
}
