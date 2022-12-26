using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.AdminViewModels
{
    public class AddLanguageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Gelieve een taal in te vullen.")]
        public string GesprokenTaal { get; set; }
    }
}