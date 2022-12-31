using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class FilmsViewModel
    {
        public List<Film> Films { get; set; }
        public Genre Genre { get; set; }

        // SEARCH
        public string Search { get; set; }
    }
}