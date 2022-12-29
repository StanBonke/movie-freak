using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class DeleteFilmViewModel
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Omschrijving { get; set; }

        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        public int GenreId { get; set; }
    }
}