using MovieFreak.Models;
using System.Collections.Generic;
using System;

namespace MovieFreak.ViewModels.FilmViewModels
{
    public class FilmDetailsViewModel
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Omschrijving { get; set; }

        public string Duurtijd { get; set; }

        public string Trailerlink { get; set; }

        // foreign keys
        public int GenreId { get; set; }

        public List<Personage> Personages { get; set; }

        public List<FilmTaal> FilmTalen { get; set; }

        public Genre Genre { get; set; }

        public int BerekenLeeftijd(DateTime geboortedatum)
        {
            int age = (int)((DateTime.Now - geboortedatum).TotalDays / 365.242199);
            return age;
        }
    }
}