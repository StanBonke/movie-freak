using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre cannot be empty")]
        public string FilmGenre { get; set; }

        // navigation properties
        public List<Film> Films { get; set; }
    }
}