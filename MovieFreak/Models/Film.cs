using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Duration cannot be empty")]
        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        // foreign keys
        public int GenreId { get; set; }

        // navigation properties
        public List<Personage> Personages { get; set; }

        public List<FilmTaal> FilmTalen { get; set; }
        public Genre Genre { get; set; }
    }
}