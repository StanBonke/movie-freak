using Microsoft.AspNetCore.Identity;
using System;

namespace MovieFreak.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public string Gebruikersnaam { get; set; }
    }
}