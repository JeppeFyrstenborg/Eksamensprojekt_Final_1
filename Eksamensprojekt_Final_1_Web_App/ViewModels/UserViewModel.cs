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

        //Lidt en hjælpe ViewModel til oprettelsen af en bruger. 
        //Den har nogle attributter for password, så jeg dermed også kan lave validation af brugerens adganskode.
        //Den har jeg ikke på hverken User eller UserAuth, da den kun fremgår som en hashed værdi.

        public UserAuth UserAuth { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password mangler")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W)(?!.*\s).{8,}$",
        ErrorMessage = "Adgangskoden skal være minimum 8 karakterer lang, " +
            "indeholde mindst ét stort bogstav, ét tal, og ét specielt tegn.")]
        public string Password { get; set; }

        [Display(Name = "Gentag password")]
        [Required(ErrorMessage = "Password-tjek mangler")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "De to adgangskoder er ikke ens")]
        public string PasswordCheck { get; set; }
    }
}