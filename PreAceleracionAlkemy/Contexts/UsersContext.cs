using Microsoft.EntityFrameworkCore;
using PreAceleracionAlkemy.Models;
namespace PreAceleracionAlkemy.Contexts
{
    public class UsersContext:DbContext
    {
        private const string Schema = "usuarios";

        public UsersContext (DbContextOptions<UsersContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.HasDefaultSchema(Schema);
        }

        public DbSet<User> Users { get; set; }=null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

    }
}
