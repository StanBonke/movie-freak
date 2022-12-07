namespace MovieFreak.Models
{
    public class FilmTaal
    {
        public int Id { get; set; }

        // navigation properties
        public Film Film { get; set; }

        public Taal Taal { get; set; }
    }
}