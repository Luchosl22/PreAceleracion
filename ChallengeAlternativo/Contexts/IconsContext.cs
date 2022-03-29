using Microsoft.EntityFrameworkCore;
using ChallengeAlternativo.Models;
namespace ChallengeAlternativo.Contexts
{
    public class IconsContext : DbContext
    {
        private const string Schema = "icons";


        public IconsContext(DbContextOptions<IconsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
        }
             

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Continent> Continents { get; set; } = null!;
        public DbSet<GeographicIcon> GeographicIcons { get; set; } = null!;
    }


}
