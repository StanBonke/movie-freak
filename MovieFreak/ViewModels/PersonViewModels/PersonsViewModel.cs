using MovieFreak.Models;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.PersonViewModels
{
    public class PersonsViewModel
    {
        public List<Persoon> Personen { get; set; }

        // SEARCH
        public string PersonSearch { get; set; }
    }
}