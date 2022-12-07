using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Taal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een taal in te vullen.")]
        public string GesprokenTaal { get; set; }

        // navigation properties
        public ICollection<FilmTaal> FilmTalen { get; set; }
    }
}