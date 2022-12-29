using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.UserViewModels
{
    public class UsersViewModel
    {
        public List<IdentityUser> Users { get; set; }

        // SEARCH
        public string UserSearch { get; set; }
    }
}