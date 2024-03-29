﻿using MovieFreak.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class AdminViewModel
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

        public List<Film> Films { get; set; }
    }
}