using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een genre in te vullen.")]
        public string FilmGenre { get; set; }

        // navigation properties
        public List<Film> Films { get; set; }
    }
}