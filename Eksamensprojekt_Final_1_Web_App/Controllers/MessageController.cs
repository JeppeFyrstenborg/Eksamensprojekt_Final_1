using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Eksamensprojekt_Final_1_Web_App.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository MessageRepository = new MessageRepository();
        // GET: Message
        public ActionResult GetMessages()
        {
            List<Message> messages = MessageRepository.GetAllMessages();


            return View("Messages", messages);
        }

        public ActionResult _messagesListView(int? id, int? id2)
        {
            if (id != null && id2 != null)
            {
                List<Message> messages = MessageRepository
                    .GetMessagesFromChatWithUser((int)id)
                    .Where(m => m.User.UserId == (int)id2)
                    .ToList();

                return Json(messages, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}