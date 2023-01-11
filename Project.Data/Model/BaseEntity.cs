namespace Project.Data.Model
{
    public class BaseEntity
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
