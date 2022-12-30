using System.ComponentModel.DataAnnotations;
using System;

namespace MovieFreak.ViewModels.PersonViewModels
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname can't be empty.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Lastname can't be empty.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Date of birth can't be empty.")]
        public DateTime Geboortedatum { get; set; }

        public string Geboorteplaats { get; set; }
        public string Geboorteland { get; set; }

        public string Biografie { get; set; }

        [Required(ErrorMessage = "Role can't be empty.")]
        [RegularExpression("Actor|Director", ErrorMessage = "Role must either be actor or director.")]
        public string Rol { get; set; }
    }
}