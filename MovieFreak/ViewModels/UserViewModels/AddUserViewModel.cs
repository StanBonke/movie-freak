using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels.UserViewModels
{
    public class AddUserViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}