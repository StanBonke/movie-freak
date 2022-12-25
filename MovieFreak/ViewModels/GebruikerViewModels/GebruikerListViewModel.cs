using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieFreak.ViewModels.GebruikerViewModels
{
    public class GebruikerListViewModel
    {
        public List<IdentityUser> Gebruikers { get; set; }
    }
}