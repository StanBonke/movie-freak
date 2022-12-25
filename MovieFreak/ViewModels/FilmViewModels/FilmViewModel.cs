using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class FilmViewModel
    {
        public List<Film> Films { get; set; }
        public List<Personage> Personages { get; set; }
        public Genre Genre { get; set; }
    }
}