using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFreak.Models
{
    public class Taal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Language cannot be empty")]
        public string GesprokenTaal { get; set; }

        // navigation properties
        public List<FilmTaal> FilmTalen { get; set; }
    }
}