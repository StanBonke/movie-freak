﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Persoon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname cannot be empty")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Lastname cannot be empty")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Date of birth cannot be empty")]
        public DateTime Geboortedatum { get; set; }

        public string Geboorteplaats { get; set; }
        public string Geboorteland { get; set; }

        public string Biografie { get; set; }

        [Required(ErrorMessage = "Give this person a role (actor or director)")]
        public string Rol { get; set; }

        // navigation properties
        public List<Personage> Personages { get; set; }
    }
}