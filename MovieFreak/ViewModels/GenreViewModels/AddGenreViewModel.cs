using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.GenreViewModels
{
    public class AddGenreViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre can't be empty.")]
        public string FilmGenre { get; set; }
    }
}