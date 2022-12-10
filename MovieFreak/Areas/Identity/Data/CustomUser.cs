using Microsoft.AspNetCore.Identity;
using System;

namespace MovieFreak.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }

        [PersonalData]
        public string Lastname { get; set; }
    }
}