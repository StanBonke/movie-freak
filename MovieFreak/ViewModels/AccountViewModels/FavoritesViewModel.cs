using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.AccountViewModels
{
    public class FavoritesViewModel
    {
        public List<Film> Films { get; set; }
        public Genre Genre { get; set; }

        // SEARCH
        public string Search { get; set; }
    }
}