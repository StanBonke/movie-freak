using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieFreak.ViewModels
{
    public class GrantPermissionViewModel
    {
        public SelectList Users { get; set; }
        public SelectList Rollen { get; set; }
        public string UserId { get; set; }
        public string RolId { get; set; }
    }
}