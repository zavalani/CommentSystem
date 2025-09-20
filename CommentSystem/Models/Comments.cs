namespace CommentSystem.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public DateTime CommentDate { get; set; }
        public string Text { get; set; }
    }
}
