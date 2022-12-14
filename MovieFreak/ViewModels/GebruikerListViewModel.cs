using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieFreak.ViewModels
{
    public class GebruikerListViewModel
    {
        public List<IdentityUser> Gebruikers { get; set; }
    }
}