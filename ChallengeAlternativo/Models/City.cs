namespace ChallengeAlternativo.Models
{
    public class City
    {
       
            public int Id { get; set; }
            public string Image { get; set; }
            public string Denomination { get; set; }
            public long Population { get; set; }
            public decimal Area { get; set; }
            // relacion con iconos , una ciudad puede tener varios iconos

            public Continent Continent { get; set; }

            public ICollection<GeographicIcon> GeographicIcons { get ; set; } = new List<GeographicIcon>();













    }
}
