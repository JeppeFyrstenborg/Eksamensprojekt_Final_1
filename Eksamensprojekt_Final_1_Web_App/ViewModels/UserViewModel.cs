using DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Eksamensprojekt_Final_1_Web_App.ViewModels
{
    public class UserViewModel
    {
        public UserAuth UserAuth { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password mangler")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W)(?!.*\s).{8,}$",
    ErrorMessage = "The password must have at least 8 characters, including one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Display(Name = "Gentag password")]
        [Required(ErrorMessage = "Password-tjek mangler")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "De to adgangskoder er ikke ens")]
        public string PasswordCheck { get; set; }

        public Chat SelectedChat { get; set; }
    }
}