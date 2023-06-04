using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Eksamensprojekt_Final_1_Web_App.Controllers
{
    //Controller til alt vedrørende beskeder. 
    public class MessageController : Controller
    {
        private IMessageRepository MessageRepository = new MessageRepository();
        // GET: Message
        public ActionResult GetMessages()
        {
            List<Message> messages = MessageRepository.GetAllMessages();


            return View("Messages", messages);
        }


        /// <summary>
        /// Skulle have været en [ChildActionOnly]. 
        /// Men man kan ikke lave ajax kald til denne type, så blev nød til at lave den på denne måde.
        /// </summary>
        public ActionResult _messagesListView(int? id, int? id2)
        {
            if (id != null && id2 != null)
            {
                List<Message> messages = MessageRepository
                    .GetMessagesFromChatWithUser((int)id)
                    .Where(m => m.User.UserId == (int)id2)
                    .ToList();

                string html = RenderPartialViewToString("_messagesListView", messages);
                return Content(html);
            }

            return Content("");
        }

        /// <summary>
        /// Metode til at lave et partialview om til text, så det kan sendes direkte til browseren og renders,
        /// </summary>
        private string RenderPartialViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}