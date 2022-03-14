namespace PreAceleracionAlkemy.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Password { get; set; }
 
        public string Email { get; set; }

        //public string Post { get; set; } 

       // public string Comment { get; set; }

     
        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
