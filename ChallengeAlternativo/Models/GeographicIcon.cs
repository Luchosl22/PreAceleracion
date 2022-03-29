namespace ChallengeAlternativo.Models
{
    public class GeographicIcon
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Denomination { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Height { get; set; }
        public string History { get; set; } 

        //Relacion con Ciudad , un icono esta en una sola ciudad

        public City City { get; set; }





}



}