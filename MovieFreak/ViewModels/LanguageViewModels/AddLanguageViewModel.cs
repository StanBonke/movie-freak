using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.LanguageViewModels
{
    public class AddLanguageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Language cannot be empty")]
        public string GesprokenTaal { get; set; }
    }
}