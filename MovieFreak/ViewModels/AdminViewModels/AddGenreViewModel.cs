using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class AddGenreViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een genre in te vullen.")]
        public string FilmGenre { get; set; }
    }
}