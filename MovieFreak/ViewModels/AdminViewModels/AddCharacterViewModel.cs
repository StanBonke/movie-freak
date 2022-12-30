using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class AddCharacterViewModel
    {
        public string VoornaamPersonage { get; set; }
        public string AchternaamPersonage { get; set; }

        // foreign keys

        [Range(1, int.MaxValue, ErrorMessage = "Persoon id can't be 0.")]
        public int PersoonId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Film id can't be 0.")]
        public int FilmId { get; set; }
    }
}