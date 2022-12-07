namespace MovieFreak.Models
{
    public class FilmTaal
    {
        public int Id { get; set; }

        // foreign keys
        public int FilmId { get; set; }

        public int TaalId { get; set; }

        // navigation properties
        public Film Film { get; set; }

        public Taal Taal { get; set; }
    }
}