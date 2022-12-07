namespace MovieFreak.Models
{
    public class Personage
    {
        public int Id { get; set; }
        public string voornaamPersonage { get; set; }
        public string achternaamPersonage { get; set; }

        // foreign keys
        public int filmId { get; set; }

        public int persoonId { get; set; }

        // navigation properties
        public Film Film { get; set; }

        public Persoon Persoon { get; set; }
    }
}