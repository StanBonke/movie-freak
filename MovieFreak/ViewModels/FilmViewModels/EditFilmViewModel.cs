using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class EditFilmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Duration cannot be empty")]
        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Genre id can't be 0")]
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }
    }
}