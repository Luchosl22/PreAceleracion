namespace ChallengeAlternativo.Models
{
    public class Continent
    {


        public int Id { get; set; }  
        
        public string Denomination { get; set; }

        public ICollection <City> Cities { get; set; } = new List<City> ();

        //Relacion con ciudades
    }
}
