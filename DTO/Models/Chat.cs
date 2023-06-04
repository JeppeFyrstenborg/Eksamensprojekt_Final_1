using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public class Chat
    {
        public int ChatId { get; set; }

        [Display(Name = "Navn på Chat")]
        [Required(ErrorMessage = "Du har ikke indtastet navn på chat")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Navnet på chatten skal mindst have 3 bogstaver")]
        public string ChatName { get; set; }

        public DateTime CreationDate { get; set; }

        public List<Message> Messages { get; set; }

        public List<User> Users { get; set; }

        public Chat()
        {
            this.Messages = new List<Message>();
            this.Users = new List<User>();
            this.CreationDate = DateTime.Now;
        }

        public Chat(string chatName)
        {
            ChatName = chatName;
            CreationDate = DateTime.Now;
            Messages = new List<Message>();
            Users = new List<User>();
        }

        public override string ToString()
        {
            return ChatName;
        }
    }
}
