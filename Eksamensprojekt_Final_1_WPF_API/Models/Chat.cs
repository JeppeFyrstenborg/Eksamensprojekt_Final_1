using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.Models
{
    public class Chat
    {
        public int ChatId { get; set; }

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
