﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<Chat> Chats { get; set; }
        public User() { }



        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}