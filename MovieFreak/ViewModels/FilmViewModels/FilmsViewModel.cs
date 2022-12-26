using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class FilmsViewModel
    {
        public List<FilmTaal> FilmTalen { get; set; }
        public Genre Genre { get; set; }
    }
}