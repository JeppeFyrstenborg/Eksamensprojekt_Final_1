using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repositories;
using DTO.Models;
using Eksamensprojekt_Final_1_Web_App.ViewModels;

namespace Eksamensprojekt_Final_1_Web_App.Controllers
{
    public class HomeController : Controller
    {

        private ChatRepository ChatRepository = new ChatRepository();

        // GET: Home
        public ActionResult GetChats()
        {
            List<Chat> chats = ChatRepository.GetAllChats();

            return View("Chats", chats);
        }

        [ChildActionOnly]
        public ActionResult _chatListView(int? id)
        {
            UserChatViewModel userChatViewModel = new UserChatViewModel();

            userChatViewModel.UserId = (int)id;
            userChatViewModel.Chats = ChatRepository.GetChatsForUserID((int)id);

            return PartialView(userChatViewModel);
        }
    }
}