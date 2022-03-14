namespace PreAceleracionAlkemy.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }  
        public string Content { get; set; }

       // public string User { get; set; }

       // public User User { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();



    }
}
