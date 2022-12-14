﻿using System.ComponentModel.DataAnnotations;

namespace MovieFreak.ViewModels
{
    public class CreateGebruikerViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}