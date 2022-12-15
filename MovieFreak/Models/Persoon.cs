using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Persoon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een voornaam in te vullen.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Gelieve een achternaam in te vullen.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Gelieve een geboortedatum in te vullen.")]
        public DateTime Geboortedatum { get; set; }

        public string Geboorteplaats { get; set; }
        public string Geboorteland { get; set; }

        public string Biografie { get; set; }

        [Required(ErrorMessage = "Gelieve een rol toe dienen.")]
        public string Rol { get; set; }

        // navigation properties
        public List<Personage> Personages { get; set; }
    }
}