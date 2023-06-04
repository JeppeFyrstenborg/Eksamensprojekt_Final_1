using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eksamensprojekt_Final_1_Web_App.ViewModels
{
    public class UserChatViewModel
    {
        //Bruger denne ViewModel til at mit partial view vedrørende chats på en bruger.
        //Knapperne som viser beskeder i chatten skal have et brugerId og et chatId. 
        //Det gør det derfor nemmere.
        public int UserId { get; set; }

        public List<Chat> Chats { get; set; }


    }
}