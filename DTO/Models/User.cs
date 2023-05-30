using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DTO.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Brugernavn")]
        [Required(ErrorMessage = "Du har ikke indtastet brugernavn")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Brugernavn skal mindst have 3 bogstaver")]
        public string Username { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Du har ikke indtastet e-mail")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail er ikke i en gyldig format")]
        public string Email { get; set; }

        [Display(Name = "Fødselsdag")]
        [Required(ErrorMessage = "Du har ikke indtastet fødselsdag")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public List<Chat> Chats { get; set; }
        public User()
        {
            this.Birthday = DateTime.Now;
        }



        public User(string username, string email, DateTime birthDay)
        {
            this.Username = username;
            this.Email = email;
            Birthday = birthDay;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
