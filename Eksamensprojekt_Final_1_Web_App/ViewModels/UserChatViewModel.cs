using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eksamensprojekt_Final_1_Web_App.ViewModels
{
    public class UserChatViewModel
    {
        public int UserId { get; set; }

        public List<Chat> Chats { get; set; }


    }
}