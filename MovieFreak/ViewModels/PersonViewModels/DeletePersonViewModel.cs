using System.ComponentModel.DataAnnotations;
using System;

namespace MovieFreak.ViewModels.PersonViewModels
{
    public class DeletePersonViewModel
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Geboorteplaats { get; set; }
        public string Geboorteland { get; set; }
        public string Biografie { get; set; }
        public string Rol { get; set; }
    }
}