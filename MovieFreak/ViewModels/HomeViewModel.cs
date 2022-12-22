using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Omschrijving { get; set; }

        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        // foreign keys
        public int GenreId { get; set; }

        public List<FilmTaal> FilmTalen { get; set; }

        public Genre Genre { get; set; }

        // Voor het veranderen van de spotlight film
        public List<Film> Films { get; set; }
    }
}