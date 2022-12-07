using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een titel in te vullen.")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Gelieve een omschrijving in te vullen.")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Gelieve een duurtijd in te vullen.")]
        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        // foreign keys
        public int GenreId { get; set; }

        // navigation properties
        public ICollection<Personage> Personages { get; set; }

        public ICollection<FilmTaal> FilmTalen { get; set; }
        public Genre Genre { get; set; }
    }
}