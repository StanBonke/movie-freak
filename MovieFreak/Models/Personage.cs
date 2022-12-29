using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Personage
    {
        public int Id { get; set; }
        public string VoornaamPersonage { get; set; }
        public string AchternaamPersonage { get; set; }

        // foreign keys

        public int FilmId { get; set; }

        public int PersoonId { get; set; }

        // navigation properties
        public Film Film { get; set; }

        public Persoon Persoon { get; set; }
    }
}