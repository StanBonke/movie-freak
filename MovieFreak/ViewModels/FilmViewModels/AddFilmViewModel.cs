using Microsoft.AspNetCore.Mvc.Rendering;
using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class AddFilmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can't be empty.")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Description can't be empty.")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Duration can't be empty.")]
        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Genre id can't be 0.")]
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }
    }
}