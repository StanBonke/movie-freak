using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class AddFilmLanguageViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Film id can't be 0")]
        public int FilmId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Taal id can't be 0")]
        public int TaalId { get; set; }
    }
}