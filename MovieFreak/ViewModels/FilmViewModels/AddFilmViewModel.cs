using Microsoft.AspNetCore.Mvc.Rendering;
using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class AddFilmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een titel in te vullen.")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Gelieve een omschrijving in te vullen.")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Gelieve een duurtijd in te vullen.")]
        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }
    }
}