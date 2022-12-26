using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class DatalinkViewModel
    {
        public List<Film> Films { get; set; }
        public List<Persoon> Personen { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Taal> Talen { get; set; }
    }
}