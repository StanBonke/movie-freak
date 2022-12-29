using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieFreak.ViewModels.UserViewModels
{
    public class UserRoleViewModel
    {
        public SelectList Users { get; set; }
        public SelectList Rollen { get; set; }
        public string UserId { get; set; }
        public string RolId { get; set; }
    }
}